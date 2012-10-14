using System.Collections.Generic;

namespace DbShell.Driver.Common.Utility
{
    public class HashSetEx<T> : IEnumerable<T>
    {
        Dictionary<T, bool> m_data = new Dictionary<T, bool>();
        public HashSetEx() { }
        public HashSetEx(IEnumerable<T> src)
        {
            UnionWith(src);
        }
        public HashSetEx(params T[] src)
        {
            UnionWith(src);
        }
        public void Add(T elem) { m_data[elem] = true; }
        public void Clear() { m_data.Clear(); }
        public bool Contains(T elem) { return m_data.ContainsKey(elem); }
        public void UnionWith(IEnumerable<T> src)
        {
            foreach (var item in src) m_data[item] = true;
        }
        public void Remove(T item)
        {
            m_data.Remove(item);
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return m_data.Keys.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_data.Keys.GetEnumerator();
        }

        #endregion

        public void AddRange(IEnumerable<T> src)
        {
            UnionWith(src);
        }
    }
}
