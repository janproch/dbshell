using System;
using System.Collections;
using System.Collections.Generic;

namespace DbShell.Driver.Common.Utility
{
    public class ListProxy<T> : IList<T>, IList
    {
        protected List<T> m_obj;

        public ListProxy()
        {
            m_obj = new List<T>();
        }

        protected virtual void OnChanged() { }

        #region IList<T> Members

        public virtual int IndexOf(T item)
        {
            return m_obj.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            m_obj.Insert(index, item);
            OnChanged();
        }

        public virtual void RemoveAt(int index)
        {
            m_obj.RemoveAt(index);
            OnChanged();
        }

        public virtual T this[int index]
        {
            get
            {
                return m_obj[index];
            }
            set
            {
                m_obj[index] = value;
                OnChanged();
            }
        }

        #endregion

        #region ICollection<T> Members

        public virtual void Add(T item)
        {
            m_obj.Add(item);
            OnChanged();
        }

        public virtual void Clear()
        {
            m_obj.Clear();
            OnChanged();
        }

        public virtual bool Contains(T item)
        {
            return m_obj.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            m_obj.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get { return m_obj.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return ((IList<T>)m_obj).IsReadOnly; }
        }

        public virtual bool Remove(T item)
        {
            var res = m_obj.Remove(item);
            OnChanged();
            return res;
        }

        #endregion

        #region IEnumerable<T> Members

        public virtual IEnumerator<T> GetEnumerator()
        {
            return m_obj.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_obj.GetEnumerator();
        }

        #endregion

        #region IList Members

        public int Add(object value)
        {
            Add((T)value);
            return Count - 1;
        }

        public bool Contains(object value)
        {
            return value is T && Contains((T)value);
        }

        public int IndexOf(object value)
        {
            if (!(value is T)) return -1;
            return IndexOf((T)value);
        }

        public void Insert(int index, object value)
        {
            Insert(index, (T)value);
        }

        public bool IsFixedSize
        {
            get
            {
                IList lst = m_obj;
                return lst.IsFixedSize;
            }
        }

        public void Remove(object value)
        {
            Remove((T)value);
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (T)value;
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            IList lst = m_obj;
            lst.CopyTo(array, index);
        }

        public bool IsSynchronized
        {
            get
            {
                IList lst = m_obj;
                return lst.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                IList lst = m_obj;
                return lst.SyncRoot;
            }
        }

        #endregion
    }
}
