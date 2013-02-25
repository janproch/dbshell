using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public static class ListExtension
    {
        public static void Exchange(this IList list, int i1, int i2)
        {
            object tmp = list[i1];
            list[i1] = list[i2];
            list[i2] = tmp;
        }


        public static void SortByKey<ElementType, KeyType>(this List<ElementType> lst, Func<ElementType, KeyType> key)
            where KeyType : IComparable
        {
            lst.Sort((Comparison<ElementType>)(delegate(ElementType a, ElementType b) { return key(a).CompareTo(key(b)); }));
        }

        public static void RemoveIf<T>(this IList<T> list, Func<T, bool> testFunc)
        {
            for (int i = 0; i < list.Count; )
            {
                if (testFunc(list[i])) list.RemoveAt(i);
                else i++;
            }
        }

        public static void ReplaceIf<T>(this IList<T> list, Func<T, bool> testFunc, T newvalue)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (testFunc(list[i])) list[i] = newvalue;
            }
        }

        public static int IndexOfEx<T>(this IList<T> list, T item)
        {
            for (int i = 0; i < list.Count; i++) if (Object.Equals(list[i], item)) return i;
            return -1;
        }
    }
}
