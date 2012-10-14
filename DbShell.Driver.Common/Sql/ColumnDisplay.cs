using System.Collections.Generic;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Sql
{
    public class ColumnDisplayInfo
    {
        public enum UsageStyle { Value, Hidden, Lookup }

        [XmlElem]
        // used only when Style == Lookup
        public int VisibleColumnIndex { get; set; }
        [XmlElem]
        public UsageStyle Style { get; set; }

        [XmlElem]
        public bool IsPrimaryKey { get; set; }
        [XmlElem]
        public bool IsReadOnly { get; set; }

        public ColumnDisplayInfo()
        {
            Style = UsageStyle.Value;
        }
    }

    //public class ColumnDisplayInfoCollection : List<ColumnDisplayInfo>
    //{
    //    public bool IsMultiTable()
    //    {
    //        DmlfSource lastsrc = null;
    //        foreach (var col in this)
    //        {
    //            if (lastsrc != null && col. was && col.sou .BaseTable != lastsrc) return true;
    //            was = true;
    //            lastsrc = col.BaseTable;
    //        }
    //        return false;
    //    }

    //    public List<DmlfColumnRef> GetPkCols(DmlfSource source, string[] colnames)
    //    {
    //        var res = new List<DmlfColumnRef>();
    //        int index = 0;
    //        foreach (var col in this)
    //        {
    //            if (col.BaseTable == source && col.IsPrimaryKey) res.Add(new DmlfColumnRef { Source = col.BaseTable, ColumnName = colnames[index] });
    //            index++;
    //        }
    //        return res;
    //    }
    //}

    /// <summary>
    /// maps result columns into grid (as value or lookup)
    /// </summary>
    /// <typeparam name="T">additional column info (eg. IColumnStructure)</typeparam>
    public class ColumnDisplay : List<ColumnDisplayColumn>
    {
        public void AddColumn(string name, int index)
        {
            AddColumnTag(name, index, null);
        }

        public void AddColumnTag(string name, int index, object tag)
        {
            Add(new ColumnDisplayColumn
            {
                ValueTag = tag,
                ValueSourceIndex = index,
                ValueRef = DmlfResultField.BuildFromColumn(name)
            });
        }

        public void AddColumn(DmlfResultField field, int index)
        {
            AddColumnTag(field, index, null);
        }

        public void AddColumnTag(DmlfResultField field, int index, object tag)
        {
            switch (field.DisplayInfo.Style)
            {
                case ColumnDisplayInfo.UsageStyle.Value:
                    Add(new ColumnDisplayColumn
                    {
                        ValueRef = field,
                        ValueSourceIndex = index,
                        ValueTag = tag,
                    });
                    break;
                case ColumnDisplayInfo.UsageStyle.Lookup:
                    int vindex = field.DisplayInfo.VisibleColumnIndex;
                    this[vindex].LookupRef = field;
                    this[vindex].LookupSourceIndex = index;
                    this[vindex].LookupTag = tag;
                    break;
            }
        }

        public List<NameWithSchema> GetLinkedTables()
        {
            var res = new List<NameWithSchema>();
            foreach (var col in this)
            {
                var src = col.ValueRef.Source;
                if (src == null || src == DmlfSource.BaseTable || src.TableOrView == null) continue;
                if (!res.Contains(src.TableOrView)) res.Add(src.TableOrView);
            }
            return res;
        }
    }

    public class ColumnDisplayColumn
    {
        public DmlfResultField ValueRef;
        public int ValueSourceIndex;
        public bool ValueIsReadOnly { get { return ValueRef.DisplayInfo.IsReadOnly; } }
        public object ValueTag;

        public DmlfResultField LookupRef;
        public int LookupSourceIndex;
        public object LookupTag;
    }

    public class TColumnDisplay<T> : ColumnDisplay
    {
        public void AddColumn(string name, int index, T tag)
        {
            AddColumnTag(name, index, tag);
        }
        public void AddColumn(DmlfResultField field, int index, T tag)
        {
            AddColumnTag(field, index, tag);
        }
        public T GetValueTag(int index)
        {
            return (T)this[index].ValueTag;
        }
        public T GetLookupTag(int index)
        {
            return (T)this[index].LookupTag;
        }
    }
}
