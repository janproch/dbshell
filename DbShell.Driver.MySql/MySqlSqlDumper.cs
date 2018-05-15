using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.MySql
{
    public class MySqlSqlDumper : SqlDumper
    {
        public MySqlSqlDumper(ISqlOutputStream stream, IDatabaseFactory factory, SqlFormatProperties props)
            : base(stream, factory, props)
        {
        }

        //private MySqlDumpWriterConfig Wcfg { get { return m_props.DumpWriterConfig as MySqlDumpWriterConfig; } }

        public override void RenameTable(TableInfo obj, string newName)
        {
            PutCmd("^rename ^table %f ^to %i", obj.FullName, newName);
        }

        //UNSAFE, not supported by MySQL: http://dev.mysql.com/doc/refman/5.1/en/rename-database.html
        //public override void RenameDatabase(string oldname, string newname)
        //{
        //    PutCmd("^rename ^database %i ^to %i", oldname, newname);
        //}

        public override void ChangeColumn(ColumnInfo oldcol, ColumnInfo newcol, IEnumerable<ConstraintInfo> constraints)
        {
            Put("^alter ^table %f ^change ^column %i %i ", oldcol.OwnerTable, oldcol.Name, newcol.Name);
            ColumnDefinition(newcol, true, true, true);
            InlineConstraints(constraints);
            EndCommand();
        }

        public override void RenameColumn(ColumnInfo column, string newcol)
        {
            var newcoldef = column.CloneColumn();
            newcoldef.Name = newcol;
            ChangeColumn(column, newcoldef, new ConstraintInfo[] { });
        }

        //public override void DropSpecificObject(ISpecificObjectStructure obj, DropFlags flags)
        //{
        //    bool testIfExist = (flags & DropFlags.TestIfExist) != 0;
        //    switch (obj.ObjectType)
        //    {
        //        case "view":
        //            PutCmdTest("50010", "^drop ^view%k %f", testIfExist ? " if exists" : "", obj.ObjectName);
        //            break;
        //        case "procedure":
        //            PutCmdTest("50010", "^drop ^procedure%k %f", testIfExist ? " if exists" : "", obj.ObjectName);
        //            break;
        //        case "function":
        //            PutCmdTest("50010", "^drop ^function%k %f", testIfExist ? " if exists" : "", obj.ObjectName);
        //            break;
        //        case "trigger":
        //            PutCmdTest("50017", "^drop ^trigger%k %f", testIfExist ? " if exists" : "", obj.ObjectName);
        //            break;
        //        case "mysql.event":
        //            PutCmdTest("51000", "^drop ^event%k %f", testIfExist ? " if exists" : "", obj.ObjectName);
        //            break;
        //        default:
        //            throw new NotImplementedError("DAE-00145");
        //    }
        //}

        //public override void PutVersionTestBegin(string version)
        //{
        //    if (!m_props.OmitVersionTests) WriteRaw("/*!" + version + " ");
        //}
        //public override void PutVersionTestEnd(string version)
        //{
        //    if (!m_props.OmitVersionTests) WriteRaw("*/");
        //}

        //private void EnumOptions(Action<string, string> func)
        //{
        //    if (Wcfg == null || Wcfg.DumpTableEngine) func("mysql.engine", "ENGINE");
        //    if (Wcfg == null || Wcfg.DumpAutoIncrementValues) func("mysql.auto_increment", "AUTO_INCREMENT");
        //    if (Wcfg == null || Wcfg.DumpTableCollation) func("mysql.collation", "COLLATE");
        //}

        //public override void CreateTableOptions(ITableStructure table)
        //{
        //    EnumOptions((specKey, option) => PutTableOption(table, specKey, option));
        //}

        //public override void AlterTableOptions(ITableStructure table, Dictionary<string, string> alteredOptions)
        //{
        //    EnumOptions((specKey, option) => AlterTableOptions(table, option, alteredOptions.Get(specKey, null)));
        //}

        //private void AlterTableOptions(ITableStructure table, string option, string value)
        //{
        //    if (value != null)
        //    {
        //        PutCmd("^alter ^table %f %k=%s", table.FullName, option, value);
        //    }
        //}

        //private void DelimChangeBegin()
        //{
        //    if (Wcfg != null && Wcfg.DumpDelimMode)
        //    {
        //        m_stream.OverrideCommandDelimiter(";;\n");
        //        WriteRaw("DELIMITER ;;\n");
        //    }
        //}

        //private void DelimChangeEnd()
        //{
        //    if (Wcfg != null && Wcfg.DumpDelimMode)
        //    {
        //        m_stream.OverrideCommandDelimiter(null);
        //        WriteRaw("DELIMITER ;\n");
        //    }
        //}

        //private string RemoveDefiner(string createsql)
        //{
        //    if (FormatProperties.CleanupSpecificObjectCode)
        //    {
        //        var regex = new Regex(@"definer\s*=\s*`[^`]+`\s*@\s*`[^`]+`", RegexOptions.IgnoreCase);
        //        createsql = regex.Replace(createsql, "");
        //    }
        //    return createsql;
        //}

        //public override void CreateSpecificObject(ISpecificObjectStructure obj)
        //{
        //    switch (obj.ObjectType)
        //    {
        //        case "trigger":
        //            DelimChangeBegin();
        //            WriteRawTest("50017", obj.CreateSql);
        //            EndCommand();
        //            DelimChangeEnd();
        //            break;
        //        case "view":
        //            WriteRawTest("50010", RemoveDefiner(obj.CreateSql));
        //            EndCommand();
        //            break;
        //        case "procedure":
        //            DelimChangeBegin();
        //            WriteRawTest("50010", RemoveDefiner(obj.CreateSql));
        //            EndCommand();
        //            DelimChangeEnd();
        //            break;
        //        case "function":
        //            DelimChangeBegin();
        //            WriteRawTest("50010", RemoveDefiner(obj.CreateSql));
        //            EndCommand();
        //            DelimChangeEnd();
        //            break;
        //        case "mysql.event":
        //            DelimChangeBegin();
        //            WriteRawTest("51000", obj.CreateSql);
        //            EndCommand();
        //            DelimChangeEnd();
        //            break;
        //    }
        //}

        //private void PutTableOption(ITableStructure table, string specKey, string option)
        //{
        //    string val = table.SpecificData.Get(specKey);
        //    if (!String.IsNullOrEmpty(val))
        //    {
        //        Put(" %k=%s ", option, val);
        //    }
        //}

        //public override void DropTable(ITableStructure table, DropFlags flags)
        //{
        //    bool testIfExist = (flags & DropFlags.TestIfExist) != 0;
        //    DropTableReferences(table, flags);
        //    PutCmd("^drop ^table%k %f", testIfExist ? " if exists" : "", table.FullName);
        //}

        //protected override void ColumnRef(IColumnReference colref)
        //{
        //    if (colref.SpecificData.ContainsKey("mysql.sub_part"))
        //    {
        //        Put("%i(%s)", colref.ColumnName, colref.SpecificData["mysql.sub_part"]);
        //    }
        //    else
        //    {
        //        base.ColumnRef(colref);
        //    }
        //}

        //private void PutDbOptions(Dictionary<string, string> options)
        //{
        //    if (options == null) return;
        //    if (options.ContainsKey("mysql.collation")) Put(" ^collate %s ", options["mysql.collation"]);
        //    if (options.ContainsKey("mysql.character_set")) Put(" ^character ^set %s ", options["mysql.character_set"]);
        //}

        //public override void CreateDatabase(string dbname, Dictionary<string, string> options)
        //{
        //    Put("^create ^database %i", dbname);
        //    PutDbOptions(options);
        //    EndCommand();
        //}

        //public override void AlterDatabaseOptions(string dbname, Dictionary<string, string> options)
        //{
        //    Put("^alter ^database %i", dbname);
        //    PutDbOptions(options);
        //    EndCommand();
        //}

        public override void EnableConstraints(NameWithSchema table, bool enabled)
        {
            PutCmd("^set FOREIGN_KEY_CHECKS = %s", enabled ? "1" : "0");
        }

        public override void Comment(string value)
        {
            Put("/* %s */", value);
        }

        public override void BeginTransaction()
        {
            PutCmd("^start ^transaction");
        }

        public override void SelectTableIntoNewTable(NameWithSchema sourceName, NameWithSchema targetName)
        {
            PutCmd("^create ^table %f (^select * ^from %f)", targetName, sourceName);
        }
    }
}
