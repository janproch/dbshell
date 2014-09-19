using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core.RazorModels
{
    public class QueryModel : IEnumerable
    {
        private Query _query;
        private IShellContext _context;

        public QueryModel(Query query, IShellContext context)
        {
            _query = query;
            _context = context;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IListProvider)_query).GetList(_context).GetEnumerator();
        }
    }
}
