using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.IO;
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
        Materialize,
        Rollback,

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
        private StringWriter _sw;
        private IDatabaseFactory _factory;

        public SqlScriptCompiler(IDatabaseFactory factory, DataSyncSqlModel datasync, IShellContext context, string procName)
        {
            _context = context;
            _procName = procName;
            _datasync = datasync;
            _factory = factory;

            _sw = new StringWriter();
            var so = new SqlOutputStream(factory.CreateDialect(), _sw, new SqlFormatProperties());
            so.OverrideCommandDelimiter(";");
            _dmp = factory.CreateDumper(so, new SqlFormatProperties());
        }

        public ISqlDumper Dumper => _dmp;
        public IDatabaseFactory Factory => _factory;
        public void Put(string format, params object[] args) => _dmp.Put(format, args);
        public void PutCmd(string format, params object[] args) => _dmp.PutCmd(format, args);
        public static DmlfExpression ImportDateTimeExpression => new DmlfSqlValueExpression { Value = ImportDateTimeVariableName };
        public string GetCompiledSql() => _sw.ToString();

        private const string SEPARATOR =
            "------------------------------------------------------------------------------------------------";

        public void EndCommand()
        {
            _dmp.EndCommand();
            _dmp.Put("&n");
        }

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

        public void PutProcedureHeader(NameWithSchema name, bool useTransaction, string createKeyword, List<ParameterModel> pars)
        {
            Put($"%k ^procedure %f ({ImportDateTimeVariableName} ^datetime = ^null", createKeyword, name);
            if (useTransaction) Put(", @useTransaction bit = 1");

            foreach(var par in pars)
            {
                Put($", @{par.Name} {par.DataType} = ^null");
            }

            Put($") ^as &n");
            Put("^begin&>&n");
            Put($"^if ({ImportDateTimeVariableName} ^is ^null) ^set {ImportDateTimeVariableName} = ^getdate();&n");

            foreach (var par in pars)
            {
                if (String.IsNullOrEmpty(par.DefaultValue)) continue;
                Put($"^if (@{par.Name} ^is ^null) ^set @{par.Name} = {par.DefaultValue}; &n");
            }
        }

        public void PutCommonProlog(bool useTransaction, string sqlPrologBeforeBeginTransaction, string sqlPrologAfterBeginTransaction)
        {
            Put($"^declare {ImportDateVariableName} ^datetime;&n");
            Put($"^set {ImportDateVariableName} = ^dateadd(dd, 0, ^datediff(dd, 0, {ImportDateTimeVariableName}));&n");
            Put("^declare @rows ^nvarchar(100);&n");
            Put("^declare @msg ^nvarchar(^max);&n");
            Put("^declare @lastLogDiff ^float;&n");

            Put("DECLARE @CatchErrorMessage NVARCHAR(4000);&n");
            Put("DECLARE @CatchErrorSeverity INT;;&n");
            Put("DECLARE @CatchErrorState INT;&n");
            Put("DECLARE @SqlTemplate NVARCHAR(MAX);&n");

            Put("^declare @messages ^table (ID INT NOT NULL PRIMARY KEY IDENTITY, Message NVARCHAR(MAX), Created DATETIME NOT NULL DEFAULT GETDATE(), Duration FLOAT, Operation NVARCHAR(100), TargetEntity  NVARCHAR(250), Rows INT)");
            PutLogMessage(null, LogOperationType.Start, "Import started", null);
            StartTimeMeasure("IMPORT");

            PutSqlScript(sqlPrologBeforeBeginTransaction);

            if (useTransaction)
            {
                PutBeginTransaction();
            }

            PutSqlScript(sqlPrologAfterBeginTransaction);
        }

        private void PutSqlScript(string sql)
        {
            if (String.IsNullOrEmpty(sql)) return;
            foreach (var item in GoSplitter.GoSplit(sql))
            {
                Put("&r"); // dump separator if needed
                _dmp.WriteRaw(item.Data);
                _dmp.EndCommand();
                Put("&d"); // mark data dumped state
            }
        }

        public void PutCommonEpilog(bool useTransaction, string sqlEpilogBeforeCommitTransaction, string sqlEpilogAfterCommitTransaction)
        {
            PutSqlScript(sqlEpilogBeforeCommitTransaction);
            if (useTransaction)
            {
                PutEndTransaction();
            }
            PutSqlScript(sqlEpilogAfterCommitTransaction);

            PutLogMessage(null, LogOperationType.Finish, "Import finished", "IMPORT");
            Put("^select * from @messages;&n");
        }

        public void PutProcedureFooter()
        {
            Put("&<&n^end&n");
        }

        public void PutScriptProlog(bool useTransaction, List<ParameterModel> pars, Dictionary<string, string> parValues)
        {
            Put($"^declare {ImportDateTimeVariableName} ^ datetime;&n");
            Put($"^set {ImportDateTimeVariableName} = ^getdate();&n");
            if (useTransaction)
            {
                Put("^declare @useTransaction bit;&n");
                Put("^set @useTransaction = 1;&n");
            }

            foreach (var par in pars)
            {
                Put($"declare @{par.Name} {par.DataType} = ^null;&n");
                string value = par.DefaultValue;
                if (parValues.ContainsKey(par.Name)) value = parValues[par.Name];
                if (!String.IsNullOrEmpty(value))
                {
                    Put($"^if (@{par.Name} ^is ^null) ^set @{par.Name} = {value}; &n");
                }
            }
        }

        public void PutBeginTryCatch(TargetEntitySqlModel entity)
        {
            Put("^begin ^try&n");
            Put("IF NULL = NULL SELECT NULL;&n");
        }

        public void PutEndTryCatch(TargetEntitySqlModel entity, bool useTransaction)
        {
            Put("^end ^try&n");
            Put("^begin ^catch&n");
            Put("&>");
            PutLogMessage(entity, LogOperationType.Error, null, null);
            Put("&<");
            if (useTransaction)
            {
                Put("^if (@useTransaction = 1) begin SELECT @CatchErrorMessage = ERROR_MESSAGE(),@CatchErrorSeverity = ERROR_SEVERITY(), @CatchErrorState = ERROR_STATE();RAISERROR (@CatchErrorMessage, @CatchErrorSeverity, @CatchErrorState);^end;");
            }
            Put("^end ^catch&n");
        }

        private void PutBeginTransaction()
        {
            PutIfTransactionStart();
            Put("BEGIN TRANSACTION&n");
            PutIfTransactionEnd();
            Put("BEGIN TRY&n");
            Put("&>");
        }

        private void PutEndTransaction()
        {
            Put("&<");
            PutIfTransactionStart();
            Put("COMMIT TRANSACTION&n");
            PutIfTransactionEnd();
            Put("END TRY&n");
            Put("BEGIN CATCH&n");
            Put("&>");
            PutIfTransactionStart();
            Put("ROLLBACK TRANSACTION&n");
            PutIfTransactionEnd();
            PutLogMessage(null, LogOperationType.Rollback, "Import failed, transaction rollbacked", null);
            //PutLogMessage(null, LogOperationType.Error, null, null);
            Put("&<");
            Put("^end ^catch&n");
        }

        public void CreateOrAlterProcedure(NameWithSchema name, string sqlCore)
        {
            Put("^declare @procedureText ^nvarchar(^max);&n");
            Put("^set @procedureText = %v;&n", sqlCore);
            if (name.Schema != null)
            {
                Put("^if (^exists (^select * from sys.objects inner join sys.schemas on schemas.schema_id = objects.schema_id where type='P' and schemas.name=%v and objects.name=%v))&n", name.Schema, name.Name);
            }
            else
            {
                Put("^if (^exists (^select * from sys.objects inner join sys.schemas on schemas.schema_id = objects.schema_id where type='P' and objects.name=%v))&n", name.Name);
            }
            Put("begin&nset @procedureText = 'alter' + @procedureText&nend&nelse&nbegin&nset @procedureText = 'create' + @procedureText&nend&n");
            Put("exec sp_executesql @procedureText;&n");
        }

        private void PutIfTransactionEnd()
        {
            Put("^end&<&n");
        }

        private void PutIfTransactionStart()
        {
            Put("^if (@useTransaction = 1)&>&n^begin&nIF NULL=NULL SELECT NULL;&n");
        }


        public void PutLogMessage(TargetEntitySqlModel entity, LogOperationType operation, string message, string durationName)
        {
            Put("set @rows = cast(@@ROWCOUNT as nvarchar);&n");
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
                    throw new Exception("DBSH-00218 Duration name not defined: " + durationName);
                Put($"set @lastLogDiff = DATEDIFF(second, @lastLogTime_{durationName}, GETDATE());&n");
            }
            else
            {
                Put("set @lastLogDiff = NULL;&n");
            }

            Put($"INSERT INTO @messages (Message, Duration, Operation, TargetEntity, Rows) VALUES (@msg, @lastLogDiff, '{operation}', %v, @rows);&n", entity?.LogName);
            Put("PRINT @msg; &n");
            _datasync.Dbsh.LogHandlers.ForEach(x => x.PutLogMessage(
                Dumper,
                $"'{operation}'",
                entity == null ? "NULL" : $"'{entity.LogName}'",
                "@msg",
                "@lastLogDiff",
                _procName == null ? "NULL" : $"'{_procName}'",
                "@rows",
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
