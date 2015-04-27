using DbShell.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Driver.SqlServer.Test
{
    [TestClass]
    public class AnalyseTest : DatabaseTestBase
    {
        [TestMethod]
        public void OneTable()
        {
            InitDatabase();

            string sql = LoadEmbeddedResource("OneTable.sql");
            using (var conn = OpenConnection(true))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                var factory = new SqlServerDatabaseFactory();
                var analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.FullAnalysis();
                var result = analyser.Structure;
                Assert.AreEqual(1, result.Tables.Count);
                var table = result.Tables[0];
                Assert.AreEqual(2, table.Columns.Count);
                Assert.AreEqual("ID", table.Columns[0].Name);
                Assert.AreEqual("Name", table.Columns[1].Name);
                Assert.AreEqual(true, table.Columns[0].AutoIncrement);
                Assert.IsNotNull(table.PrimaryKey);
            }
        }

        [TestMethod]
        public void ForeignKeys()
        {
            InitDatabase();

            string sql = LoadEmbeddedResource("ForeignKeys.sql");
            using (var conn = OpenConnection(true))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                var factory = new SqlServerDatabaseFactory();
                var analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.FullAnalysis();
                var result = analyser.Structure;

                Assert.AreEqual(2, result.Tables.Count);
                var table = result.Tables.Find(t => t.Name == "Test2");
                Assert.AreEqual(1, table.ForeignKeys.Count);
                var fk = table.ForeignKeys[0];
                Assert.AreEqual("ID_TEST1", fk.RefColumns[0].RefColumn.Name);
                Assert.AreEqual("ID_TEST1", fk.Columns[0].RefColumn.Name);
                Assert.AreEqual("Test1", fk.RefTable.Name);
            }
        }
    }
}
