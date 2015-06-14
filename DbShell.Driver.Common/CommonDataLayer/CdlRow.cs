using System;
using System.Collections.Generic;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlRowEventArgs : EventArgs
    {
        public CdlRow Row;
    }

    public delegate void CdlRowEventHandler(object sender, CdlRowEventArgs e);

    public enum CdlRowState
    {
        Detached, Unchanged, Added, Deleted, Modified
    }

    public class CdlRow : ICdlRecord
    {
        struct FieldRec
        {
            internal object Value;
            internal bool Changed;
        }

        FieldRec[] m_fields;
        CdlTable m_table;
        ICdlRecord m_original;
        int m_curField;
        TableInfo m_structure;

        internal CdlRow(CdlTable table, ICdlRecord original, CdlRowState initialState, TableInfo structure)
        {
            m_table = table;
            m_fields = new FieldRec[m_table.Structure.Columns.Count];
            m_original = original;
            m_structure = structure;
            RowState = initialState;
        }

        public CdlRowState RowState { get; set; }
        public CdlTable Table { get { return m_table; } }

        public string[] GetChangedColumns(bool notNull)
        {
            var res = new List<string>();
            for (int i = 0; i < m_fields.Length; i++)
            {
                if (notNull && m_fields[i].Value == null) continue;
                if (m_fields[i].Changed)
                {
                    res.Add(m_table.Structure.Columns[i].Name);
                }
            }
            return res.ToArray();
        }

        public DmlfColumnRef[] GetChangedColumnRefs()
        {
            var res = new List<DmlfColumnRef>();
            for (int i = 0; i < m_fields.Length; i++)
            {
                if (m_fields[i].Changed)
                {
                    res.Add(m_table.ResultFields[i].Column);
                }
            }
            return res.ToArray();
        }

        public object[] GetValuesByCols(DmlfColumnRef[] cols)
        {
            return this.GetValuesByCols(cols, m_table.ResultFields);
        }

        public object[] this[string[] cols]
        {
            get { return this.GetValuesByCols(cols); }
            set { SetValuesByCols(cols, value); }
        }
        //public Dictionary<string, object> GetChangedColumnValues()
        //{
        //    var res = new Dictionary<string, object>();
        //    for (int i = 0; i < m_fields.Length; i++)
        //    {
        //        if (m_fields[i].Changed)
        //        {
        //            res[m_table.Structure.Columns[i].ColumnName] = m_fields[i].Value;
        //        }
        //    }
        //    return res;
        //}

        public ICdlRecord Original { get { return m_original; } }

        #region ICdlRecord Members

        public void ReadValue(int i)
        {
            m_curField = i;
            if (m_original != null) m_original.ReadValue(i);
        }

        public int FieldCount
        {
            get { return m_fields.Length; }
        }

        public TypeStorage GetDefaultStorage(int i)
        {
            return m_table.Structure.Columns[i].CommonType.DefaultStorage;
        }

        public TableInfo Structure
        {
            get { return m_structure; }
        }

        public bool GetBoolean()
        {
            if (m_fields[m_curField].Changed) return (bool)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetBoolean();
            throw new CdlTableError("DBSH-00016 Cannot convert null to boolean");
        }

        public byte GetByte()
        {
            if (m_fields[m_curField].Changed) return (byte)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetByte();
            throw new CdlTableError("DBSH-00017 Cannot convert null to byte");
        }

        public sbyte GetSByte()
        {
            if (m_fields[m_curField].Changed) return (sbyte)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetSByte();
            throw new CdlTableError("DBSH-00018 Cannot convert null to sbyte");
        }

        public byte[] GetByteArray()
        {
            if (m_fields[m_curField].Changed) return (byte[])m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetByteArray();
            throw new CdlTableError("DBSH-00019 Cannot convert null to byte array");
        }

        public DateTime GetDateTime()
        {
            if (m_fields[m_curField].Changed) return (DateTime)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetDateTime();
            throw new CdlTableError("DBSH-00020 Cannot convert null to datetime");
        }

        public DateTimeEx GetDateTimeEx()
        {
            if (m_fields[m_curField].Changed) return (DateTimeEx)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetDateTimeEx();
            throw new CdlTableError("DBSH-00021 Cannot convert null to datetimeex");
        }

        public DateEx GetDateEx()
        {
            if (m_fields[m_curField].Changed) return (DateEx)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetDateEx();
            throw new CdlTableError("DBSH-00022 Cannot convert null to dateex");
        }

        public TimeEx GetTimeEx()
        {
            if (m_fields[m_curField].Changed) return (TimeEx)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetTimeEx();
            throw new CdlTableError("DBSH-00023 Cannot convert null to timeex");
        }

        public decimal GetDecimal()
        {
            if (m_fields[m_curField].Changed) return (decimal)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetDecimal();
            throw new CdlTableError("DBSH-00024 Cannot convert null to decimal");
        }

        public double GetDouble()
        {
            if (m_fields[m_curField].Changed) return (double)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetDouble();
            throw new CdlTableError("DBSH-00025 Cannot convert null to double");
        }

        public TypeStorage GetFieldType()
        {
            if (m_fields[m_curField].Changed)
            {
                if (m_fields[m_curField].Value == null) return TypeStorage.Null;
                return GetDefaultStorage(m_curField);
            }
            if (m_original != null) return m_original.GetFieldType();
            return TypeStorage.Null;
        }

        public float GetFloat()
        {
            if (m_fields[m_curField].Changed) return (float)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetFloat();
            throw new CdlTableError("DBSH-00026 Cannot convert null to float");
        }

        public Guid GetGuid()
        {
            if (m_fields[m_curField].Changed) return (Guid)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetGuid();
            throw new CdlTableError("DBSH-00027 Cannot convert null to Guid");
        }

        public short GetInt16()
        {
            if (m_fields[m_curField].Changed) return (short)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetInt16();
            throw new CdlTableError("DBSH-00028 Cannot convert null to short");
        }

        public int GetInt32()
        {
            if (m_fields[m_curField].Changed) return (int)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetInt32();
            throw new CdlTableError("DBSH-00029 Cannot convert null to int");
        }

        public long GetInt64()
        {
            if (m_fields[m_curField].Changed) return (long)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetInt64();
            throw new CdlTableError("DBSH-00030 Cannot convert null to long");
        }

        public ushort GetUInt16()
        {
            if (m_fields[m_curField].Changed) return (ushort)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetUInt16();
            throw new CdlTableError("DBSH-00031 Cannot convert null to ushort");
        }

        public uint GetUInt32()
        {
            if (m_fields[m_curField].Changed) return (uint)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetUInt32();
            throw new CdlTableError("DBSH-00032 Cannot convert null to uint");
        }

        public ulong GetUInt64()
        {
            if (m_fields[m_curField].Changed) return (ulong)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetUInt64();
            throw new CdlTableError("DBSH-00033 Cannot convert null to ulong");
        }

        public string GetName(int i)
        {
            return m_table.Structure.Columns[i].Name;
        }

        public int GetOrdinal(string name)
        {
            return m_table.Structure.Columns.GetIndex(name);
        }

        public string GetString()
        {
            if (m_fields[m_curField].Changed) return (string)m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetString();
            return null;
        }

        //public Array GetArray()
        //{
        //    if (m_fields[m_curField].Changed) return (Array)m_fields[m_curField].Value;
        //    if (m_original != null) return m_original.GetArray();
        //    return null;
        //}

        public object GetValue()
        {
            if (m_fields[m_curField].Changed) return m_fields[m_curField].Value;
            if (m_original != null) return m_original.GetValue();
            return null;
        }

        public int GetValues(object[] values)
        {
            int cnt = Math.Min(values.Length, m_fields.Length);
            if (m_original != null) m_original.GetValues(values);
            for (int i = 0; i < cnt; i++)
            {
                if (m_fields[i].Changed) values[i] = m_fields[i].Value;
            }
            return cnt;
        }

        public bool IsDBNull(int i)
        {
            return this[i].IsNullOrDbNull();
        }

        public object this[string name]
        {
            get
            {
                return this[GetOrdinal(name)];
            }
            set
            {
                this[GetOrdinal(name)] = value;
            }
        }

        public object this[int i]
        {
            get
            {
                if (m_fields[i].Changed) return m_fields[i].Value;
                if (m_original != null) return m_original.GetValue(i);
                return null;
            }
            set
            {
                m_fields[i].Value = m_table.CdlConvertor.ConvertValue(GetDefaultStorage(i), value);
                m_fields[i].Changed = true;
                if (RowState == CdlRowState.Unchanged) RowState = CdlRowState.Modified;
            }
        }

        #endregion

        public void SetValue(int colindex, ICdlValueReader reader)
        {
            var holder = new CdlValueHolder();
            m_table.CdlConvertor.ConvertValue(reader, GetDefaultStorage(colindex), holder);
            m_fields[colindex].Value = holder.GetValue();
            m_fields[colindex].Changed = true;
            if (RowState == CdlRowState.Unchanged) RowState = CdlRowState.Modified;
        }

        public bool ContainsText(string pattern)
        {
            pattern = pattern.ToLower();
            for (int i = 0; i < FieldCount; i++)
            {
                string fld = this[i].SafeToString();
                if (fld != null && fld.ToLower().Contains(pattern)) return true;
            }
            return false;
        }

        public bool IsChanged(int index)
        {
            return m_fields[index].Changed;
        }

        public void RevertChanges()
        {
            // cannot revert changes of new rows
            if (RowState == CdlRowState.Added) return;

            for (int i = 0; i < m_fields.Length; i++)
            {
                m_fields[i].Changed = false;
                m_fields[i].Value = null;
            }
            switch (RowState)
            {
                case CdlRowState.Modified:
                    RowState = CdlRowState.Unchanged;
                    break;
                case CdlRowState.Deleted:
                    RowState = CdlRowState.Unchanged;
                    break;
            }
        }

        public object[] GetItemArray()
        {
            object[] res = new object[FieldCount];
            GetValues(res);
            return res;
        }

        public void SetValuesByCols(string[] columns, object[] values)
        {
            for (int i = 0; i < columns.Length; i++) this[columns[i]] = values[i];
        }

        public string GetFormattedValue(int colindex)
        {
            ReadValue(colindex);
            m_table.CdlConvertor.Formatter.ReadFrom(this);
            return m_table.CdlConvertor.Formatter.GetText();
        }
    }
}
