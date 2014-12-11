using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.DataSet.DataSetModels
{
    public class DataSetClass
    {
        private TableInfo _targetTable;
        private DataSetModel _model;

        public string IdentityColumn;
        public int IdentityColumnOrdinal = -1;

        //private string _identityColumn;
        //private int _identityColumnOrdinal = -1;
        public string[] Columns;
        public string[] ComplexPkCols;
        public int[] ComplexPkColIndexes;

        public bool LoadMissingInstances;
        public bool KeepKey;

        //public string IdentityColumn
        //{
        //    get { return KeepKey ? null : _identityColumn; }
        //}
        //public int IdentityColumnOrdinal
        //{
        //    get { return KeepKey ? -1 : _identityColumnOrdinal; }
        //}

        public List<DataSetReference> References = new List<DataSetReference>();
        public List<DataSetInstance> AllInstances = new List<DataSetInstance>();
        public Dictionary<int, DataSetInstance> InstancesByIdentity = new Dictionary<int, DataSetInstance>();
        public Dictionary<string, DataSetInstance> InstancesByComplexPk = new Dictionary<string, DataSetInstance>();

        public Dictionary<string, int> ColumnOrdinals = new Dictionary<string, int>();
        public Dictionary<string, UndefinedReferenceReport> _undefinedReferences = new Dictionary<string, UndefinedReferenceReport>();

        public DataSetClass(DataSetModel model, TableInfo targetTable)
        {
            _targetTable = targetTable;
            _model = model;

            foreach (var fk in _targetTable.ForeignKeys)
            {
                if (fk.Columns.Count > 1) continue;
                if (fk.RefTableFullName == targetTable.FullName) continue;

                var target = _model.GetClass(fk.RefTableName);
                var r = new DataSetReference
                    {
                        BaseClass = this,
                        ReferencedClass = target,
                        BindingColumn = fk.Columns[0].Name,
                        Mandatory = fk.Columns[0].RefColumn.NotNull,
                    };

                References.Add(r);
            }

            var autoInc = _targetTable.FindAutoIncrementColumn();
            if (autoInc != null)
            {
                IdentityColumn = autoInc.Name;
                IdentityColumnOrdinal = _targetTable.Columns.IndexOf(autoInc);
            }
            Columns = _targetTable.Columns.Where(c=>c.ComputedExpression == null).Select(c => c.Name).ToArray();

            for (int i = 0; i < _targetTable.ColumnCount; i++)
            {
                ColumnOrdinals[_targetTable.Columns[i].Name] = i;
            }
            if (_targetTable.PrimaryKey != null && _targetTable.PrimaryKey.Columns.Count > 1)
            {
                ComplexPkCols = _targetTable.PrimaryKey.Columns.Select(c => c.Name).ToArray();
            }
            if (ComplexPkCols != null && Columns != null)
            {
                var idxs = new List<int>();
                foreach (string col in ComplexPkCols)
                {
                    idxs.Add(Array.IndexOf(Columns, col));
                }
                ComplexPkColIndexes = idxs.ToArray();
            }
            else
            {
                ComplexPkColIndexes = null;
            }
        }

        public string TableName
        {
            get { return _targetTable.Name; }
        }

        public TableInfo Structure
        {
            get { return _targetTable; }
        }

        public DataSetInstance AddRecord(object[] values)
        {
            var ent = new DataSetInstance(this, values);

            if (IdentityColumnOrdinal >= 0)
            {
                if (InstancesByIdentity.ContainsKey(ent.IdentityValue)) return null;
                InstancesByIdentity[ent.IdentityValue] = ent;
            }
            if (ComplexPkColIndexes != null)
            {
                var sb = new StringBuilder();
                foreach (int index in ComplexPkColIndexes)
                {
                    sb.Append(ent.Values[index]);
                    sb.Append("###");
                }
                string key = sb.ToString();
                if (InstancesByComplexPk.ContainsKey(key)) return null;
                InstancesByComplexPk[key] = ent;
            }
            AllInstances.Add(ent);

            return ent;
        }

        public DataSetReference GetReference(int i)
        {
            foreach (var r in References)
            {
                if (r.BindingColumn == Columns[i]) return r;
            }
            return null;
        }

        public DataSetInstance GetInstanceByIdentity(int id)
        {
            DataSetInstance res;
            if (InstancesByIdentity.TryGetValue(id, out res)) return res;
            return null;
        }

        public DataSetReference FindReference(string column, string reftable)
        {
            DataSetReference result = null;
            foreach (var r in References)
            {
                if (!String.IsNullOrEmpty(column) && column != r.BindingColumn) continue;
                if (!String.IsNullOrEmpty(reftable) && reftable != r.ReferencedClass.TableName) continue;
                if (result != null) throw new Exception(String.Format("DBSH-00119 Reference is not unique, Table={0}, Column={1}, RefTable={2}", TableName, column, reftable));
                result = r;
            }
            return result;
        }

        public void ReportUndefinedReference(string tableName, string bindingColumn, int refid)
        {
            var key = tableName + "||" + bindingColumn;
            if (!_undefinedReferences.ContainsKey(key)) _undefinedReferences[key] = new UndefinedReferenceReport
                {
                    Column = bindingColumn, 
                    Table = tableName
                };
            _undefinedReferences[key].RefCount++;
            _undefinedReferences[key].KeyValues.Add(refid);
        }

        public void ReportWarnings()
        {
            foreach (var item in _undefinedReferences.Values)
            {
                _model.Warning("DBSH-00135 Undefined reference {0}.{1}=>{2}, used {3} times, {4} different keys. Use <ds:KeepKey Table='{2}' /> to keep original values.",
                               item.Table, item.Column, TableName, item.RefCount, item.KeyValues.Count);
            }
        }

        public void ReportPrepareInformation()
        {
            if (AllInstances.Count == 0) return;
            _model.Info("DBSH-00136 Table {0}: loaded {1} rows", TableName, AllInstances.Count);
        }
    }
}
