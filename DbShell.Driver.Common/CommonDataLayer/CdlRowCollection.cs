using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlRowCollection : ListProxy<CdlRow>, IRowCollection<CdlRow>
    {
        CdlTable m_table;

        internal CdlRowCollection(CdlTable table)
        {
            m_table = table;
        }

        public override void Add(CdlRow item)
        {
            if (item.RowState != CdlRowState.Detached) throw new BadCdlRowStateError("DBSH-00068", CdlRowState.Detached, item.RowState);
            base.Add(item);
            item.RowState = CdlRowState.Added;
            m_table.NotifyAddedRow(item);
        }

        public override void Insert(int index, CdlRow item)
        {
            if (item.RowState != CdlRowState.Detached) throw new BadCdlRowStateError("DBSH-00069", CdlRowState.Detached, item.RowState);
            base.Insert(index, item);
            item.RowState = CdlRowState.Added;
            m_table.NotifyAddedRow(item);
        }

        public override bool Remove(CdlRow item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RawRemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public override void RemoveAt(int index)
        {
            var item = this[index];

            if (item.RowState == CdlRowState.Added)
            {
                item.RowState = CdlRowState.Detached;
                base.RemoveAt(index);
            }
            else
            {
                item.RowState = CdlRowState.Deleted;
            }

            m_table.NotifyRemovedRow(item);
        }

        internal void AddInternal(CdlRow row)
        {
            base.Add(row);
        }
    }
}
