using System;
using System.Collections.Generic;

namespace DbShell.Driver.Common.Utility
{
    public static class PyList
    {
        public static int RealIndex(string text, int pyindex)
        {
            if (pyindex < 0) return text.Length + pyindex;
            return pyindex;
        }
        public static string Slice(this string text, int from, int to)
        {
            int rfrom = RealIndex(text, from);
            int rto = RealIndex(text, to);
            return text.Substring(rfrom, rto - rfrom);
        }
        public static int RealIndex(Array array, int pyindex)
        {
            if (pyindex < 0) return array.Length + pyindex;
            return pyindex;
        }
        public static T[] Slice<T>(T[] array, int from, int to)
        {
            int rfrom = RealIndex(array, from);
            int rto = RealIndex(array, to);
            T[] res = new T[rto - rfrom];
            for (int i = 0; i < rto - rfrom; i++) res[i] = array[rfrom + i];
            return res;
        }
        public static T[] SliceFrom<T>(T[] array, int from)
        {
            return Slice(array, from, array.Length);
        }
        public static T[] SliceTo<T>(T[] array, int to)
        {
            return Slice(array, 0, to);
        }
        private static T Extrem<T>(IEnumerable<T> values, bool ismin) where T : IComparable
        {
            int minmul = ismin ? 1 : -1;
            T res = default(T);
            bool was = false;
            foreach (T val in values)
            {
                if (was)
                {
                    if (val.CompareTo(res) * minmul < 0) res = val;
                }
                else
                {
                    res = val;
                }
                was = true;
            }
            return res;
        }

        public static T Minimum<T>(IEnumerable<T> values) where T : IComparable
        {
            return Extrem(values, true);
        }
        public static T Maximum<T>(IEnumerable<T> values) where T : IComparable
        {
            return Extrem(values, false);
        }

        public static IEnumerable<int> Range(int n)
        {
            for (int i = 0; i < n; i++) yield return i;
        }

        public static void Exchange<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
}
