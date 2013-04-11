using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerSqlDumper : SqlDumper
    {
        public SqlServerSqlDumper(ISqlOutputStream stream, IDatabaseFactory factory, SqlFormatProperties props)
            : base(stream, factory, props)
        {
        }

        public override void AllowIdentityInsert(NameWithSchema table, bool allow)
        {
            Put("^set ^identity_insert %f %k;&n", table, allow ? "on" : "off");
        }

        private void RenameObject(NamedObjectInfo obj, string newname)
        {
            PutCmd("execute sp_rename '%f', '%s', 'OBJECT'", obj.FullName, newname);
        }

        private void ChangeObjectSchema(NamedObjectInfo obj, string newschema)
        {
            PutCmd("execute sp_changeobjectowner '%f', '%s'", obj.FullName, newschema);
        }

        public override void RenameView(ViewInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeViewSchema(ViewInfo obj, string newschema)
        {
            ChangeObjectSchema(obj, newschema);
        }

        public override void RenameFunction(FunctionInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeFunctionSchema(FunctionInfo obj, string newschema)
        {
            ChangeObjectSchema(obj, newschema);
        }

        public override void RenameStoredProcedure(StoredProcedureInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeStoredProcedureSchema(StoredProcedureInfo obj, string newschema)
        {
            ChangeObjectSchema(obj, newschema);
        }
    }
}
