using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DbShell.Common;
using DbShell.Core;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.DataSet.DataSetModels
{
    public class DataSetModel
    {
        private DatabaseInfo _targetDatabase;
        private bool _prepared;
        private IShellContext _context;
        private int _idVarCounter;
        public Dictionary<string, DataSetClass> Classes = new Dictionary<string, DataSetClass>();
        private IDatabaseFactory _factory;
        private IDialectDataAdapter _dda;
        private List<LoadReferencesDefinition> _loadRefDefs = new List<LoadReferencesDefinition>();
        public bool KeepUndefinedReferences = false;
        private bool _loadingStopped;
        private bool _loadAllMissing;

        public DataSetModel(DatabaseInfo targetDatabase, IShellContext context, IDatabaseFactory factory)
        {
            _targetDatabase = targetDatabase;
            _context = context;
            _factory = factory;
            _dda = _factory.CreateDataAdapter();
        }

        public DataSetClass GetClass(string name)
        {
            name = name.ToLower();
            if (Classes.ContainsKey(name)) return Classes[name];
            var tbl = _targetDatabase.FindTableLike(name);
            if (tbl == null) throw new Exception("DBSH-00120 Unknown target table in data set:" + name);
            var cls = new DataSetClass(this, tbl);
            Classes[name] = cls;
            cls.InitializeClass();
            return cls;
        }

        private List<DataSetInstance> DoLoadRows(ICdlReader reader, string targetTable)
        {
            var loaded = new List<DataSetInstance>();
            var ts = reader.Structure;
            var cls = GetClass(targetTable);

            var cols = cls.Structure.Columns.ToList();

            int[] map = new int[cols.Count];

            for (int i = 0; i < cols.Count; i++)
            {
                map[i] = ts.Columns.IndexOfIf(
                    c => System.String.Compare(c.Name, cols[i].Name, System.StringComparison.OrdinalIgnoreCase) == 0);
            }

            while (reader.Read())
            {
                if (_loadingStopped) return loaded;
                object[] newValues = new object[map.Length];
                for (int i = 0; i < map.Length; i++)
                {
                    if (map[i] < 0) continue;
                    reader.ReadValue(map[i]);
                    newValues[i] = reader.GetValue();
                }

                var added = cls.AddRecord(newValues);
                if (added != null) loaded.Add(added);
            }

            return loaded;
        }

        public void LoadFromReader(ITabularDataSource source, string targetTable, IShellContext context)
        {
            using (var reader = source.CreateReader(context))
            {
                DoLoadRows(reader, targetTable);
            }
        }

        public void LoadTable(ITabularDataSource source, string targetTable, IShellContext context)
        {
            CheckUnprepared("LoadTable");
            LoadFromReader(source, targetTable, context);
        }

        private List<DataSetClass> GetOrderedClasses()
        {
            var orderedClasses = new List<DataSetClass>();
            var rest = new List<DataSetClass>(Classes.Values);
            while (rest.Count > 0)
            {
                DataSetClass added = null;
                foreach (var cls in rest)
                {
                    bool clsok = true;
                    foreach (var r in cls.References)
                    {
                        if (!r.Mandatory) continue;
                        if (!orderedClasses.Contains(r.ReferencedClass))
                        {
                            clsok = false;
                            break;
                        }
                    }
                    if (clsok)
                    {
                        added = cls;
                        orderedClasses.Add(cls);
                        break;
                    }
                }
                if (added != null)
                {
                    rest.Remove(added);
                }
                else
                {
                    throw new Exception("DBSH-00121 Reference cycle:" + String.Join(",", rest.Select(c => c.ToString()).ToArray()));
                }
            }
            return orderedClasses;
        }

        private void CheckUnprepared(string operation)
        {
            string msg = String.Format("DBSH-00122 DataSet is prepared. Operation <ds:{0}.../> must be used before Use <ds:Prepare .../>", operation);
            if (_prepared) throw new Exception(msg);
        }

        private void CheckPrepared()
        {
            if (!_prepared) throw new Exception("DBSH-00123 DataSet is not prepared. Use <ds:Prepare .../>");
        }

        public void Warning(string message, params object[] args)
        {
            if (_context != null)
            {
                _context.OutputMessage(String.Format(message, args));
            }
        }

        public void Info(string message, params object[] args)
        {
            if (_context != null)
            {
                _context.OutputMessage(String.Format(message, args));
            }
        }

        public HashSet<int> GetAllReferences(DataSetClass cls)
        {
            var refValues = new HashSet<int>();
            foreach (var rcls in Classes.Values)
            {
                foreach (var r in rcls.References)
                {
                    if (r.ReferencedClass == cls)
                    {
                        int colindex = Array.IndexOf(r.BaseClass.Columns, r.BindingColumn);
                        if (colindex >= 0)
                        {
                            foreach (var inst in r.BaseClass.AllInstances)
                            {
                                if (inst.Values[colindex] == null || inst.Values[colindex] == DBNull.Value) continue;
                                int refid = Int32.Parse(inst.Values[colindex].ToString());
                                refValues.Add(refid);
                            }
                        }
                        else
                        {
                            Warning("Class {0} doesn't contain binding column {1}", r.BaseClass, r.BindingColumn);
                        }
                    }
                }
                //foreach (var fr in rcls.FulltextReferences)
                //{
                //    if (fr.ReferencedClass == cls)
                //    {
                //        int colindex = Array.IndexOf(fr.BaseClass.Columns, fr.BindingColumn);
                //        if (colindex >= 0)
                //        {
                //            var re = new Regex(fr.Regex);
                //            foreach (var inst in fr.BaseClass.AllInstaces)
                //            {
                //                if (inst.Values[colindex] == null || inst.Values[colindex] == DBNull.Value) continue;
                //                foreach (Match m in re.Matches(inst.Values[colindex].ToString()))
                //                {
                //                    int refid = Int32.Parse(m.Groups[fr.RegexGroup].Value);
                //                    refValues.Add(refid);
                //                }
                //            }
                //        }
                //        else
                //        {
                //            Warning("Class {0} doesn't contain binding column {1}", fr.BaseClass, fr.BindingColumn);
                //        }
                //    }
                //}
            }
            return refValues;
        }

        public DataSetModel CloneData()
        {
            CheckUnprepared("Clone");
            var res = new DataSetModel(_targetDatabase, _context, _factory);

            foreach(var cls in Classes)
            {
                res.Classes[cls.Key] = new DataSetClass(res, cls.Value.TargetTable);
            }
            foreach(var cls in res.Classes)
            {
                cls.Value.InitializeClass();
            }
            foreach (var cls in Classes)
            {
                foreach (var instance in cls.Value.AllInstances)
                {
                    res.Classes[cls.Key].AddRecord(instance.Values);
                }
            }
            return res;
        }

        public void LoadReference(string table, string column, string reftable)
        {
            LoadReference(
                new LoadReferencesDefinition
                    {
                        Column = column,
                        RefTable = reftable,
                        Table = table
                    });
        }

        public void LoadReference(LoadReferencesDefinition refDef)
        {
            CheckUnprepared("LoadReference");
            _loadRefDefs.Add(refDef);
        }

        public List<LoadReferencesDefinition> GetAvailableReferences()
        {
            var res = new List<LoadReferencesDefinition>();
            foreach (var cls in Classes.Values.ToList())
            {
                if (cls.SimplePkCol == null) continue;
                if (!cls.AllInstances.Any()) continue;
                foreach (var fk in cls.Structure.GetReferences())
                {
                    var rcls = GetClass(fk.OwnerTable.Name);
                    foreach (var refref in rcls.References)
                    {
                        if (refref.ReferencedClass != cls) continue;
                        res.Add(new LoadReferencesDefinition
                            {
                                Column = refref.BindingColumn,
                                Table = rcls.TableName,
                                RefTable = cls.TableName,
                            });
                    }
                }
            }
            return res;
        }

        public void LoadMarkedData(DbConnection conn)
        {
            CheckUnprepared("LoadMarkedData");

            foreach (var cls in Classes.Values)
            {
                if (cls.RequiredPks.Any())
                {
                    string cond = "[" + cls.Structure.PrimaryKey.Columns[0].Name + "] in (" + cls.RequiredPks.Select(x => "'" + x + "'").CreateDelimitedText(",") + ")";
                    DoAddRows(conn, cls.TableName, cond);
                    cls.RequiredPks.Clear();
                }

                foreach (string cond in cls.AddRowsRequests)
                {
                    if (_loadingStopped) return;
                    DoAddRows(conn, cls.TableName, cond);
                }
                cls.AddRowsRequests.Clear();
            }

            var loadedRefs = new HashSet<DataSetReference>();
            foreach (var loadRef in _loadRefDefs)
            {
                if (_loadingStopped) return;
                var x = GetClass(loadRef.Table);
                var r = x.FindReference(loadRef.Column, loadRef.RefTable);
                if (r == null)
                {
                    throw new Exception(String.Format("Undefined reference from {0}.{1}=>{2}", loadRef.Table, loadRef.Column, loadRef.RefTable));
                }
                loadedRefs.Add(r);
            }

            int maxSteps = 5;
            for (int step = 0; step < maxSteps; step++)
            {
                bool anyLoaded = false;
                foreach (var cls in Classes.Values)
                {
                    foreach (var r in cls.References)
                    {
                        if (_loadingStopped) return;
                        if (!loadedRefs.Contains(r)) continue;
                        anyLoaded |= DoLoadReferences(conn, r) > 0;
                    }
                }

                foreach (var cls in Classes.Values)
                {
                    if (_loadingStopped) return;
                    if (!cls.LoadMissingInstances && !_loadAllMissing) continue;
                    /// load missing identity entities
                    anyLoaded |= LoadMissing(conn, cls) > 0;
                }

                if (!anyLoaded) break;
            }
        }

        public void Prepare(DbConnection conn)
        {
            if (_prepared) throw new Exception("DBSH-00124 DataSet is already prepared");

            LoadMarkedData(conn);

            _prepared = true;

            foreach (var cls in Classes.Values)
            {
                if (!cls.LookupDefined) continue;
                // load lookup fields
                ProcessLookupValues(conn, cls);
            }

            foreach (var cls in Classes.Values)
            {
                if (cls.IdentityColumn == null) continue;
                if (cls.AllInstances.Count == 0) continue;
                var refs = GetAllReferences(cls);
                foreach (int refid in refs)
                {
                    if (cls.InstancesByIdentity.ContainsKey(refid))
                    {
                        cls.InstancesByIdentity[refid].IsReferenced = true;
                    }
                }
            }

            ReportPrepareInformation();
        }

        private void ProcessLookupValues(DbConnection conn, DataSetClass cls)
        {
            if (String.IsNullOrEmpty(cls.SimplePkCol))
            {
                throw new Exception(String.Format("Lookup column for table {0} is not defined", cls));
            }
            var refValues = GetAllReferences(cls);
            if (refValues.Count == 0) return;

            foreach(var row in cls.AllInstances)
            {
                int value = row.SimpleKeyValue;
                if (!refValues.Contains(value)) continue;
                string[] values = cls.LookupFieldIndexes.Select(x => x >= 0 ? row.Values[x].SafeToString() : null).ToArray();
                cls.LookupValues[value] = values;
            }
        }

        private void ReportPrepareInformation()
        {
            foreach (var cls in Classes.Values)
            {
                cls.ReportPrepareInformation();
            }
        }

        private int DoLoadReferences(DbConnection conn, DataSetReference reference)
        {
            if (reference.ReferencedClass.AllInstances.Count == 0) return 0;
            var sb = new StringBuilder();
            sb.AppendFormat("select * from [{0}] where [{1}] in (", reference.BaseClass.TableName, reference.BindingColumn);
            bool was = false;
            foreach (var inst in reference.ReferencedClass.AllInstances)
            {
                if (was) sb.Append(",");
                sb.Append(inst.IdentityValue);
                was = true;
            }
            sb.Append(")");

            //if (reference.BaseClass.AllInstaces.Count > 0)
            //{
            //    was = false;
            //    sb.AppendFormat(" and [{0}] not in (", reference.BaseClass.IdentityColumn);
            //    foreach (var inst in reference.BaseClass.AllInstaces)
            //    {
            //        if (was) sb.Append(",");
            //        sb.Append(inst.IdentityValue);
            //        was = true;
            //    }
            //    sb.Append(")");
            //}

            List<DataSetInstance> loaded;
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.CommandTimeout = 3600;
                using (ICdlReader reader = _dda.AdaptReader(cmd.ExecuteReader()))
                {
                    loaded = DoLoadRows(reader, reference.BaseClass.TableName);
                }
            }
            return loaded.Count;
        }

        private int LoadMissing(DbConnection conn, DataSetClass cls)
        {
            var refValues = cls.GetMissingKeys();
            if (refValues.Count == 0) return 0;
            var sb = new StringBuilder();
            sb.AppendFormat("select * from [{0}] where [{1}] in (", cls.TableName, cls.SimplePkCol);
            bool was = false;
            foreach (int id in refValues)
            {
                if (was) sb.Append(",");
                sb.Append(id);
                was = true;
            }
            sb.Append(")");
            List<DataSetInstance> loaded;

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.CommandTimeout = 3600;
                using (ICdlReader reader = _dda.AdaptReader(cmd.ExecuteReader()))
                {
                    loaded = DoLoadRows(reader, cls.TableName);
                }
            }
            //if (AddedMissingInstances != null)
            //{
            //    foreach (var ent in loaded)
            //    {
            //        var ev = new AddedMissingInstancesEventArgs
            //        {
            //            Class = cls,
            //            Instance = ent,
            //            Connection = conn,
            //        };
            //        AddedMissingInstances(this, ev);
            //    }
            //}
            return loaded.Count;
        }


        public void WriteSql(TextWriter tw)
        {
            CheckPrepared();

            var sdw = new SqlDumpWriter(tw);

            sdw.Write("create table #memory (id int, value int);\n");
            sdw.WriteBlockProlog("declare @reg0 int;\n");

            // 1. determine order of classes, as partial order using relation "contains mandatory relation"
            var orderedClasses = GetOrderedClasses();

            // define lookups
            foreach (var cls in orderedClasses)
            {
                if (!cls.LookupDefined) continue;
                WriteLookup(sdw, cls);
            }

            // write inserts
            foreach (var cls in orderedClasses)
            {
                if (cls.LookupDefined) continue;
                WriteClass(sdw, cls);
            }

            // write updates (non mandatory references)
            foreach (var cls in orderedClasses)
            {
                WriteClassUpdates(sdw, cls);
            }

            tw.Write("drop table #memory;\n");

            ReportWarnings();
        }

        private void WriteLookup(SqlDumpWriter sdw, DataSetClass cls)
        {
            foreach (var tuple in cls.LookupValues)
            {
                var sb = new StringBuilder();
                sb.Append("(");
                sb.AppendFormat("select top(1) tmain.[{0}] from [{1}] tmain ", cls.SimplePkCol, cls.TableName);
                var exprs = new List<string>();
                var rewr = new SqlRewriter(cls.TableName, this);
                for (int i = 0; i < cls.LookupFields.Length; i++) exprs.Add(rewr.Rewrite(cls.LookupFields[i]));
                rewr.WriteJoins(sb);
                sb.Append(" where ");
                bool was = false;
                for (int i = 0; i < exprs.Count; i++)
                {
                    if (was) sb.Append(" and ");
                    sb.AppendFormat("{0}=N'{1}'", exprs[i], tuple.Value[i]);
                    was = true;
                }
                sb.Append(")");
                cls.LookupVariables[tuple.Key] = AssignVariable(sdw, sb.ToString());
            }
        }

        private void ReportWarnings()
        {
            foreach (var cls in Classes.Values)
            {
                cls.ReportWarnings();
            }
        }

        private void WriteClass(SqlDumpWriter sdw, DataSetClass cls)
        {
            foreach (var inst in cls.AllInstances)
            {
                WriteInstance(sdw, inst);
            }
        }

        private void WriteClassUpdates(SqlDumpWriter sdw, DataSetClass cls)
        {
            foreach (var inst in cls.AllInstances)
            {
                WriteInstanceUpdates(sdw, inst);
            }
        }

        private void WriteInstanceUpdates(SqlDumpWriter sdw, DataSetInstance inst)
        {
            foreach (var r in inst.Class.References)
            {
                if (r.Mandatory) continue;
                int colord = inst.Class.ColumnOrdinals[r.BindingColumn];
                if (inst.Values[colord] == null || inst.Values[colord] == DBNull.Value) continue;
                int? rvar = GetReferenceVariable(inst.Values[colord].ToString(), r.BaseClass, r.ReferencedClass, r.BindingColumn);
                if (rvar == null) continue;
                sdw.Write("update [{0}] set [{1}]=", r.BaseClass.TableName, r.BindingColumn);
                sdw.WriteVar(rvar.Value);
                sdw.Write(" where [{0}]=", r.BaseClass.IdentityColumn);
                sdw.WriteVar(inst.IdVariable.Value);
                sdw.EndCommand();
            }
            //foreach (var fr in inst.Class.FulltextReferences)
            //{
            //    int colord = inst.Class.ColumnOrdinals[fr.BindingColumn];
            //    var re = new Regex(fr.Regex);
            //    string val = inst.Values[colord].ToString();
            //    sdw.SuspendVariables();
            //    val = val.Replace("'", "''");
            //    val = re.Replace(val, new FulltextVariableRefMatchReplacer { fr = fr, sdw = sdw, ctx = this }.Replace);
            //    sdw.Write("update [{0}] set [{1}]=N'{2}' where [{3}]=", fr.BaseClass.TableName, fr.BindingColumn, val, fr.BaseClass.IdentityColumn);
            //    sdw.WriteVar(inst.IdVariable.Value);
            //    sdw.ResumeVariables();
            //    sdw.EndCommand();
            //}
        }


        private void WriteInstance(SqlDumpWriter sdw, DataSetInstance inst)
        {
            sdw.Write("insert into [{0}] (", inst.Class.TableName);
            WriteColumnList(inst.Class, sdw.CurrentCommandBuilder);
            sdw.Write(") values (");
            bool was = false;
            for (int i = 0; i < inst.Class.Columns.Length; i++)
            {
                if (inst.Class.Columns[i] == inst.Class.IdentityColumn) continue;
                if (inst.Class.TargetTable.Columns[i].ComputedExpression != null) continue;
                if (was) sdw.Write(",");
                var r = inst.Class.GetReference(i);
                //var fr = inst.Class.GetFulltextReference(i);
                //if (fr != null)
                //{
                //    sdw.Write(fr.EmptyValueExpression);
                //}
                //else 
                if (r != null && !r.ReferencedClass.KeepKey)
                {
                    if (r.ReferencedClass.LookupDefined)
                    {
                        if (inst.Values[i] == null || inst.Values[i] == DBNull.Value)
                        {
                            sdw.Write("NULL");
                        }
                        else
                        {
                            int refid = Int32.Parse(inst.Values[i].ToString());
                            sdw.WriteVar(r.ReferencedClass.LookupVariables[refid]);
                        }
                    }
                    else
                    {
                        if (r.ReferencedClass.IdentityColumn == null)
                        {
                            int ord = r.BaseClass.ColumnOrdinals[r.BindingColumn];
                            if (r.BaseClass.AllInstances.Select(x => x.Values[ord]).Any(x => x != null))
                            {
                                throw new Exception(String.Format("DBSH-00125 Lookup or target identity must be defined on table {0} because of reference from {1}", r.ReferencedClass.TableName,
                                                                  r.BaseClass.TableName));
                            }
                        }
                        if (r.Mandatory)
                        {
                            if (inst.Values[i] == null || inst.Values[i] == DBNull.Value)
                            {
                                sdw.Write("NULL");
                            }
                            else
                            {
                                int? rvar = GetReferenceVariable(inst.Values[i].ToString(), r.BaseClass, r.ReferencedClass, r.BindingColumn);
                                if (rvar == null)
                                {
                                    if (KeepUndefinedReferences)
                                    {
                                        WriteValue(sdw.CurrentCommandBuilder, inst.Values[i]);
                                    }
                                    else
                                    {
                                        sdw.Write("NULL");
                                    }
                                }
                                else
                                {
                                    sdw.WriteVar(rvar.Value);
                                }
                            }
                        }
                        else
                        {
                            sdw.Write("NULL");
                        }
                    }
                }
                else
                {
                    //object overr;
                    //if (inst.Class.Overrides.TryGetValue(inst.Class.Columns[i], out overr))
                    //{
                    //    if (overr is RawOverrides)
                    //        sdw.CurrentCommandBuilder.Append(((RawOverrides)overr).RawValue);
                    //    else
                    //        WriteValue(sdw.CurrentCommandBuilder, overr);
                    //}
                    //else
                    //{
                    //    WriteValue(sdw.CurrentCommandBuilder, inst.Values[i]);
                    //}
                    WriteValue(sdw.CurrentCommandBuilder, inst.Values[i]);
                }
                was = true;
            }
            sdw.Write(")");
            sdw.EndCommand();
            if (inst.RequiredIdentity)
            {
                inst.IdVariable = AssignVariable(sdw, "SCOPE_IDENTITY()");
            }
        }

        private int AssignVariable(SqlDumpWriter sdw, string initExpr)
        {
            _idVarCounter++;
            sdw.Write("set @reg0={0};", initExpr);
            sdw.Write("insert into #memory (id, value) values ({0}, @reg0)", _idVarCounter);
            sdw.EndCommand();
            return _idVarCounter;
        }

        protected internal void WriteValue(StringBuilder sb, object value)
        {
            if (value is string) sb.AppendFormat("N'{0}'", value.ToString().Replace("'", "''"));
            else if (value is DateTime) sb.AppendFormat("'{0}'", ((DateTime) value).ToString("s"));
            else if (value is decimal) sb.AppendFormat("'{0}'", ((decimal) value).ToString(CultureInfo.InvariantCulture));
            else if (value is float) sb.AppendFormat("'{0}'", ((float) value).ToString(CultureInfo.InvariantCulture));
            else if (value is double) sb.AppendFormat("'{0}'", ((double) value).ToString(CultureInfo.InvariantCulture));
            else if (value == null || value == DBNull.Value) sb.Append("NULL");
            else if (value is bool) sb.Append((bool) value ? "1" : "0");
            else if (value is byte[])
            {
                sb.Append("0x");
                StringTool.EncodeHex((byte[]) value, sb);
            }
            else if (value is decimal) sb.AppendFormat(String.Format(CultureInfo.InvariantCulture, "'{0}'", value));
            else sb.AppendFormat("{0}", value);
        }

        internal void WriteColumnList(DataSetClass cls, StringBuilder sb)
        {
            bool was = false;
            for (int i = 0; i < cls.Columns.Length; i++)
            {
                if (cls.Columns[i] == cls.IdentityColumn) continue;
                if (cls.TargetTable.Columns[i].ComputedExpression != null) continue;
                if (was) sb.Append(",");
                sb.AppendFormat("[{0}]", cls.Columns[i]);
                was = true;
            }
        }

        public int? GetReferenceVariable(string srefid, DataSetClass baseClass, DataSetClass referencedClass, string bindingColumn)
        {
            var refobj = GetReferenceInstance(srefid, baseClass, referencedClass, bindingColumn);
            if (refobj != null) return refobj.IdVariable;
            return null;
        }

        public DataSetInstance GetReferenceInstance(string srefid, DataSetClass baseClass, DataSetClass referencedClass, string bindingColumn)
        {
            int refid = Int32.Parse(srefid);
            if (!referencedClass.InstancesByIdentity.ContainsKey(refid))
            {
                referencedClass.ReportUndefinedReference(baseClass.TableName, bindingColumn, refid);
                //if (UndefinedReference != null)
                //{
                //    var ev = new UndefinedReferenceEventArgs();
                //    ev.BaseClass = baseClass;
                //    ev.ReferencedClass = referencedClass;
                //    ev.ReferencedValue = srefid;
                //    ev.BindingColumn = bindingColumn;
                //    UndefinedReference(this, ev);
                //    if (ev.NewReference != null) return ev.NewReference;
                //}
                return null;
            }
            var refobj = referencedClass.GetInstanceByIdentity(refid);
            return refobj;
        }

        public void AddRows(string table, string condition)
        {
            CheckUnprepared("AddRows");
            var cls = GetClass(table);
            cls.AddRowsRequests.Add(condition);
        }

        public void AddRowsByPk(string table, params string[] pks)
        {
            var cls = GetClass(table);
            foreach(string pk in pks)
            {
                cls.RequiredPks.Add(pk);
            }
        }

        private void DoAddRows(DbConnection conn, string table, string condition)
        {
            using (var cmd = conn.CreateCommand())
            {
                var sb = new StringBuilder();

                sb.Append("SELECT ");
                var cls = GetClass(table);
                sb.Append(cls.Columns.Select(x => "tmain.[" + x + "]").CreateDelimitedText(", "));
                sb.Append(" FROM [" + table + "] tmain");

                if (!String.IsNullOrEmpty(condition))
                {
                    var rewr = new SqlRewriter(table, this);
                    string outcond = rewr.Rewrite(condition);
                    rewr.WriteJoins(sb);
                    sb.Append(" WHERE " + outcond);
                }
                cmd.CommandText = sb.ToString();

                try
                {
                    using (ICdlReader reader = _dda.AdaptReader(cmd.ExecuteReader()))
                    {
                        DoLoadRows(reader, table);
                    }
                }
                catch (Exception err)
                {
                    throw new Exception(String.Format("Error loading, table={0}, condition={1}, error={2}", table, condition, err.Message));
                }
            }
        }

        public void LoadMissing(string table)
        {
            CheckUnprepared("LoadMissing");
            var cls = GetClass(table);
            cls.LoadMissingInstances = true;
        }

        public void KeepKey(string table)
        {
            CheckUnprepared("KeepKey");
            var cls = GetClass(table);
            cls.KeepKey = true;
        }

        public void DefineLookup(string table, string[] lookupColumns)
        {
            CheckUnprepared("Lookup");
            var cls = GetClass(table);
            cls.LookupFields = lookupColumns;
            cls.LookupFieldIndexes = lookupColumns.Select(x => cls.ColumnOrdinals.Get(x, -1)).ToArray();
        }

        public void ImportIntoDatabase(DbConnection conn)
        {
            var sw = new StringWriter();
            WriteSql(sw);

            using (var tran = conn.BeginTransaction())
            {
                foreach (var item in GoSplitter.GoSplit(sw.ToString()))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = item.Data;
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                    }
                }
                tran.Commit();
            }
        }

        public void StopLoading()
        {
            _loadingStopped = true;
        }

        public void LoadAllMissing()
        {
            _loadAllMissing = true;
        }
    }
}
