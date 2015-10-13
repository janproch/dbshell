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

    }
}
