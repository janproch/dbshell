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

        [DeploymentItem("RelatedDataSync/rds1.xaml")]
        [TestMethod]
        public void SimpleSyncTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRds1Data.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds1.xaml");
                runner.Run();
            }
            AssertIsValue("3", "select count(*) from Target");
        }

        [DeploymentItem("RelatedDataSync/rds2.xaml")]
        [TestMethod]
        public void SourceJoinSyncTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRds2Data.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds2.xaml");
                runner.Run();
            }
        }

        [DeploymentItem("RelatedDataSync/rdscountry_natural.xaml")]
        [TestMethod]
        public void CountryNaturalKeysTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsGeoDataNatualKeys.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rdscountry_natural.xaml");
                runner.Run();
            }
            AssertExists("select * from TargetCityPartByContinentList");
        }

        [DeploymentItem("RelatedDataSync/rdscountry_integer.xaml")]
        [TestMethod]
        public void CountryIntegerKeysTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsGeoDataIntegerKeys.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rdscountry_integer.xaml");
                runner.Run();
            }
        }

        [DeploymentItem("RelatedDataSync/rds_lifetime.xaml")]
        [TestMethod]
        public void LifetimeTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRds2Lifetime.sql");
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

        [DeploymentItem("RelatedDataSync/rds_excel.xaml")]
        [DeploymentItem("RelatedDataSync/rds.xlsx")]
        [TestMethod]
        public void RdsExcelTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsExcel.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_excel.xaml");
                runner.Run();
            }

            AssertExists("select * from ExcelTarget");
        }

        [DeploymentItem("RelatedDataSync/rds_flat.xaml")]
        [TestMethod]
        public void RdsFlatTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsFlat.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_flat.xaml");
                runner.Run();
            }

            AssertExists("select * from Target1");
            AssertExists("select * from Target2");
        }

        [DeploymentItem("RelatedDataSync/rds_params.xaml")]
        [TestMethod]
        public void RdsParamsTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRds1Data.sql");
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

        [DeploymentItem("RelatedDataSync/rds_name_params.xaml")]
        [TestMethod]
        public void RdsNameParamsTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRds_NameParams.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_name_params.xaml");
                runner.Run();
            }
            RunScript("exec RunSync1 @TargetName='TargetData', @SourceName='SourceData', @SourceQuery='select 1001 as SourceId2, 1001 as Value2'");

            AssertExists("select * from TargetData where ParamId=1");
            AssertIsValue("1001", "select Value from TargetData where ParamId=2");
        }

        [DeploymentItem("RelatedDataSync/rds_ref_restr.xaml")]
        [TestMethod]
        public void RdsRefRestrTest()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsRefRestr.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_ref_restr.xaml");
                runner.Run();
            }

            AssertExists("select * from Target");
        }

        [DeploymentItem("RelatedDataSync/rds_duplicator.xaml")]
        [TestMethod]
        public void RdsDuplicator()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsDuplicator.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_duplicator.xaml");
                runner.Run();
            }

            AssertExists("select * from Master where MasterIsCopy=1");
            AssertExists("select * from Detail where DetailIsCopy=1");
        }

        [DeploymentItem("RelatedDataSync/rds_ref_update.xaml")]
        [TestMethod]
        public void RdsRefUpdate()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsRefUpdate.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_ref_update.xaml");
                runner.Run();
            }

            RunScript("exec RunSync");
            AssertIsValue("2", "select count(*) from TargetDetail inner join TargetMaster on TargetDetail.TargetMasterId=TargetMaster.TargetMasterId where TargetMaster.MasterIdOriginal=1");

            RunScript("update Source set MasterId=2 where DetailId=1");
            RunScript("exec RunSync");
            AssertIsValue("1", "select count(*) from TargetDetail inner join TargetMaster on TargetDetail.TargetMasterId=TargetMaster.TargetMasterId where TargetMaster.MasterIdOriginal=1");
        }

        [DeploymentItem("RelatedDataSync/rds_template.xaml")]
        [TestMethod]
        public void RdsTemplate()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsTemplate.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_template.xaml");
                runner.Run();
            }

            AssertIsValue("1_2", "select Value from Target where TargetIdOriginal=1");
            AssertIsValue("1_", "select Value from Target where TargetIdOriginal=2");
            AssertIsValue("_2", "select Value from Target where TargetIdOriginal=3");
        }

        [DeploymentItem("RelatedDataSync/rds_ref_restr_2.xaml")]
        [TestMethod]
        public void RdsRefRestrTest2()
        {
            // restriction on reference object
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsRefRestr2.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_ref_restr_2.xaml");
                runner.Run();
            }

            RunScript("exec RunSync");

            AssertIsValue("2", "select count(*) from TargetItemGroup where TargetGroupId=1");

            RunScript("insert into TargetItemGroup values (3, 2)");

            RunScript("exec RunSync");
            AssertIsValue("2", "select count(*) from TargetItemGroup where TargetGroupId=1");
            // test whether row which does not match restriction is not deleted
            AssertIsValue("1", "select count(*) from TargetItemGroup where TargetGroupId=2");

            RunScript("update Source set IsInGroup=0 where Value='val2'");
            RunScript("exec RunSync");
            AssertIsValue("1", "select count(*) from TargetItemGroup where TargetGroupId=1");
            AssertIsValue("1", "select count(*) from TargetItemGroup where TargetGroupId=2");
        }

        [DeploymentItem("RelatedDataSync/rds_ref_restr_3.xaml")]
        [TestMethod]
        public void RdsRefRestrTest3()
        {
            // restriction on reference object
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsRefRestr3.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_ref_restr_3.xaml");
                runner.Run();
            }

            RunScript("exec RunSync");

            AssertIsValue("2", "select count(*) from TargetGroup");
            AssertIsValue("3", "select count(*) from TargetItemGroup");

            RunScript("insert into TargetGroup (GroupName, TargetCategoryId) values ('fixed1', 2)");
            RunScript("insert into TargetItemGroup values (1, 3)");
            RunScript("insert into TargetItemGroup values (2, 3)");

            AssertIsValue("5", "select count(*) from TargetItemGroup");
            AssertIsValue("3", "select count(*) from TargetGroup");

            RunScript("exec RunSync");

            AssertIsValue("5", "select count(*) from TargetItemGroup");
            AssertIsValue("3", "select count(*) from TargetGroup");

            RunScript("update Source set GroupName='g3' where SourceId = 3");
            RunScript("exec RunSync");
            AssertIsValue("5", "select count(*) from TargetItemGroup");
            AssertIsValue("4", "select count(*) from TargetGroup");
        }

        [DeploymentItem("RelatedDataSync/rds_null_restr.xaml")]
        [TestMethod]
        public void RdsNullRestr()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsNullRestr.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_null_restr.xaml");
                runner.Run();

                AssertIsValue("3", "select count(*) from Target");

                runner.Run();

                AssertIsValue("3", "select count(*) from Target");
            }
        }

        [DeploymentItem("RelatedDataSync/rds_update_restr.xaml")]
        [TestMethod]
        public void RdsUpdateRestr()
        {
            InitDatabase();
            RunEmbeddedScript("RelatedDataSync.CreateRdsUpdateRestr.sql");

            using (var runner = CreateRunner())
            {
                runner.LoadFile("rds_update_restr.xaml");
                runner.Run();
                AssertIsValue("2", "select count(*) from Target2");

                RunScript("update Source2 set Value1=22 where ID=2");
                runner.Run();
                AssertIsValue("2", "select count(*) from Target2");
                AssertIsValue("101", "select Value1 from Target2 where IdOriginal=1");
                AssertIsValue("22", "select Value1 from Target2 where IdOriginal=2");
            }
        }
    }
}
