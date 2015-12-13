using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

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
        public string[] LookupFields;
        public int[] LookupFieldIndexes;

        public string[] ConditionalInsertFields;
        public int[] ConditionalInsertFieldIndexes;

        public string SimplePkCol;
        public int SimplePkColIndex = -1;

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
        public Dictionary<string, DataSetInstance> InstancesBySimpleKey = new Dictionary<string, DataSetInstance>();
        public Dictionary<string, DataSetInstance> InstancesByComplexPk = new Dictionary<string, DataSetInstance>();
        public Dictionary<string, FormulaDefinition> ChangedColumns = new Dictionary<string, FormulaDefinition>();

        // dict old lookup value -> lookup mapping tuple
        public Dictionary<string, string[]> LookupValues = new Dictionary<string, string[]>();

        // dict old lookup value -> lookup variable (for WriteSql)
        public Dictionary<string, int> LookupVariables = new Dictionary<string, int>();

        public Dictionary<string, int> ColumnOrdinals = new Dictionary<string, int>();
        public Dictionary<string, UndefinedReferenceReport> _undefinedReferences = new Dictionary<string, UndefinedReferenceReport>();
        public List<string> AddRowsRequests = new List<string>();
        public HashSet<string> RequiredPks = new HashSet<string>();

        public DataSetClass(DataSetModel model, TableInfo targetTable)
        {
            _targetTable = targetTable;
            _model = model;
        }

        public ICdlReader CreateReader()
        {
            return new DataSetClassReader(this);
        }

        public void InitializeClass()
        {
            foreach (var fk in _targetTable.ForeignKeys)
            {
                if (fk.Columns.Count > 1) continue;
                if (_targetTable != null && fk.RefTableFullName == _targetTable.FullName) continue;

                var target = _model.GetClass(fk.RefTableFullName);
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
            Columns = _targetTable.Columns.Select(c => c.Name).ToArray();

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
            if (_targetTable.PrimaryKey != null && _targetTable.PrimaryKey.Columns.Count == 1)
            {
                SimplePkCol = _targetTable.PrimaryKey.Columns[0].Name;
                SimplePkColIndex = Array.IndexOf(Columns, SimplePkCol);
            }
        }

        public NameWithSchema TableName
        {
            get { return _targetTable.FullName; }
        }

        public TableInfo Structure
        {
            get { return _targetTable; }
        }

        public bool LookupDefined
        {
            get { return LookupFields != null && SimplePkCol != null; }
        }

        public DataSetInstance AddRecord(object[] values)
        {
            var ent = new DataSetInstance(this, values);

            if (SimplePkColIndex >= 0)
            {
                if (InstancesBySimpleKey.ContainsKey(ent.SimpleKeyValue)) return null;
                InstancesBySimpleKey[ent.SimpleKeyValue] = ent;
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

        public DataSetInstance GetInstanceByIdentity(string id)
        {
            DataSetInstance res;
            if (InstancesBySimpleKey.TryGetValue(id, out res)) return res;
            return null;
        }

        public DataSetReference FindReference(string column, NameWithSchema reftable)
        {
            DataSetReference result = null;
            foreach (var r in References)
            {
                if (!String.IsNullOrEmpty(column) && column != r.BindingColumn) continue;
                if (reftable != null && reftable != r.ReferencedClass.TableName) continue;
                if (result != null) throw new Exception(String.Format("DBSH-00119 Reference is not unique, Table={0}, Column={1}, RefTable={2}", TableName, column, reftable));
                result = r;
            }
            return result;
        }

        public void ReportUndefinedReference(NameWithSchema tableName, string bindingColumn, string refid)
        {
            var key = tableName + "||" + bindingColumn;
            if (!_undefinedReferences.ContainsKey(key))
                _undefinedReferences[key] = new UndefinedReferenceReport
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
                string message = String.Format("DBSH-00135 Undefined reference {0}.{1}=>{2}, used {3} times, {4} different keys.", item.Table, item.Column, TableName, item.RefCount,
                                               item.KeyValues.Count);
                if (!_model.KeepUndefinedReferences) message += String.Format(" Use <ds:KeepKey Table='{0}' /> to keep original values.", TableName);
                _model.Warning(message);
            }
        }

        public void ReportPrepareInformation()
        {
            if (AllInstances.Count == 0) return;
            _model.Info("DBSH-00136 Table {0}: loaded {1} rows", TableName, AllInstances.Count);
        }

        public DataSetModel Model
        {
            get { return _model; }
        }

        public TableInfo TargetTable
        {
            get { return _targetTable; }
        }

        public void RemoveAllRows()
        {
            AllInstances.Clear();
            InstancesByComplexPk.Clear();
            InstancesBySimpleKey.Clear();
        }

        public HashSet<string> GetMissingKeys()
        {
            var refValues = _model.GetAllReferences(this);
            foreach (string id in InstancesBySimpleKey.Keys) refValues.Remove(id);
            return refValues;
        }
    }

    public class DataSetClassReader : ArrayDataRecord, ICdlReader
    {
        private DataSetClass _cls;
        private int _rowIndex = -1;

        public DataSetClassReader(DataSetClass cls)
            : base(cls.TargetTable)
        {
            _cls = cls;
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        public event Action Disposing;

        public bool Read()
        {
            _rowIndex++;
            if (_rowIndex < _cls.AllInstances.Count)
            {
                for (int i = 0; i < _values.Length; i++)
                {
                    _values[i] = _cls.AllInstances[_rowIndex].Values[i];
                }
                return true;
            }
            return false;
        }

        public bool NextResult()
        {
            return false;
        }
    }
}
