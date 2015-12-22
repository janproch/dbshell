using DbShell.RelatedDataSync;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Test
{
    [TestClass]
    public class RdsTest : DatabaseTestBase
    {
        public RdsTest()
        {
            new SyncModel();
            new Excel.Open();
        }

        [DeploymentItem("rds1.xaml")]
        [TestMethod]
        public void SimpleSyncTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRds1Data.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds1.xaml");
                runner.Run();
            }
        }

        [DeploymentItem("rds2.xaml")]
        [TestMethod]
        public void SourceJoinSyncTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRds2Data.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds2.xaml");
                runner.Run();
            }
        }

        [DeploymentItem("rdscountry_natural.xaml")]
        [TestMethod]
        public void CountryNaturalKeysTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRdsGeoDataNatualKeys.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rdscountry_natural.xaml");
                runner.Run();
            }
            AssertExists("select * from TargetCityPartByContinentList");
        }

        [DeploymentItem("rdscountry_integer.xaml")]
        [TestMethod]
        public void CountryIntegerKeysTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRdsGeoDataIntegerKeys.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rdscountry_integer.xaml");
                runner.Run();
            }
        }

        [DeploymentItem("rds_lifetime.xaml")]
        [TestMethod]
        public void LifetimeTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRds2Lifetime.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_lifetime.xaml");
                runner.Run();
            }
            RunScript("exec RunSync1");
            RunScript("update source set A='1a.v2' where Id=1");
            RunScript("delete from source where Id=2");
            RunScript("exec RunSync1");

            AssertIsNotNull("select DeletedDate from Target where IdOriginal='2' and ImportGroup='markdelete'");
            AssertIsNull("select Id from Target where IdOriginal=2 and ImportGroup='simple'");

            AssertIsNotNull("select ValidTo from Target where IdOriginal='2' and ImportGroup='keephistory'");
            AssertIsNull("select ValidTo from Target where IdOriginal='3' and ImportGroup='keephistory'");
            AssertIsNotNull("select ValidTo from Target where IdOriginal='1' and ImportGroup='keephistory'");
            AssertIsValue("1a.v2", "select A from Target where IdOriginal = '1' and ImportGroup = 'keephistory' and ValidTo is null");

            RunScript("update Source set A=null where Id=4");
            RunScript("exec RunSync1");
            AssertExists("select * from ImportLog where Operation='error'");
        }

        [DeploymentItem("rds_excel.xaml")]
        [DeploymentItem("rds.xlsx")]
        [TestMethod]
        public void RdsExcelTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRdsExcel.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_excel.xaml");
                runner.Run();
            }

            AssertExists("select * from ExcelTarget");
        }

        [DeploymentItem("rds_flat.xaml")]
        [TestMethod]
        public void RdsFlatTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRdsFlat.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_flat.xaml");
                runner.Run();
            }

            AssertExists("select * from Target1");
            AssertExists("select * from Target2");
        }

        [DeploymentItem("rds_params.xaml")]
        [TestMethod]
        public void RdsParamsTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRds1Data.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_params.xaml");
                runner.Run();
            }
            RunScript("exec RunSync1 @ResValue=11");
            RunScript("exec RunSync1");

            AssertIsValue("4", "select count(*) from Target where ParamId=11");
            AssertIsValue("4", "select count(*) from Target where ParamId=33");
            AssertIsValue("4", "select count(*) from Target where ParamId=99");
            AssertIsValue("12", "select count(*) from Target");
        }

        [DeploymentItem("rds_name_params.xaml")]
        [TestMethod]
        public void RdsNameParamsTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateRds_NameParams.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_name_params.xaml");
                runner.Run();
            }
            RunScript("exec RunSync1 @TargetName='TargetData', @SourceName='SourceData', @SourceQuery='select 1001 as SourceId2, 1001 as Value2'");

            AssertExists("select * from TargetData where ParamId=1");
            AssertIsValue("1001", "select Value from TargetData where ParamId=2");
        }
    }
}