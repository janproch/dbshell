using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public class GetKeyboardsEventArgs
    {
        public ISqlDialect Dialect;
        public HashSetEx<string> Keywords;
    }

    public static class KeywordsProvider
    {
        public static event Action<GetKeyboardsEventArgs> GetKeywords;

        public static HashSetEx<string> InvokeGetKeywords(ISqlDialect dialect)
        {
            if (GetKeywords == null) return null;
            var args = new GetKeyboardsEventArgs
                {
                    Dialect = dialect,
                };
            GetKeywords(args);
            return args.Keywords;
        }
    }
}
