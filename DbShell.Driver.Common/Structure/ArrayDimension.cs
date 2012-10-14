using System;

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
}
