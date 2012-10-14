using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
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