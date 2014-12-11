using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public class NullableKeysDictionary<Key, Value> : IEnumerable<KeyValuePair<Key, Value>>
        where Key : class
    {
        private bool _isNullKey = false;
        private Value _nullValue = default(Value);
        private Dictionary<Key, Value> _dict = new Dictionary<Key, Value>();

        public Value this[Key key]
        {
            get
            {
                if (key == null)
                {
                    if (_isNullKey) return _nullValue;
                    throw new Exception("DBSH-00000 Null key not in dictionary");
                }
                else
                {
                    return _dict[key];
                }
            }
            set
            {
                if (key == null)
                {
                    _isNullKey = true;
                    _nullValue = value;
                }
                else
                {
                    _dict[key] = value;
                }
            }
        }

        public bool ContainsKey(Key key)
        {
            if (key == null) return _isNullKey;
            else return _dict.ContainsKey(key);
        }

        public IEnumerable<Key> Keys
        {
            get
            {
                if (_isNullKey) yield return null;
                foreach (Key key in _dict.Keys)
                {
                    yield return key;
                }
            }
        }

        public IEnumerable<Value> Values
        {
            get
            {
                if (_isNullKey) yield return _nullValue;
                foreach (Value value in _dict.Values)
                {
                    yield return value;
                }
            }
        }

        public void Clear()
        {
            _dict.Clear();
        }

        #region IEnumerable<KeyValuePair<Key,Value>> Members

        public IEnumerator<KeyValuePair<Key, Value>> GetEnumerator()
        {
            if (_isNullKey) yield return new KeyValuePair<Key, Value>(null, _nullValue);
            foreach (var item in _dict)
            {
                yield return item;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (_isNullKey) yield return new KeyValuePair<Key, Value>(null, _nullValue);
            foreach (var item in _dict)
            {
                yield return item;
            }
        }

        #endregion

        public bool TryGetValue(Key key, out Value value)
        {
            if (key == null)
            {
                value = _nullValue;
                return _isNullKey;
            }
            return _dict.TryGetValue(key, out value);
        }

        public int Count
        {
            get { return _dict.Count + (_isNullKey ? 1 : 0); }
        }
    }
}
