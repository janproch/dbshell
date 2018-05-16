using DbShell.All;
using DbShell.Core;
using DbShell.Excel.ExcelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DbShell.Test.ExportImportFormats
{
    public class ExcelTests : DatabaseTestBase
    {
        public ExcelTests()
        {
            DbShellUtility.BuildDefaultServiceProvider();
        }

        [Fact]
        public void ExcelFileAnalyseTest()
        {
            var model = ExcelModel.OpenFile("ExportImportFormats/Combined.xlsx");
            Assert.True(new[] { "Album", "Artist" }.SequenceEqual(model.GetSheetNames()));
        }

        [Fact]
        public void ExcelFileReadTest()
        {
            Initialize("sqlite");

            var batch = new Batch
            {
                Connection = ProviderConnectionString,
            };
            batch.Commands.Add(new Excel.Open { File = "ExportImportFormats/Combined.xlsx" });
            batch.Commands.Add(new CopyTable
            {
                Source = new Excel.Sheet { SheetName = "Album" },
                Target = new CreateTable { Name = "ExcelAlbum" },
            });
            batch.Commands.Add(new Excel.Close());

            batch.Run();
            AssertIsValue("28", $"select count(*) from ExcelAlbum");
            AssertIsValue("Big Ones", $"select Title from Album where AlbumId=5");
        }
    }
}
