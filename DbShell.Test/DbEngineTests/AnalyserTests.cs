using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.EngineProviders.Test;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace DbShell.Test.DbEngineTests
{
    public class AnalyserTests : DatabaseTestBase
    {
        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void FullAnalyse(string engine)
        {
            Initialize(engine);

            using (var conn = OpenConnection())
            {
                var factory = DatabaseFactory;
                var analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.FullAnalysis();
                var result = analyser.Structure;
                Assert.Equal(5, result.Tables.Count);

                var album = result.FindTableLike("album");
                Assert.NotNull(album);
                Assert.Equal(3, album.ColumnCount);
                Assert.True(album.Columns[0].CommonType is DbTypeInt);
                Assert.True(album.Columns[1].CommonType is DbTypeString);
                Assert.True(album.Columns[2].CommonType is DbTypeInt);
                Assert.True(album.Columns[0].AutoIncrement);
                Assert.Equal(1, album.ForeignKeys.Count);
                var fk = album.ForeignKeys[0];
                Assert.Equal("artist", fk.RefTableName?.ToLower());
                Assert.Equal(1, fk.Columns.Count);

                var genre = result.FindTableLike("genre");
                Assert.False(genre.Columns[0].AutoIncrement);

                // check autoincrement flag of empty table
                var importedData = result.FindTableLike("importedData");
                Assert.True(importedData.Columns[0].AutoIncrement);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void IncrementalAnalyse(string engine)
        {
            Initialize(engine);
            var dialect = DatabaseFactory.CreateDialect();

            using (var conn = OpenConnection())
            {
                var factory = DatabaseFactory;
                var analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.FullAnalysis();
                var dbInfo = analyser.Structure;

                // new analyser
                analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.Structure = dbInfo;
                analyser.GetModifications();
                var changeSet = analyser.ChangeSet;
                Assert.Equal(0, changeSet.Items.Count);

                Thread.Sleep(TimeSpan.FromSeconds(1.5));
                RunScript($"alter table {dialect.QuoteIdentifier("Genre")} add testflag int null;");
                analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.Structure = dbInfo;
                analyser.GetModifications();
                changeSet = analyser.ChangeSet;
                Assert.Equal(1, changeSet.Items.Count);

                analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.Structure = dbInfo;
                analyser.ChangeSet = changeSet;
                analyser.IncrementalAnalysis();
                var newDbInfo = analyser.Structure;

                var genre = newDbInfo.FindTableLike("genre");
                Assert.Equal(3, genre.ColumnCount);
                Assert.Equal("testflag", genre.Columns[2].Name);

                Thread.Sleep(TimeSpan.FromSeconds(1.5));
                RunScript($"drop table {dialect.QuoteIdentifier("Genre")};");
                analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.Structure = newDbInfo;
                analyser.GetModifications();
                analyser.IncrementalAnalysis();
                var newDbInfo2 = analyser.Structure;
                Assert.Equal(4, newDbInfo2.Tables.Count);
                var genre2 = newDbInfo.FindTableLike("genre");
                Assert.Null(genre2);

                Thread.Sleep(TimeSpan.FromSeconds(1.5));
                RunScript($"create table {dialect.QuoteIdentifier("NewTable1")} (testcol int null);");
                analyser = factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.Structure = newDbInfo;
                analyser.GetModifications();
                analyser.IncrementalAnalysis();
                var newDbInfo3 = analyser.Structure;
                Assert.Equal(5, newDbInfo3.Tables.Count);
                var newTable1 = newDbInfo.FindTableLike("NewTable1");
                Assert.NotNull(newTable1);
                Assert.Equal(1, newTable1.ColumnCount);
            }
        }
    }
}
