using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.SqlServer
{
    public static class MsSqlServerVersion
    {
        public static bool Is_2005(this DatabaseServerVersion version) { return version != null && version.IsMinimally(9, 0, 0); }
        public static bool Is_2008(this DatabaseServerVersion version) { return version != null && version.IsMinimally(10, 0, 0); }
    }

    public class SqlServerDatabaseAnalyser : DatabaseAnalyser
    {
        private Dictionary<NameWithSchema, TableInfo> _tables = new Dictionary<NameWithSchema, TableInfo>();
        private Dictionary<string, TableInfo> _tablesById = new Dictionary<string, TableInfo>();
        private Dictionary<string, ViewInfo> _viewsById = new Dictionary<string, ViewInfo>();

        private SqlConnection Connection
        {
            get { return (SqlConnection) _conn; }
        }

        private DateTime _last = DateTime.Now;

        private void Timer(string msg)
        {
            var now = DateTime.Now;
            Debug.WriteLine("{0:0.00}", (now - _last).TotalMilliseconds);
            Debug.WriteLine(msg);
            _last = now;
        }

        private string CreateFilterExpression(bool tables = false, bool views = false,
            bool procedures = false, bool functions = false, bool triggers = false)
        {
            List<string> res = null;
            if (tables && FilterOptions.TableFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.TableFilter);
            }
            if (views && FilterOptions.ViewFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.ViewFilter);
            }
            if (procedures && FilterOptions.StoredProcedureFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.StoredProcedureFilter);
            }
            if (functions && FilterOptions.FunctionFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.FunctionFilter);
            }
            if (triggers && FilterOptions.TriggerFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.TriggerFilter);
            }
            if (res != null)
            {
                if (res.Count == 0) return " = 0";
                return " in (" + res.CreateDelimitedText(",") + ")";
            }
            return " is not null";
        }

        private string CreateQuery(string resFileName, bool tables = false, bool views = false,
            bool procedures = false, bool functions = false, bool triggers = false)
        {
            string res = SqlServerDatabaseFactory.LoadEmbeddedResource(resFileName);
            res = res.Replace("=[OBJECT_ID_CONDITION]", CreateFilterExpression(tables, views, procedures, functions, triggers));
            res = SqlServerLinkedServer.ReplaceLinkedServer(res, LinkedServerName, DatabaseName);
            return res;
        }

        public string SimplifyExpression(string expr)
        {
            while (expr != null && expr.StartsWith("(") && expr.EndsWith(")"))
            {
                expr = expr.Substring(1, expr.Length - 2);
            }
            return expr;
        }

        protected override void DoRunAnalysis()
        {
            foreach (var table in Structure.Tables)
            {
                _tables[table.FullName] = table;
                _tablesById[table.ObjectId] = table;
            }

            foreach (var view in Structure.Views)
            {
                _viewsById[view.ObjectId] = view;
            }

            var dialect = SqlServerDatabaseFactory.Instance.CreateDialect();

            if (FilterOptions.AnyTables && IsTablesPhase)
            {
                Timer("tables...");
                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("tables.sql", tables: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            int modifyIndex = reader.GetOrdinal("modify_date");
                            int createIndex = reader.GetOrdinal("modify_date");
                            while (reader.Read())
                            {
                                string tname = reader.SafeString("TableName");
                                string schema = reader.SafeString("SchemaName");
                                string id = reader.SafeString("object_id");
                                DateTime modify = reader.GetDateTime(modifyIndex);
                                DateTime create = reader.GetDateTime(createIndex);

                                if (_tablesById.ContainsKey(id))
                                {
                                    var table = _tablesById[id];
                                    table.FullName = new NameWithSchema(schema, tname);
                                    table.ModifyDate = modify;
                                }
                                else
                                {
                                    var table = new TableInfo(Structure)
                                        {
                                            FullName = new NameWithSchema(schema, tname),
                                            ObjectId = id,
                                            ModifyDate = modify,
                                            CreateDate = create,
                                        };
                                    Structure.Tables.Add(table);
                                    _tables[table.FullName] = table;
                                    _tablesById[table.ObjectId] = table;
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading tables", err);
                }

                Timer("columns...");

                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        string sql = CreateQuery("columns.sql", tables: true);
                        if (ServerVersion.Is_2008() && String.IsNullOrEmpty(LinkedServerName)) sql = sql.Replace("#2008#", ",c.is_sparse");
                        else sql = sql.Replace("#2008#", "");
                        cmd.CommandText = sql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tid = reader.SafeString("object_id");
                                if (!_tablesById.ContainsKey(tid)) continue;
                                var table = _tablesById[tid];
                                var col = new ColumnInfo(table);
                                col.Name = reader.SafeString("column_name");
                                col.NotNull = reader.SafeString("is_nullable") != "True";
                                col.DataType = reader.SafeString("type_name");
                                int bytelen = reader.SafeString("max_length").SafeIntParse();
                                if (col.DataType.ToLower().Contains("nchar") || col.DataType.ToLower().Contains("nvarchar"))
                                {
                                    col.Length = bytelen >= 0 ? bytelen/2 : bytelen;
                                }
                                else if (col.DataType.ToLower().Contains("char") || col.DataType.ToLower().Contains("binary"))
                                {
                                    col.Length = bytelen;
                                }
                                col.Precision = reader.SafeString("precision").SafeIntParse();
                                col.Scale = reader.SafeString("scale").SafeIntParse();
                                col.DefaultValue = SimplifyExpression(reader.SafeString("default_value"));
                                col.DefaultConstraint = reader.SafeString("default_constraint");
                                col.AutoIncrement = reader.SafeString("is_identity") == "True";
                                col.ComputedExpression = SimplifyExpression(reader.SafeString("computed_expression"));
                                col.IsPersisted = reader.SafeString("is_persisted") == "True";
                                col.IsSparse = reader.SafeString("is_sparse") == "True";
                                col.ObjectId = reader.SafeString("column_id");
                                col.CommonType = AnalyseType(col.DataType, col.Length, col.Precision, col.Scale);
                                table.Columns.Add(col);
                                if (String.IsNullOrWhiteSpace(col.ComputedExpression)) col.ComputedExpression = null;
                                if (String.IsNullOrWhiteSpace(col.DefaultValue))
                                {
                                    col.DefaultValue = null;
                                    col.DefaultConstraint = null;
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading columns", err);
                }

                try
                {
                    Timer("primary keys...");
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("primary_keys.sql", tables: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string table = reader.SafeString("TableName");
                                string schema = reader.SafeString("SchemaName");
                                string column = reader.SafeString("ColumnName");
                                string cnt = reader.SafeString("ConstraintName");
                                var t = _tables[new NameWithSchema(schema, table)];
                                t.Columns[column].PrimaryKey = true;

                                if (t.PrimaryKey == null)
                                {
                                    t.PrimaryKey = new PrimaryKeyInfo(t);
                                    t.PrimaryKey.ConstraintName = cnt;
                                }
                                t.PrimaryKey.Columns.Add(new ColumnReference {RefColumn = t.Columns[column]});
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading primary keys", err);
                }

                try
                {
                    Timer("foreign keys...");
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("foreign_keys.sql", tables: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fktable = reader.SafeString("FK_Table");
                                string fkcolumn = reader.SafeString("FK_Column");
                                string fkschema = reader.SafeString("FK_Schema");

                                string pktable = reader.SafeString("IX_Table");
                                if (String.IsNullOrEmpty(pktable)) pktable = reader.SafeString("PK_Table");
                                string pkcolumn = reader.SafeString("IX_Column");
                                if (String.IsNullOrEmpty(pkcolumn)) pkcolumn = reader.SafeString("PK_Column");
                                string pkschema = reader.SafeString("IX_Schema");
                                if (String.IsNullOrEmpty(pkschema)) pkschema = reader.SafeString("PK_Schema");

                                string deleteAction = reader.SafeString("Delete_Action");
                                string updateAction = reader.SafeString("Update_Action");

                                string cname = reader.SafeString("Constraint_Name");

                                var fkt = _tables[new NameWithSchema(fkschema, fktable)];
                                var pkt = _tables[new NameWithSchema(pkschema, pktable)];
                                var fk = fkt.ForeignKeys.Find(f => f.ConstraintName == cname);
                                if (fk == null)
                                {
                                    fk = new ForeignKeyInfo(fkt) {ConstraintName = cname, RefTable = pkt};
                                    fk.Columns.Add(new ColumnReference
                                        {
                                            RefColumn = fkt.Columns[fkcolumn]
                                        });
                                    fk.RefColumns.Add(new ColumnReference
                                        {
                                            RefColumn = pkt.Columns[pkcolumn]
                                        });
                                    fk.OnDeleteAction = ForeignKeyActionExtension.FromSqlName(deleteAction);
                                    fk.OnUpdateAction = ForeignKeyActionExtension.FromSqlName(updateAction);
                                    fkt.ForeignKeys.Add(fk);
                                }
                                ;
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading foreign keys", err);
                }

                var indexById = new Dictionary<string, ColumnsConstraintInfo>();

                try
                {
                    Timer("indexes...");
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("getindexes.sql", tables: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string oid = reader.SafeString("object_id");
                                string ixname = reader.SafeString("ix_name");
                                string typedesc = (reader.SafeString("type_desc") ?? "").ToLower();
                                bool isunique = reader.SafeString("is_unique") == "True";
                                string indexid = reader.SafeString("index_id");
                                bool isUniqueConstraint = reader.SafeString("is_unique_constraint") == "True";

                                var table = _tablesById.Get(oid);
                                if (table == null) continue;
                                if (isUniqueConstraint)
                                {
                                    var unique = new UniqueInfo(table);
                                    unique.ObjectId = indexid;
                                    unique.ConstraintName = ixname;
                                    indexById[oid + "|" + indexid] = unique;
                                    table.Uniques.Add(unique);
                                }
                                else
                                {
                                    var index = new IndexInfo(table);
                                    index.ObjectId = indexid;
                                    index.IsUnique = isunique;
                                    index.ConstraintName = ixname;
                                    switch (typedesc)
                                    {
                                        case "clustered":
                                            index.IndexType = DbIndexType.Clustered;
                                            break;
                                        case "xml":
                                            index.IndexType = DbIndexType.Xml;
                                            break;
                                        case "spatial":
                                            index.IndexType = DbIndexType.Spatial;
                                            break;
                                        case "fulltext":
                                            index.IndexType = DbIndexType.Fulltext;
                                            break;
                                    }
                                    indexById[oid + "|" + indexid] = index;
                                    table.Indexes.Add(index);
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading indexes", err);
                }

                try
                {
                    Timer("index columns...");
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("getindexcols.sql", tables: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string oid = reader.SafeString("object_id");
                                string indexid = reader.SafeString("index_id");
                                string colid = reader.SafeString("column_id");
                                bool desc = reader.SafeString("is_descending_key") == "True";
                                bool inc = reader.SafeString("is_included_column") == "True";

                                var index = indexById.Get(oid + "|" + indexid);
                                if (index == null) continue;
                                var col = index.OwnerTable.Columns.FirstOrDefault(x => x.ObjectId == colid);
                                if (col == null) continue;

                                index.Columns.Add(new ColumnReference
                                    {
                                        RefColumn = col,
                                        IsDescending = desc,
                                        IsIncluded = inc,
                                    });
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading index columns", err);
                }

                try
                {
                    Timer("check constraints...");
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("getchecks.sql", tables: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string oid = reader.SafeString("object_id");
                                string name = reader.SafeString("name");
                                string def = SimplifyExpression(reader.SafeString("definition"));

                                var table = _tablesById.Get(oid);
                                if (table == null) continue;

                                var check = new CheckInfo(table)
                                    {
                                        ConstraintName = name,
                                        Definition = def,
                                    };

                                table.Checks.Add(check);
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading check constraints", err);
                }
            }


            var objs = new Dictionary<NameWithSchema, string>();
            if ((FilterOptions.AnyFunctions || FilterOptions.AnyStoredProcedures || FilterOptions.AnyViews || FilterOptions.AnyTriggers) && (IsViewsPhase || IsFunctionsPhase))
            {
                try
                {
                    Timer("sql code...");
                    // load code text
                    using (var cmd = Connection.CreateCommand())
                    {
                        string sql;
                        if (Phase == DatabaseAnalysePhase.All)
                        {
                            sql = CreateQuery("loadsqlcode.sql", views: true, procedures: true, functions: true, triggers: true);
                            sql = sql.Replace("#TYPECOND#", "1=1");
                        }
                        else
                        {
                            sql = CreateQuery("loadsqlcode.sql", views: IsViewsPhase, procedures: IsFunctionsPhase, functions: IsFunctionsPhase, triggers: IsFunctionsPhase);
                            var types = new List<string>();
                            if (IsViewsPhase)
                            {
                                types.Add("V");
                            }
                            if (IsFunctionsPhase)
                            {
                                types.Add("P");
                                types.Add("IF");
                                types.Add("FN");
                                types.Add("TF");
                                types.Add("TR");
                            }
                            sql = sql.Replace("#TYPECOND#", "s.type in (" + types.Select(x => "'" + x + "'").CreateDelimitedText(",") + ")");
                        }
                        cmd.CommandText = sql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            NameWithSchema lastName = null;
                            while (reader.Read())
                            {
                                var name = new NameWithSchema(reader.SafeString("OBJ_SCHEMA"), reader.SafeString("OBJ_NAME"));
                                string text = reader.SafeString("CODE_TEXT") ?? "";
                                if (lastName != null && name == lastName)
                                {
                                    objs[name] += text;
                                }
                                else
                                {
                                    lastName = name;
                                    objs[name] = text;
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading SQL code", err);
                }
            }

            if (FilterOptions.AnyViews && IsViewsPhase)
            {
                try
                {
                    Timer("views...");
                    // load views
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("loadviews.sql", views: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            int modifyIndex = reader.GetOrdinal("modify_date");
                            int createIndex = reader.GetOrdinal("modify_date");
                            while (reader.Read())
                            {
                                var name = new NameWithSchema(reader.SafeString("Schema"), reader.SafeString("Name"));
                                string id = reader.SafeString("object_id");
                                DateTime modify = reader.GetDateTime(modifyIndex);
                                DateTime create = reader.GetDateTime(createIndex);

                                var view = new ViewInfo(Structure)
                                    {
                                        FullName = name,
                                        ObjectId = id,
                                        ModifyDate = modify,
                                        CreateDate = create,
                                    };
                                if (objs.ContainsKey(name)) view.CreateSql = objs[name];
                                Structure.Views.Add(view);
                                _viewsById[view.ObjectId] = view;
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading views", err);
                }
            }

            if (FilterOptions.AnyTriggers && IsFunctionsPhase)
            {
                try
                {
                    Timer("triggers...");
                    // load triggers
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("gettriggers.sql", triggers: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            int modifyIndex = reader.GetOrdinal("modify_date");
                            int createIndex = reader.GetOrdinal("modify_date");
                            while (reader.Read())
                            {
                                var name = new NameWithSchema(reader.SafeString("schema"), reader.SafeString("name"));
                                string id = reader.SafeString("object_id");
                                string parentId = reader.SafeString("parent_id");
                                DateTime modify = reader.GetDateTime(modifyIndex);
                                DateTime create = reader.GetDateTime(createIndex);

                                var trg = new TriggerInfo(Structure)
                                    {
                                        FullName = name,
                                        ObjectId = id,
                                        ModifyDate = modify,
                                        CreateDate = create,
                                    };
                                if (objs.ContainsKey(name)) trg.CreateSql = objs[name];
                                trg.RelatedTable = _tablesById.Get(parentId);
                                trg.RelatedView = _viewsById.Get(parentId);
                                Structure.Triggers.Add(trg);
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading triggers", err);
                }
            }

            if ((FilterOptions.AnyStoredProcedures || FilterOptions.AnyFunctions) && IsFunctionsPhase)
            {
                try
                {
                    Timer("programmables...");
                    var programmables = new Dictionary<NameWithSchema, ProgrammableInfo>();

                    // load procedures and functions
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("programmables.sql", procedures: true, functions: true);
                        using (var reader = cmd.ExecuteReader())
                        {
                            int modifyIndex = reader.GetOrdinal("modify_date");
                            int createIndex = reader.GetOrdinal("modify_date");

                            while (reader.Read())
                            {
                                var name = new NameWithSchema(reader.SafeString("schema"), reader.SafeString("name"));
                                string id = reader.SafeString("object_id");
                                DateTime modify = reader.GetDateTime(modifyIndex);
                                DateTime create = reader.GetDateTime(createIndex);
                                ProgrammableInfo info = null;
                                string type = reader.SafeString("type");
                                switch (type.Trim())
                                {
                                    case "P":
                                        info = new StoredProcedureInfo(Structure);
                                        break;
                                    case "IF":
                                    case "FN":
                                    case "TF":
                                        info = new FunctionInfo(Structure);
                                        break;
                                }
                                if (info == null) continue;
                                info.ObjectId = id;
                                info.CreateDate = create;
                                info.ModifyDate = modify;
                                programmables[name] = info;
                                info.FullName = name;
                                if (objs.ContainsKey(name)) info.CreateSql = objs[name];
                                if (info is StoredProcedureInfo) Structure.StoredProcedures.Add((StoredProcedureInfo) info);
                                if (info is FunctionInfo) Structure.Functions.Add((FunctionInfo) info);
                            }
                        }
                    }

                    Timer("parameters...");

                    try
                    {
                        // load parameters
                        using (var cmd = Connection.CreateCommand())
                        {
                            cmd.CommandText = CreateQuery("parameters.sql", procedures: true, functions: true);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var name = new NameWithSchema(reader.SafeString("SPECIFIC_SCHEMA"), reader.SafeString("SPECIFIC_NAME"));
                                    if (!programmables.ContainsKey(name)) continue;
                                    var prg = programmables[name];
                                    if (reader.SafeString("IS_RESULT") == "YES")
                                    {
                                        var func = prg as FunctionInfo;
                                        if (func == null) continue;
                                        func.ResultType = reader.SafeString("DATA_TYPE");
                                        continue;
                                    }
                                    var arg = new ParameterInfo(prg);
                                    prg.Parameters.Add(arg);
                                    arg.DataType = reader.SafeString("DATA_TYPE");
                                    arg.Name = reader.SafeString("PARAMETER_NAME");
                                    arg.IsOutput = reader.SafeString("PARAMETER_MODE") == "OUT";
                                }
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        AddErrorReport("Error loading parameters", err);
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading programmables", err);
                }
            }

            Timer("view structure...");

            if (FilterOptions.AnyViews && IsViewsPhase)
            {
                try
                {
                    // load view structure
                    foreach (var view in Structure.Views)
                    {
                        if (FilterOptions.ViewFilter != null && !FilterOptions.ViewFilter.Contains(view.ObjectId))
                        {
                            continue;
                        }

                        using (var cmd = Connection.CreateCommand())
                        {
                            cmd.CommandText = SqlServerLinkedServer.ReplaceLinkedServer("SELECT * FROM [SERVER]." + dialect.QuoteFullName(view.FullName), LinkedServerName, DatabaseName);
                            try
                            {
                                using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly | CommandBehavior.KeyInfo))
                                {
                                    var queryInfo = reader.GetQueryResultInfo();
                                    view.QueryInfo = queryInfo;
                                }
                            }
                            catch (Exception err)
                            {
                                view.QueryInfo = null;
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading view structure", err);
                }
            }

            if (FilterOptions.GlobalSettings && IsSettingsPhase)
            {
                try
                {
                    Timer("default schema...");

                    // load default schema
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SCHEMA_NAME()";
                        Structure.DefaultSchema = cmd.ExecuteScalar().ToString();
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading defgault schema", err);
                }
            }

            if (IsSettingsPhase)
            {
                try
                {
                    Timer("schemas...");

                    // load schemas
                    using (var cmd = Connection.CreateCommand())
                    {
                        Structure.Schemas.Clear();
                        cmd.CommandText = CreateQuery("getschemas.sql");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader.SafeString("name");
                                string id = reader.SafeString("object_id");
                                Structure.Schemas.Add(new SchemaInfo(Structure)
                                    {
                                        ObjectId = id,
                                        Name = name,
                                    });
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading schemas", err);
                }
            }

            Timer("done...");

            //Structure.FixPrimaryKeys();
        }

        public static DbTypeBase AnalyseType(string dt, int len, int prec, int scale)
        {
            switch (dt)
            {
                case "binary":
                    return new DbTypeString
                        {
                            Length = len,
                            IsBinary = true,
                        };
                case "image":
                    return new DbTypeBlob();
                case "timestamp":
                    return new DbTypeString();
                case "varbinary":
                    return new DbTypeString
                        {
                            Length = len,
                            IsBinary = true,
                            IsVarLength = true,
                        };
                case "bit":
                    return new DbTypeLogical();
                case "tinyint":
                    return new DbTypeInt
                        {
                            Bytes = 1
                        };
                case "datetime":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                        };
                case "datetime2":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                        };
                case "datetimeoffset":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                            HasTimeZone = true,
                        };
                case "date":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Date,
                        };
                case "time":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Time,
                        };
                case "smalldatetime":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                        };
                case "decimal":
                    return new DbTypeNumeric
                        {
                            Precision = prec,
                            Scale = scale,
                        };
                case "numeric":
                    return new DbTypeNumeric
                        {
                            Precision = prec,
                            Scale = scale,
                        };
                case "float":
                    return new DbTypeFloat();
                case "uniqueidentifier":
                    return new DbTypeGuid();
                case "smallint":
                    return new DbTypeInt
                        {
                            Bytes = 2
                        };
                case "int":
                    return new DbTypeInt
                        {
                            Bytes = 4
                        };
                case "bigint":
                    return new DbTypeInt
                        {
                            Bytes = 8
                        };
                case "real":
                    return new DbTypeFloat();
                case "char":
                    return new DbTypeString
                        {
                            Length = len,
                        };
                case "nchar":
                    return new DbTypeString
                        {
                            Length = len,
                            IsUnicode = true,
                        };
                case "varchar":
                    return new DbTypeString
                        {
                            Length = len,
                            IsVarLength = true,
                        };
                case "nvarchar":
                    return new DbTypeString
                        {
                            Length = len,
                            IsVarLength = true,
                            IsUnicode = true,
                        };
                case "text":
                    return new DbTypeText();
                case "ntext":
                    return new DbTypeText();
                case "xml":
                    return new DbTypeXml();
                case "money":
                    return new DbTypeNumeric();
                case "smallmoney":
                    return new DbTypeNumeric();
                case "sql_variant":
                    return new DbTypeText();
            }
            return new DbTypeGeneric {Sql = dt};
        }

        protected override void DoGetModifications()
        {
            var existingObjects = new HashSet<string>();

            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = SqlServerLinkedServer.ReplaceLinkedServer(SqlServerDatabaseFactory.LoadEmbeddedResource("modifications.sql"), LinkedServerName, DatabaseName);
                using (var reader = cmd.ExecuteReader())
                {
                    int modifyIndex = reader.GetOrdinal("modify_date");

                    while (reader.Read())
                    {
                        string id = reader.SafeString("object_id");
                        DateTime modify = reader.GetDateTime(modifyIndex);
                        string stype = reader.SafeString("type");
                        string name = reader.SafeString("name");
                        string schema = reader.SafeString("schema");

                        existingObjects.Add(id);

                        DatabaseObjectType type;
                        switch (stype.Trim())
                        {
                            case "U":
                                type = DatabaseObjectType.Table;
                                break;
                            case "V":
                                type = DatabaseObjectType.View;
                                break;
                            case "P":
                                type = DatabaseObjectType.StoredProcedure;
                                break;
                            case "IF":
                            case "FN":
                            case "TF":
                                type = DatabaseObjectType.Function;
                                break;
                            case "TR":
                                type = DatabaseObjectType.Trigger;
                                break;
                            default:
                                continue;
                        }

                        var obj = Structure.FindObjectById(id);

                        if (obj == null)
                        {
                            var item = new DatabaseChangeItem
                                {
                                    Action = DatabaseChangeAction.Add,
                                    ObjectId = id,
                                    ObjectType = type,
                                    NewName = new NameWithSchema(schema, name),
                                };
                            ChangeSet.Items.Add(item);
                        }
                        else
                        {
                            if (obj.ModifyDate == null || Math.Abs((obj.ModifyDate.Value - modify).TotalSeconds) >= 1)
                            {
                                var item = new DatabaseChangeItem
                                    {
                                        Action = DatabaseChangeAction.Change,
                                        ObjectId = id,
                                        ObjectType = type,
                                        OldName = ((NamedObjectInfo) obj).FullName,
                                        NewName = new NameWithSchema(schema, name),
                                    };
                                ChangeSet.Items.Add(item);
                            }
                        }
                    }
                }
            }
            AddDeletedObjects(Structure.Tables, existingObjects);
            AddDeletedObjects(Structure.Views, existingObjects);
            AddDeletedObjects(Structure.StoredProcedures, existingObjects);
            AddDeletedObjects(Structure.Functions, existingObjects);
        }

        private void AddDeletedObjects<T>(IEnumerable<T> items, HashSet<string> existingObjects)
            where T : NamedObjectInfo
        {
            foreach (var obj in items)
            {
                if (!existingObjects.Contains(obj.ObjectId))
                {
                    var item = new DatabaseChangeItem
                        {
                            Action = DatabaseChangeAction.Remove,
                            ObjectId = obj.ObjectId,
                            ObjectType = obj.ObjectType,
                            OldName = obj.FullName,
                        };
                    ChangeSet.Items.Add(item);
                }
            }
        }
    }
}
