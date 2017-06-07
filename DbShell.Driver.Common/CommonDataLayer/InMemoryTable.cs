using System.Collections.Generic;
using System.Xml;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    /// <summary>
    /// read-only in-memory table
    /// because of readonly principle is not neccessary to clone this object
    /// </summary>
    public class InMemoryTable : IInMemoryTable<ArrayDataRecord>
    {
        //List<BufferDataRecord> m_rows = new List<BufferDataRecord>();
        //ReadOnlyCollection<BufferDataRecord> m_roRows;
        InMemoryRows m_rows;
        TableInfo m_structure;

        private void Initialize()
        {
            m_rows = new InMemoryRows();
            //m_roRows = new ReadOnlyCollection<BufferDataRecord>(m_rows);
        }

        //public InMemoryTable(InMemoryTable oldTable, InMemoryTableOperation op)
        //{
        //    Initialize();
        //    m_structure = op.m_table.Clone();
        //    var colindexes = op.ColIndexes;
        //    foreach (var row in oldTable.Rows)
        //    {
        //        m_rows.Add(new ArrayDataRecord(row, colindexes, m_structure));
        //    }
        //}

        public InMemoryTable(TableInfo table)
        {
            Initialize();
            m_structure = table.CloneTable();
        }

        public InMemoryTable(InMemoryTable oldTable, SingleTableDataScript script)
        {
            Initialize();
            m_structure = oldTable.Structure.CloneTable();
            CdlTable bt = new CdlTable(oldTable);
            bt.RunScript(script);
            foreach (ICdlRecord rec in bt.Rows)
            {
                m_rows.Add(new ArrayDataRecord(rec));
            }
        }

#if !NETSTANDARD1_5
        public InMemoryTable(TableInfo table, XmlElement xml)
        {
            Initialize();
            m_structure = table.CloneTable();
            using (XmlNodeReader xr = new XmlNodeReader(xml))
            {
                foreach (var rec in CdlTool.LoadFromXml(m_structure, xr))
                {
                    m_rows.Add(new ArrayDataRecord(rec));
                }
            }
        }
#endif

        private InMemoryTable()
        {
            Initialize();
        }

        public static InMemoryTable FromEnumerable<T>(TableInfo table, IEnumerable<T> rows)
            where T : ICdlRecord
        {
            var res = new InMemoryTable();
            res.m_structure = table.CloneTable();
            foreach (ICdlRecord rec in rows)
            {
                res.m_rows.Add(new ArrayDataRecord(rec));
            }
            return res;
        }

        public InMemoryTable(TableInfo table, ICdlReader reader)
        {
            Initialize();
            m_structure = table.CloneTable();
            while (reader.Read())
            {
                m_rows.Add(new ArrayDataRecord(reader));
            }
        }

        public InMemoryRows Rows { get { return m_rows; } }
        public TableInfo Structure { get { return m_structure; } }
        IRowCollection<ArrayDataRecord> IInMemoryTable<ArrayDataRecord>.Rows { get { return this.Rows; } }

#if !NETSTANDARD1_5
        public void SaveToXml(XmlElement xml)
        {
            using (XmlWriter xw = xml.CreateNavigator().AppendChild())
            {
                CdlTool.SaveToXml(m_structure, Rows, xw);
                xw.Flush();
            }
        }
#endif
    }

    public class InMemoryRows : ListProxy<ArrayDataRecord>, IRowCollection<ArrayDataRecord>
    {
    }

    //public class InMemoryTableOperation
    //{
    //    internal TableInfo m_table;
    //    internal List<int> m_colIndexes;

    //    public InMemoryTableOperation(TableInfo table)
    //    {
    //        m_table = new TableInfo(table);
    //        m_colIndexes = new List<int>(PyList.Range(m_table.Columns.Count));
    //    }
    //    public void DropColumn(string name)
    //    {
    //        int index = m_table._Columns.GetIndex(name);
    //        m_table._Columns.RemoveAt(index);
    //        m_colIndexes.RemoveAt(index);
    //    }
    //    public void CreateColumn(IColumnStructure column)
    //    {
    //        m_table.AddColumn(column, true);
    //        m_colIndexes.Add(-1);
    //    }

    //    public void RenameColumn(string oldName, string newName)
    //    {
    //        m_table.RenameColumn(oldName, newName);
    //    }

    //    public int[] ColIndexes { get { return m_colIndexes.ToArray(); } }
    //}
}

