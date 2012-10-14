using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DbShell.Driver.Common.Utility
{
    public static class EnumerableExtension
    {
        //public static IEnumerable<T> MapEach<T>(this IEnumerable<T> list, Func<T, T> map)
        //{
        //    foreach (T item in list) yield return map(item);
        //}

        public static IEnumerable<S> MapEach<T, S>(this IEnumerable<T> list, Func<T, S> map)
        {
            foreach (T item in list) yield return map(item);
        }

        //public static List<T> ToList<T>(this IEnumerable<T> list)
        //{
        //    List<T> res = new List<T>();
        //    foreach (T item in list) res.Add(item);
        //    return res;
        //}

        public static string CreateDelimitedText(this IEnumerable list, string separator)
        {
            StringBuilder sb = new StringBuilder();
            bool was = false;
            foreach (object item in list)
            {
                if (was) sb.Append(separator);
                sb.Append((item ?? "").ToString());
                was = true;
            }
            return sb.ToString();
        }

        // direction : 1=minimum, -1=maximum
        public static T Extrem<T>(this IEnumerable<T> list, int direction)
            where T : IComparable
        {
            IEnumerator<T> en = list.GetEnumerator();
            en.MoveNext();
            T res = en.Current;
            while (en.MoveNext())
            {
                T curval = en.Current;
                if (curval.CompareTo(res) * direction < 0)
                {
                    res = curval;
                }
            }
            return res;
        }

        // direction : 1=minimum, -1=maximum
        public static R Extrem<T, R>(this IEnumerable<T> list, Func<T, R> get, int direction)
            where R : IComparable
        {
            IEnumerator<T> en = list.GetEnumerator();
            en.MoveNext();
            R res = get(en.Current);
            while (en.MoveNext())
            {
                R curval = get(en.Current);
                if (curval.CompareTo(res) * direction < 0)
                {
                    res = curval;
                }
            }
            return res;
        }

        // direction : 1=minimum, -1=maximum
        private static T ExtremKey<T, R>(this IEnumerable<T> list, Func<T, R> key, int direction)
            where R : IComparable
        {
            IEnumerator<T> en = list.GetEnumerator();
            en.MoveNext();
            T res = en.Current;
            R minval = key(res);
            while (en.MoveNext())
            {
                R curval = key(en.Current);
                if (curval.CompareTo(minval) * direction < 0)
                {
                    minval = curval;
                    res = en.Current;
                }
            }
            return res;
        }
        public static T MinKey<T, R>(this IEnumerable<T> list, Func<T, R> key)
            where R : IComparable
        {
            return ExtremKey<T, R>(list, key, 1);
        }
        public static T MaxKey<T, R>(this IEnumerable<T> list, Func<T, R> key)
            where R : IComparable
        {
            return ExtremKey<T, R>(list, key, -1);
        }

        public static List<ElementType> SortedByKey<ElementType, KeyType>(this IEnumerable src, Func<ElementType, KeyType> key)
            where KeyType : IComparable
            where ElementType : class
        {
            List<ElementType> res = src.ToTypedList<ElementType>();
            res.Sort((Comparison<ElementType>)(delegate(ElementType a, ElementType b) { return key(a).CompareTo(key(b)); }));
            return res;
        }

        public static List<ResultType> ToTypedList<ResultType>(this IEnumerable src)
            where ResultType : class
        {
            List<ResultType> res = new List<ResultType>();
            foreach (object x in src) res.Add((ResultType)x);
            return res;
        }

        public static List<ElementType> Sorted<ElementType>(this IEnumerable<ElementType> src)
        {
            var res = new List<ElementType>();
            foreach (var item in src) res.Add(item);
            res.Sort();
            return res;
        }

        public static Dictionary<Key, Value> ToDictionary<Key, Value>(IEnumerable<Value> values, Func<Value, Key> extractKey)
        {
            var res = new Dictionary<Key, Value>();
            foreach (var value in values)
            {
                res[extractKey(value)] = value;
            }
            return res;
        }

        public static int IndexOfIf<Elem>(this IEnumerable<Elem> elems, Func<Elem, bool> test)
        {
            int index = 0;
            foreach (var elem in elems)
            {
                if (test(elem)) return index;
                index++;
            }
            return -1;
        }

        public static bool EqualSequence<Elem>(this IEnumerable<Elem> l1, IEnumerable<Elem> l2)
        {
            return EqualSequence(l1, l2, (o1, o2) => Object.Equals(o1, o2));
        }

        public static bool EqualSequence<Elem1, Elem2>(this IEnumerable<Elem1> l1, IEnumerable<Elem2> l2, Func<Elem1,Elem2,bool> testFunc)
        {
            IEnumerator<Elem1> e1 = l1.GetEnumerator();
            IEnumerator<Elem2> e2 = l2.GetEnumerator();
            while (true)
            {
                bool n1 = e1.MoveNext();
                bool n2 = e2.MoveNext();
                if (n1 != n2) return false;
                if (!n1) return true;
                if (!testFunc(e1.Current, e2.Current)) return false;
            }
        }

        public static int CompareSequence<Elem>(this IEnumerable<Elem> l1, IEnumerable<Elem> l2)
            where Elem : IComparable
        {
            IEnumerator<Elem> e1 = l1.GetEnumerator();
            IEnumerator<Elem> e2 = l2.GetEnumerator();
            while (true)
            {
                bool n1 = e1.MoveNext();
                bool n2 = e2.MoveNext();
                if (n1 != n2)
                {
                    if (n1) return -1;
                    return 1;
                }
                if (!n1) return 0;
                if (e1.Current == null && e2.Current == null) continue;
                if (e1.Current == null) return 1;
                if (e2.Current == null) return -1;
                int res = e1.Current.CompareTo(e2.Current);
                if (res != 0) return res;
            }
            return 0;
        }

        public static bool ExistsEx<T>(this IEnumerable<T> list, Func<T, bool> test)
        {
            foreach (var x in list) if (test(x)) return true;
            return false;
        }

        public static T Last<T>(this IList<T> list)
        {
            return list[list.Count - 1];
        }

        public static int[] GetDimensions(this Array array)
        {
            int[] res = new int[array.Rank];
            for (int i = 0; i < res.Length; i++) res[i] = array.GetLength(i);
            return res;
        }

        public static T FirstWithType<T>(this IEnumerable list)
        {
            foreach (var elem in list)
            {
                if (elem is T) return (T)elem;
            }
            return default(T);
        }
    }
}
