using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public enum LogOperationType
    {
        Insert,
        Delete,
        Update,
        Start,
        Finish,
        MarkRelived,
        MarkUpdated,
        MarkDeleted,
        Error,
        TableSynchronized,

        //Materialize,
        //Script,
        //SetValidToDelete,
        //SetValidToUpdate,
        //PhysicalDelete,
    }

    public class SqlScriptCompiler
    {
        private ISqlDumper _dmp;
        public static readonly string ImportDateVariableName = "@importDate";
        public static readonly string ImportDateTimeVariableName = "@importDateTime";
        private HashSet<string> _startedDurations = new HashSet<string>();
        private DataSyncSqlModel _datasync;
        private IShellContext _context;
        private string _procName;
        private bool _inTransaction;

        public SqlScriptCompiler(ISqlDumper dmp, DataSyncSqlModel datasync, IShellContext context, string procName)
        {
            _dmp = dmp;
            _datasync = datasync;
            _context = context;
            _procName = procName;
        }

        public ISqlDumper Dumper => _dmp;
        public void Put(string format, params object[] args) => _dmp.Put(format, args);
        public void PutCmd(string format, params object[] args) => _dmp.PutCmd(format, args);
        public void EndCommand() => _dmp.EndCommand();
        public static DmlfExpression ImportDateTimeExpression => new DmlfSqlValueExpression { Value = ImportDateTimeVariableName };

        private const string SEPARATOR =
            "------------------------------------------------------------------------------------------------";

        public void PutSmallTitleComment(string title)
        {
            _dmp.Put("&n");
            string s = "-- " + title + " ";
            while (s.Length < SEPARATOR.Length) s += "-";
            _dmp.Put(s);
            _dmp.Put("&n");
        }

        public void PutSeparator()
        {
            _dmp.Put(SEPARATOR);
            _dmp.Put("&n");
        }

        public void PutMainTitleComment(string msg)
        {
            _dmp.Put("&n");
            PutSeparator();
            _dmp.Put("-- %s &n", msg);
            PutSeparator();
            _dmp.Put("&n");
        }

        public void PutProcedureHeader(NameWithSchema name)
        {
            Put($"^create ^procedure %f ({ImportDateTimeVariableName} ^datetime = ^null) ^as &n", name);
            Put("^begin&>&n");
            Put($"^if ({ImportDateTimeVariableName} ^is ^null) ^set {ImportDateTimeVariableName} = ^getdate();&n");
        }

        public void PutCommonProlog(bool useTransaction)
        {
            Put($"^declare {ImportDateVariableName} ^datetime;&n");
            Put($"^set {ImportDateVariableName} = ^dateadd(dd, 0, ^datediff(dd, 0, {ImportDateTimeVariableName}));&n");
            Put("^declare @rows ^nvarchar(100);&n");
            Put("^declare @msg ^nvarchar(^max);&n");
            Put("^declare @lastLogDiff ^float;");
            Put("^declare @messages ^table (ID INT NOT NULL PRIMARY KEY IDENTITY, Message NVARCHAR(MAX), Created DATETIME NOT NULL DEFAULT GETDATE(), Duration FLOAT, Operation NVARCHAR(100), TargetEntity  NVARCHAR(250))");
            PutLogMessage(null, LogOperationType.Start, "Import started", null);
            StartTimeMeasure("IMPORT");

            if (useTransaction)
            {
                PutBeginTransaction();
            }
        }

        public void PutCommonEpilog(bool useTransaction)
        {
            if (useTransaction)
            {
                PutEndTransaction();
            }

            PutLogMessage(null, LogOperationType.Finish, "Import finished", "IMPORT");
            Put("^select * from @messages;&n");
        }

        public void PutProcedureFooter()
        {
            Put("&<&n^end&n");
        }

        public void PutScriptProlog()
        {
            Put($"^declare {ImportDateTimeVariableName} ^ datetime;&n");
            Put($"^^set {ImportDateTimeVariableName} = ^getdate();&n");
        }

        public void PutBeginTryCatch(TargetEntitySqlModel entity)
        {
            if (_inTransaction) return;
            Put("^begin ^try&n");
        }

        public void PutEndTryCatch(TargetEntitySqlModel entity)
        {
            if (_inTransaction) return;
            Put("^end ^try&n");
            Put("^begin ^catch&n");
            Put("&>");
            PutLogMessage(entity, LogOperationType.Error, null, null);
            Put("&<");
            Put("^end ^catch&n");
        }

        private void PutBeginTransaction()
        {
            if (_inTransaction) throw new Exception("DBSH-00000 Nested transactions are not allowed");
            Put("BEGIN TRANSACTION&n");
            Put("BEGIN TRY&n");
            Put("&>");
            _inTransaction = true;
        }

        private void PutEndTransaction()
        {
            _inTransaction = false;
            Put("&<");
            Put("COMMIT TRANSACTION&n");
            Put("END TRY&n");
            Put("BEGIN CATCH&n");
            Put("&>");
            Put("ROLLBACK TRANSACTION&n");
            PutLogMessage(null, LogOperationType.Error, null, null);
            Put("&<");
            Put("^end ^catch&n");
        }


        public void PutLogMessage(TargetEntitySqlModel entity, LogOperationType operation, string message, string durationName)
        {
            if (message == null)
            {
                Put("set @msg = cast(ERROR_MESSAGE() as nvarchar(max))"
                                + " + ' Severity:' + cast(ERROR_SEVERITY() as nvarchar)"
                                + " + ' State:' + cast(ERROR_STATE() as nvarchar)"
                                + " + ' Line:' + cast(ERROR_LINE() as nvarchar)"
                                + " + ' Num:' + cast(ERROR_NUMBER() as nvarchar);&n");
            }
            else
            {
                if (entity != null) message = $"{entity.TargetTable}: {message}";

                if (message.Contains("@rows"))
                {
                    Put("set @rows = cast(@@ROWCOUNT as nvarchar);&n");
                    Put($"set @msg = REPLACE('{message}','@rows',@rows);&n");
                }
                else
                {
                    Put($"set @msg = '{message}';&n");
                }
                for (int i = 0; i < 9; i++)
                {
                    string argname = "@arg" + i;
                    if (message.Contains(argname))
                    {
                        Put($"set @msg = REPLACE(@msg,'{argname}',{argname}); &n");
                    }
                }
            }
            if (durationName != null)
            {
                if (!_startedDurations.Contains(durationName))
                    throw new Exception("DBSH-00000 Duration name not defined: " + durationName);
                Put($"set @lastLogDiff = DATEDIFF(second, @lastLogTime_{durationName}, GETDATE());&n");
            }
            else
            {
                Put("set @lastLogDiff = NULL;&n");
            }

            Put($"INSERT INTO @messages (Message, Duration, Operation, TargetEntity) VALUES (@msg, @lastLogDiff, '{operation}', %v);&n", entity?.LogName);
            Put("PRINT @msg; &n");
            _datasync.Dbsh.LogHandlers.ForEach(x => x.PutLogMessage(
                Dumper,
                $"'{operation}'",
                entity == null ? "NULL" : $"'{entity.LogName}'",
                "@msg",
                "@lastLogDiff",
                _procName == null ? "NULL" : $"'{_procName}'",
                _context));

            //sb.AppendFormat(
            //    "INSERT INTO ImportLog ([Procedure], SourceRowSet, TargetEntity, [RowCount], [Operation], ImportDate, Message, DurationSeconds) "
            //    + "VALUES ('{0}', '{1}', '{2}', @rows, '{3}', @nowDateTime, @msg, @lastLogDiff);\n",
            //    Procedure.Name,
            //    entity == null || entity.Source == null ? "" : entity.Source.Name,
            //    entity == null ? "" : entity.Name,
            //    operation.ToString().ToUpper());
        }

        public void StartTimeMeasure(string durationName)
        {
            if (!_startedDurations.Contains(durationName))
            {
                Put($"^declare @lastLogTime_{durationName} ^datetime;&n");
                _startedDurations.Add(durationName);
            }
            Put($"^set @lastLogTime_{durationName} = ^getdate();&n");
        }

    }
}
