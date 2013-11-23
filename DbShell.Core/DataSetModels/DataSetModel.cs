using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core.DataSetModels
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
            return cls;
        }

        private List<DataSetInstance> DoLoadRows(ICdlReader reader, string targetTable)
        {
            var loaded = new List<DataSetInstance>();
            var ts = reader.Structure;
            var cls = GetClass(targetTable);

            int[] map = new int[cls.Structure.ColumnCount];

            for (int i = 0; i < cls.Structure.ColumnCount; i++)
            {
                map[i] = ts.Columns.IndexOfIf(
                    c => System.String.Compare(c.Name, cls.Structure.Columns[i].Name, System.StringComparison.OrdinalIgnoreCase) == 0);
            }

            while (reader.Read())
            {
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

        public void LoadFromReader(ITabularDataSource source, string targetTable)
        {
            using (var reader = source.CreateReader())
            {
                DoLoadRows(reader, targetTable);
            }
        }

        public void LoadFile(string file, string targetTable)
        {
            CheckUnprepared("LoadFile");
            var cdlFile = new CdlFile { Name = file };
            ITabularDataSource source = cdlFile;
            LoadFromReader(source, targetTable);
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

        public void LoadReference(string table, string column, string reftable)
        {
            CheckUnprepared("LoadReference");
            _loadRefDefs.Add(
                new LoadReferencesDefinition
                    {
                        Column = column,
                        RefTable = reftable,
                        Table = table
                    });
        }

        public void Prepare(DbConnection conn)
        {
            if (_prepared) throw new Exception("DBSH-00124 DataSet is already prepared");
            _prepared = true;

            foreach (var loadRef in _loadRefDefs)
            {
                var x = GetClass(loadRef.Table);
                var r = x.FindReference(loadRef.Column, loadRef.RefTable);
                if (r == null)
                {
                    throw new Exception(String.Format("Undefined reference from {0}.{1}=>{2}", loadRef.Table, loadRef.Column, loadRef.RefTable));
                }
                r.Load = true;
            }

            int maxSteps = 5;
            for (int step = 0; step < maxSteps; step++)
            {
                bool anyLoaded = false;
                foreach (var cls in Classes.Values)
                {
                    foreach (var r in cls.References)
                    {
                        if (!r.Load) continue;
                        anyLoaded |= DoLoadReferences(conn, r) > 0;
                    }
                }

                foreach (var cls in Classes.Values)
                {
                    if (!cls.LoadMissingInstances) continue;
                    /// load missing identity entities
                    anyLoaded |= LoadMissing(conn, cls) > 0;
                }

                if (!anyLoaded) break;
            }
            //foreach (var cls in m_classes.Values)
            //{
            //    if (cls.LookupFields == null) continue;
            //    /// load lookup fields
            //    LoadLookup(conn, cls);
            //}

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

        private void ReportPrepareInformation()
        {
            foreach(var cls in Classes.Values)
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
            var refValues = GetAllReferences(cls);
            foreach (int id in cls.InstancesByIdentity.Keys) refValues.Remove(id);
            if (refValues.Count == 0) return 0;
            var sb = new StringBuilder();
            sb.AppendFormat("select * from [{0}] where [{1}] in (", cls.TableName, cls.IdentityColumn);
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

            //// define lookups
            //foreach (var cls in orderedClasses)
            //{
            //    if (cls.LookupKeyColumn == null) continue;
            //    WriteLookup(sdw, cls);
            //}

            // write inserts
            foreach (var cls in orderedClasses)
            {
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

        private void ReportWarnings()
        {
            foreach(var cls in Classes.Values)
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
                    //if (r.ReferencedClass.LookupKeyColumn != null)
                    //{
                    //    if (inst.Values[i] == null || inst.Values[i] == DBNull.Value)
                    //    {
                    //        sdw.Write("NULL");
                    //    }
                    //    else
                    //    {
                    //        int refid = Int32.Parse(inst.Values[i].ToString());
                    //        sdw.WriteVar(r.ReferencedClass.LookupVariables[refid]);
                    //    }
                    //}
                    //else
                    //{
                    if (r.ReferencedClass.IdentityColumn == null)
                    {
                        throw new Exception("DBSH-00125 Lookup or target identity must be defined");
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
                            if (rvar == null) sdw.Write("NULL");
                            else sdw.WriteVar(rvar.Value);
                        }
                    }
                    else
                    {
                        sdw.Write("NULL");
                    }
                    //}
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
            else if (value is DateTime) sb.AppendFormat("'{0}'", ((DateTime)value).ToString("s"));
            else if (value is decimal) sb.AppendFormat("'{0}'", ((decimal)value).ToString(CultureInfo.InvariantCulture));
            else if (value is float) sb.AppendFormat("'{0}'", ((float)value).ToString(CultureInfo.InvariantCulture));
            else if (value is double) sb.AppendFormat("'{0}'", ((double)value).ToString(CultureInfo.InvariantCulture));
            else if (value == null || value == DBNull.Value) sb.Append("NULL");
            else if (value is bool) sb.Append((bool)value ? "1" : "0");
            else if (value is byte[])
            {
                sb.Append("0x");
                StringTool.EncodeHex((byte[])value, sb);
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

        public void AddRows(DbConnection conn, string table, string condition)
        {
            CheckUnprepared("AddRows");
            using (var cmd = conn.CreateCommand())
            {
                var sb = new StringBuilder();
                sb.Append("SELECT tmain.* FROM [" + table + "] tmain");

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
    }
}
