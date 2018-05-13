using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
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

            var result = FullAnalyse();

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

            var pk = album.PrimaryKey;
            Assert.NotNull(pk);
            Assert.Equal(1, pk.Columns.Count);
            Assert.Equal("albumid", pk.Columns[0].RefColumnName.ToLower());

            var genre = result.FindTableLike("genre");
            Assert.False(genre.Columns[0].AutoIncrement);

            // check autoincrement flag of empty table
            var importedData = result.FindTableLike("importedData");
            Assert.True(importedData.Columns[0].AutoIncrement);
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void IncrementalAnalyse(string engine)
        {
            Initialize(engine);
            var dialect = DatabaseFactory.CreateDialect();

            DatabaseInfo dbInfo;
            DatabaseChangeSet changeSet;

            dbInfo = FullAnalyse();
            changeSet = GetModifications(dbInfo);
            Assert.Equal(0, changeSet.Items.Count);

            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            RunScript($"alter table {dialect.QuoteIdentifier("Genre")} add testflag int null;");

            changeSet = GetModifications(dbInfo);
            Assert.Equal(1, changeSet.Items.Count);
            dbInfo = IncrementalAnalysis(dbInfo, changeSet);

            var genre = dbInfo.FindTableLike("genre");
            Assert.Equal(3, genre.ColumnCount);
            Assert.Equal("testflag", genre.Columns[2].Name);

            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            RunScript($"drop table {dialect.QuoteIdentifier("Genre")};");

            dbInfo = GetModificationsAndIncrementalAnalysis(dbInfo);

            Assert.Equal(4, dbInfo.Tables.Count);
            var genre2 = dbInfo.FindTableLike("genre");
            Assert.Null(genre2);

            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            RunScript($"create table {dialect.QuoteIdentifier("NewTable1")} (testcol int null);");
            dbInfo = GetModificationsAndIncrementalAnalysis(dbInfo);
            Assert.Equal(5, dbInfo.Tables.Count);
            var newTable1 = dbInfo.FindTableLike("NewTable1");
            Assert.NotNull(newTable1);
            Assert.Equal(1, newTable1.ColumnCount);
        }
    }
}
