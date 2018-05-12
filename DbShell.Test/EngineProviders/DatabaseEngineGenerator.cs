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
            //yield return new[] { "mysql" };
            //yield return new[] { "postgre" };
            yield return new[] { "mssql" };
        }

        public IEnumerator<object[]> GetEnumerator() => Enumerate().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
