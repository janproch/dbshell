using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using System.Data.SQLite;
using DbShell.LocalDb.LocalDbModels;
using DbShell.Driver.Common.Utility;

namespace DbShell.LocalDb
{
    public class TransformData : LocalDbItemBase
    {
        [XamlProperty]
        public string Table { get; set; }

        [XamlProperty]
        public string Column { get; set; }

        [XamlProperty]
        public string Program { get; set; }

        [XamlProperty]
        public string Arguments { get; set; }

        protected override void DoRun(IShellContext context)
        {
            using (var conn = OpenConnection(context))
            {
                conn.BindFunction(
                     (SQLiteFunctionAttribute)typeof(SqliteFunctionTransform).GetCustomAttributes(typeof(SQLiteFunctionAttribute), false).First(),
                     new SqliteFunctionTransform(this)
                     );

                conn.ExecuteNonQuery(GenerateSql(dmp =>
                {
                    dmp.PutCmd("^update %i ^set %i = fn_CalculateSomething(%i)", Table, Column, Column);
                }));
            }
        }
    }
}
