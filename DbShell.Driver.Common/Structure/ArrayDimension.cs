using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public sealed class ArrayDimension
    {
        public readonly int LowerBound = 0;
        public readonly int? ArrayLength = null;

        public ArrayDimension() { }
        public ArrayDimension(int? length)
        {
            ArrayLength = length;
        }
        public ArrayDimension(int start, int? length)
        {
            LowerBound = start;
            ArrayLength = length;
        }
        public ArrayDimension(string s)
        {
            string[] ar = s.Split(new char[] { ':' }, 2);
            if (ar.Length == 2)
            {
                LowerBound = Int32.Parse(ar[0]);
                ArrayLength = ParseLength(ar[1]);
            }
            else
            {
                ArrayLength = ParseLength(s);
            }
        }
        private static int? ParseLength(string s)
        {
            if (s == "?") return null;
            return Int32.Parse(s);
        }
        public override string ToString()
        {
            string res = ArrayLength == null ? "?" : ArrayLength.ToString();
            if (LowerBound != 0) return String.Format("{0}:{1}", LowerBound, res);
            return res;
        }
    }

    public sealed class ArrayDimensions
    {
        List<ArrayDimension> m_dims = new List<ArrayDimension>();
        ReadOnlyCollection<ArrayDimension> m_dimsRead;
        public override string ToString()
        {
            return (from d in m_dims select d.ToString()).CreateDelimitedText(",");
        }
        public ArrayDimensions()
        {
            m_dimsRead = new ReadOnlyCollection<ArrayDimension>(m_dims);
        }
        public ArrayDimensions(params ArrayDimension[] dims)
        {
            m_dims.AddRange(dims);
        }
        public ArrayDimensions(string data)
            : this()
        {
            if (data == null) return;
            if (data.Length == 0) return;
            foreach (string s in data.Split(','))
            {
                m_dims.Add(new ArrayDimension(s));
            }
        }
        public bool IsArray { get { return m_dims.Count > 0; } }
        public IList<ArrayDimension> Dims { get { return m_dimsRead; } }
    }
}
