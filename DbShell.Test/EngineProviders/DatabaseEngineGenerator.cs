using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DbShell.EngineProviders.Test
{
    public class DatabaseEngineGenerator : IEnumerable<object[]>
    {
        public IEnumerable<object[]> Enumerate()
        {
            yield return new[] { "sqlite" };
            yield return new[] { "mysql" };
            yield return new[] { "postgres" };
            yield return new[] { "mssql" };
        }

        IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator() => Enumerate().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Enumerate().GetEnumerator();
    }
}
