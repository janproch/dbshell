using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.EngineProviders.Test;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DbShell.Test.DbEngineTests
{
    public class AnalyserTests : DatabaseTestBase
    {
        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void AnalyserTest(string engine)
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
    }
}

