using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerDialect : DialectBase
    {
        public override char QuoteIdentBegin
        {
            get { return '['; }
        }

        public override char QuoteIdentEnd
        {
            get { return ']'; }
        }

        public override char StringEscapeChar
        {
            get { return '\''; }
        }

        public override SqlDumperCaps DumperCaps
        {
            get
            {
                return new SqlDumperCaps
                {
                    AllFlags = false,

                    CreateTable = true,
                    DropTable = true,
                    //AlterTable = true,
                    RenameTable = true,
                    RecreateTable = true,
                    ChangeTableSchema = true,

                    ChangeColumnType = true,
                    RenameColumn = true,
                    AddColumn = true,
                    DropColumn = true,
                    ChangeColumn = true,
                    ChangeColumnDefaultValue = true,

                    RenameConstraint = true,
                    AddConstraint = true,
                    DropConstraint = true,
                    RenameIndex = true,
                    AddIndex = true,
                    DropIndex = true,

                    CreateDatabase = true,
                    DropDatabase = true,
                    RenameDatabase = true,

                    //SpecificCaps = new ObjectOperationCaps { AllFlags = true, Change = false },
                    DepCaps = new AlterDependencyCaps { AllFlags = true },
                };
            }
        }
    }
}
