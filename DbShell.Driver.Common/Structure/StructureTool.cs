using System.Linq;

namespace DbShell.Driver.Common.Structure
{
    public static class StructureTool
    {
        public static void FixPrimaryKeys(this DatabaseInfo db)
        {
            foreach (var table in db.Tables) table.FixPrimaryKey();
        }

        public static void FixPrimaryKey(this TableInfo table)
        {
            table.PrimaryKey = null;
            if (table.Columns.Any(c => c.PrimaryKey))
            {
                var pk = new PrimaryKeyInfo(table);
                pk.Columns.AddRange(from c in table.Columns where c.PrimaryKey select new ColumnReference { RefColumn = c });
                table.PrimaryKey = pk;
            }
        }
    }
}
