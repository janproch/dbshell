using DbShell.Common;
using DbShell.Driver.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace DbShell.Core.NetCore.SqlGenerator
{
    public class SqlGeneratorModel
    {
        IConnectionProvider _provider;
        IDatabaseFactory _factory;
        SqlOutputStream _sqlo;
        ISqlDumper _dmp;
        GenerateSql _options;
        DatabaseInfo _database;
        List<TableInfo> _tables = new List<TableInfo>();
        List<ViewInfo> _views = new List<ViewInfo>();
        List<StoredProcedureInfo> _storedProcedures = new List<StoredProcedureInfo>();
        List<FunctionInfo> _functions = new List<FunctionInfo>();
        SqlDialectCaps _dialectCaps;
        ICancelableProcessCallback _cancelable;
        private bool _isCanceled;

        public SqlGeneratorModel(IConnectionProvider provider, TextWriter stream, GenerateSql options, DatabaseInfo database, ICancelableProcessCallback cancelable)
        {
            _cancelable = cancelable;
            _provider = provider;
            _factory = _provider.Factory;
            _sqlo = new SqlOutputStream(_factory.CreateDialect(), stream, new SqlFormatProperties());
            _dmp = _factory.CreateDumper(_sqlo, new SqlFormatProperties());
            _options = options;
            _database = database;
            _dialectCaps = _factory.DialectCaps;

            FillWorkingSets();
        }

        private void FillWorkingSets()
        {
            if (_options.TableOptions.AllTables)
            {
                _tables.AddRange(_database.Tables);
            }
            else
            {
                _tables.AddRange(_options.TableOptions.TableFilter.Select(x => _database.FindTable(x)).Where(x => x != null));
            }

            if (_options.ViewOptions.AllObjects)
            {
                _views.AddRange(_database.Views);
            }
            else
            {
                _views.AddRange(_options.ViewOptions.ObjectFilter.Select(x => _database.FindView(x)).Where(x => x != null));
            }

            if (_options.StoredProcedureOptions.AllObjects)
            {
                _storedProcedures.AddRange(_database.StoredProcedures);
            }
            else
            {
                _storedProcedures.AddRange(_options.StoredProcedureOptions.ObjectFilter.Select(x => _database.FindStoredProcedure(x)).Where(x => x != null));
            }

            if (_options.FunctionOptions.AllObjects)
            {
                _functions.AddRange(_database.Functions);
            }
            else
            {
                _functions.AddRange(_options.FunctionOptions.ObjectFilter.Select(x => _database.FindFunction(x)).Where(x => x != null));
            }
        }

        public void Run()
        {
            try
            {
                _cancelable?.AddCancelMethod(this, () => _isCanceled = true);
                DoRun();

                if (IsFull)
                {
                    _dmp.Comment(" ******************************* SQL is truncated  ******************************* ");
                }
            }
            finally
            {
                _cancelable?.RemoveCancelMethod(this);
            }
        }

        private void DoRun()
        {
            DropObjects(_storedProcedures, _options.StoredProcedureOptions, _dmp.DropStoredProcedure);
            if (IsFull || _isCanceled) return;
            DropObjects(_functions, _options.FunctionOptions, _dmp.DropFunction);
            if (IsFull || _isCanceled) return;
            DropObjects(_views, _options.ViewOptions, _dmp.DropView);
            if (IsFull || _isCanceled) return;
            DropTables();
            if (IsFull || _isCanceled) return;

            CreateTables();
            if (IsFull || _isCanceled) return;

            TruncateTables();
            if (IsFull || _isCanceled) return;
            InsertTables();
            if (IsFull || _isCanceled) return;

            CreateForeignKeys();
            if (IsFull || _isCanceled) return;

            CreateObjects(_views, _options.ViewOptions, _dmp.CreateView);
            if (IsFull || _isCanceled) return;
            CreateObjects(_storedProcedures, _options.StoredProcedureOptions, _dmp.CreateStoredProcedure);
            if (IsFull || _isCanceled) return;
            CreateObjects(_functions, _options.FunctionOptions, _dmp.CreateFunction);
            if (IsFull || _isCanceled) return;
        }

        private void DropObjects<T>(List<T> objects, GenerateSqlObjectOptions options, Action<T, bool> drop)
        {
            if (options.Drop)
            {
                objects.ForEach(x => drop(x, options.CheckExists));
            }
        }

        private void CreateObjects<T>(List<T> objects, GenerateSqlObjectOptions options, Action<T> create)
        {
            if (options.Create)
            {
                objects.ForEach(x => create(x));
            }
        }

        private void InsertTables()
        {
            if (!_options.TableOptions.Insert) return;
            EnableConstraints(false);
            foreach (var table in _tables)
            {
                if (IsFull || _isCanceled) return;
                InsertTableData(table);
            }
            EnableConstraints(true);
        }

        private string GenerateSqlScript(Action<ISqlDumper> dmpFunc)
        {
            var sw = new StringWriter();
            var sqlo = new SqlOutputStream(_factory.CreateDialect(), sw, new SqlFormatProperties());
            var dmp = _factory.CreateDumper(sqlo, new SqlFormatProperties());
            dmpFunc(dmp);
            return sw.ToString();
        }

        private ICdlReader CreateTableReader(TableInfo table, out DbCommand cmd)
        {
            string sql = GenerateSqlScript(dmp => dmp.Put("^select %,i ^from %f", table.Columns.Select(x => x.Name), table.FullName));
            var dda = _factory.CreateDataAdapter();
            var conn = _provider.Connect();
            cmd = conn.CreateCommand();
            cmd.CommandTimeout = 3600;
            cmd.CommandText = sql;
            _cancelable?.AddCancelMethod(cmd, cmd.Cancel);
            var reader = cmd.ExecuteReader();
            var result = dda.AdaptReader(reader);
            result.Disposing += () =>
            {
                reader.Dispose();
                conn.Dispose();
            };
            return result;
        }

        private void InsertTableData(TableInfo table)
        {
            if (!_options.TableOptions.Insert) return;
            ColumnInfo autoinc = table.FindAutoIncrementColumn();
            if (autoinc != null && !_options.TableOptions.SkipAutoincrementColumn) _dmp.AllowIdentityInsert(table.FullName, true);

            var colIndexes = new List<int>();
            for (int i = 0; i < table.ColumnCount; i++) colIndexes.Add(i);
            var colNames = table.Columns.Select(x => x.Name).ToList();

            if (_options.TableOptions.SkipAutoincrementColumn && autoinc != null)
            {
                int index = table.Columns.IndexOf(autoinc);
                colIndexes.RemoveAt(index);
                colNames.RemoveAt(index);
            }

            var colIndexesArray = colIndexes.ToArray();

            using (var reader = CreateTableReader(table, out var cmd))
            {
                try
                {
                    while (reader.Read())
                    {
                        if (IsFull || _isCanceled)
                        {
                            cmd.Cancel();
                            return;
                        }
                        if (_options.TableOptions.OmitNulls)
                        {
                            var values = reader.GetValuesByCols(colIndexesArray).ToList();
                            var colNamesCopy = new List<string>(colNames);

                            for (int i = values.Count - 1; i >= 0; i--)
                            {
                                if (values[i] == null)
                                {
                                    values.RemoveAt(i);
                                    colNamesCopy.RemoveAt(i);
                                }
                            }

                            _dmp.Put("^insert ^into %f (%,i) ^values (%,v);&n", table.FullName, colNamesCopy, values);
                        }
                        else
                        {
                            _dmp.Put("^insert ^into %f (%,i) ^values (%,v);&n", table.FullName, colNames, reader.GetValuesByCols(colIndexesArray));
                        }
                    }
                }
                finally
                {
                    _cancelable?.RemoveCancelMethod(cmd);
                }
            }

            if (autoinc != null && !_options.TableOptions.SkipAutoincrementColumn) _dmp.AllowIdentityInsert(table.FullName, false);
        }

        private void EnableConstraints(bool enabled)
        {
            if (_options.TableOptions.DisableConstraints)
            {
                if (_dialectCaps.EnableConstraintsPerTable)
                {
                    _tables.ForEach(x => _dmp.EnableConstraints(x.FullName, enabled));
                }
                else
                {
                    _tables.ForEach(x => _dmp.EnableConstraints(null, enabled));
                }
            }
        }

        private void TruncateTables()
        {
            if (_options.TableOptions.Truncate)
            {
                _tables.ForEach(x => _dmp.TruncateTable(x.FullName));
            }
        }

        private bool IsFull => _options.FileSizeLimit > 0 && _sqlo.Length > _options.FileSizeLimit;

        private void DropTables()
        {
            if (_options.TableOptions.DropReferences)
            {
                _tables.SelectMany(x => x.GetReferences()).ToList().ForEach(x => _dmp.DropForeignKey(x));
            }

            if (_options.TableOptions.DropTables)
            {
                _tables.ForEach(x => _dmp.DropTable(x, _options.TableOptions.CheckIfTableExists));
            }
        }

        private void CreateTables()
        {
            if (_options.TableOptions.CreateTables)
            {
                _tables.ForEach(x => _dmp.CreateTable(x.WithoutIndexes().WithoutReferences()));
            }
            if (_options.TableOptions.CreateIndexes)
            {
                _tables.SelectMany(x => x.Indexes).ToList().ForEach(x => _dmp.CreateIndex(x));
            }
        }

        private void CreateForeignKeys()
        {
            var fks = new List<ForeignKeyInfo>();
            if (_options.TableOptions.CreateForeignKeys)
            {
                fks.AddRange(_tables.SelectMany(x => x.ForeignKeys));
            }
            if (_options.TableOptions.CreateReferences)
            {
                fks.AddRange(_tables.SelectMany(x => x.GetReferences()));
            }

            fks.Distinct().ToList().ForEach(x => _dmp.CreateForeignKey(x));
        }
    }
}
