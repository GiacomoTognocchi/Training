using System;
using System.Collections.Generic;
using System.Configuration;
using System.Management;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crif.CribisCom.Core.TestTools.UnitTesting;
using CC.Business.ProfileManager.Core.CribisComX.BusinessObjects;
using Crif.CribisCom.Core.Domain.Data;
using Crif.CribisCom.Core.Domain.Shared;
using Crif.CribisCom.Core.Repositories.Infrastructure;
using Crif.CribisCom.Core.Domain.Repository;


namespace CC.Business.ProfileManager.Core.CribisComX.UnitTest {
    /// <summary>
    /// Summary description for ProfileManagerTest
    /// </summary>
    [TestClass]
    public class ProfileManagerTest {
        const int MAX_THREADS = 20;
        const int MAX_ITERATIONS = 50;
        private const string CreateProfilation_ContinuousMonitor = @"CreateProfilation_ContinuousMonitor.sql";        
        private const string DeleteProfilation_ContinuousMonitor = @"DeleteProfilation_ContinuousMonitor.sql";

        private static ManualResetEvent startEvent = new ManualResetEvent(false);

        public ProfileManagerTest() {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //S
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) {
        //    EnableNetworkConnections();

        //    TestEnvironment.RemovePrecondition();

        //    TestEnvironment.SetPrecondition();
        //}
        //
        // Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup() {
        //    EnableNetworkConnections();

        //    TestEnvironment.RemovePrecondition();
        //}
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        private static void DisableNetworkConnections() {
            SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2");
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            foreach (ManagementObject result in search.Get()) {
                NetworkAdapter adapter = new NetworkAdapter(result);
                if (adapter.AdapterType.Equals("Ethernet 802.3")) {
                    adapter.Disable();
                }
            }
        }

        private static void EnableNetworkConnections() {
            SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=0");
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            List<NetworkAdapter> enabledEth = new List<NetworkAdapter>();
            foreach (ManagementObject result in search.Get()) {
                NetworkAdapter adapter = new NetworkAdapter(result);
                adapter.Enable();
                enabledEth.Add(adapter);
            }
            NetworkAdapter tmp = null;
            foreach (NetworkAdapter eth in enabledEth) {
                bool loop = true;
                while (loop) {
                    Thread.Sleep(1000);
                    query = new SelectQuery("Win32_NetworkAdapter", String.Format("DeviceID='{0}'", eth.DeviceID));
                    search = new ManagementObjectSearcher(query);
                    foreach (ManagementObject result in search.Get()) {
                        tmp = new NetworkAdapter(result);
                        loop = tmp.NetConnectionStatus != 2;
                    }

                }
            }
            if (enabledEth.Count > 0)
                Thread.Sleep(15000);
        }

        [TestMethod]
        public void TestProfileExternalSearch()
        {
            RepoManager.AddConnectionString(DomainKeys.ConnectionStringKey, ConfigurationManager.ConnectionStrings["DomainConnectionString"].ConnectionString);
            ProductHierarchyItem productItem = ProductsHierarchy.GetProduct("IRCReimRA");
            ProfileManager<ProductHierarchyProfile> hierarchyProfileManager = ProfileStore<ProductHierarchyProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            ProductHierarchyProfile productHierarchyProfile = hierarchyProfileManager.GetProfile(productItem.ProductFullName, "A", ProfileNamespaces.PRODUCTHIERARCHYPROFILE);
            //ProductHierarchyProfile productHierarchyProfile = hierarchyProfileManager.GetProfile("", "A", ProfileNamespaces.PRODUCTHIERARCHYPROFILE);


            ProfileManager<DataPacketProfile> dataPacketProfileManager = ProfileStore<DataPacketProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            string dataPacketProfileCode = String.Format("{0}|{1}", ProfileNamespaces.DATAPACKETPROFILE,
                null == productHierarchyProfile || string.IsNullOrEmpty(productHierarchyProfile.DataPacketProfileCode) ? "IRCReimRA" : productHierarchyProfile.DataPacketProfileCode);
            DataPacketProfile dataPacketProfile = dataPacketProfileManager.GetProfile("ES=1038,DS=1038,SB=878078406,OF=87825139,U=a2a_alebellini", "A", dataPacketProfileCode);
            string error = string.Empty;
            try
            {
                if (dataPacketProfile == null)
                {
                    error = "No DataPacket found";
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        [TestMethod]
        public void TestProfileDocumentTransformation()
        {
            ProfileManager<DTP> pm = ProfileStore<DTP>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);

            DTP foo = pm.GetProfile("ES=1038,DS=1038,SB=878078406,OF=87825139,U=a2a_alebellini", "A", ProfileNamespaces.DOCUMENTTRANSFORMATION);

            
        }

        [TestMethod]
        public void TestProfileReport()
        {
            ProfileManager<CCRP> pm = ProfileStore<CCRP>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            CCRP foo = pm.GetProfile("ES=1038,DS=1038,SB=878078406,OF=87825139,U=alebellini", "W", "urn:crif-cribiscom-companyreport-2010-11-24");
        }

        [TestMethod]
        public void TestVirtualDesk()
        {
            ProfileManager<VDP> vdp = ProfileStore<VDP>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            VDP foo = vdp.GetProfile("ES=1038,DS=1038,SB=878078406,OF=87825139,U=alebellini", "W", "urn:crif-cribiscom-virtualdesk-2018-06-03");
        }

        [TestMethod]
        public void TestClusters()
        {
            ProfileManager<CP> cp = ProfileStore<CP>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            CP foo = cp.GetProfile("ES=1038,DS=1038,SB=878078406,OF=87825139,U=alebellini", "W", "urn:crif-cribiscom-clusters-2018-06-03");
        }

        [TestMethod]
        public void TestPortfolioMarketing()
        {
            ProfileManager<ML> pm = ProfileStore<ML>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            ML foo = pm.GetProfile("ES=1038,DS=1038,SB=878078406,OF=87825139,U=ese79abdsidd", "W", "urn:crif-cribiscom-marketlab-2016-07-29");

        }

        [TestMethod]
        public void TestIsProfileContinuousMonitor_True()
        {

            ProfileManagerHelperTest.ExecuteDataBaseScript(DeleteProfilation_ContinuousMonitor);
            ProfileManagerHelperTest.ExecuteDataBaseScript(CreateProfilation_ContinuousMonitor);

            ProfileManager<CMP> pm = ProfileStore<CMP>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            CMP cmp = pm.GetProfile("ES=1038,DS=1038,SB=878320000,OF=878500000,U=CODUSER_STD10", "A", ProfileNamespaces.CONTINUOUSMONITOR);
            Assert.AreEqual(true, cmp.ICM);

            ProfileManagerHelperTest.ExecuteDataBaseScript(DeleteProfilation_ContinuousMonitor);
        }

        [TestMethod]
        public void TestIsProfileContinuousMonitor_False()
        {

            ProfileManager<CMP> pm = ProfileStore<CMP>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            CMP cmp = pm.GetProfile("ES=1038,DS=1038,SB=878320000,OF=878500000,U=CODUSER_STD11", "A", ProfileNamespaces.CONTINUOUSMONITOR);
            Assert.AreNotEqual(true, cmp.ICM);

        }

        [TestMethod]
        public void TestExpiry() {
            ProfileManager<FooProfile> pm = ProfileStore<FooProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            FooProfile foo = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=FIAT001", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
            Assert.AreEqual<Color>(Color.Green, foo.UIColors.TableFont);
            Assert.AreEqual<Color>(Color.Yellow, foo.UIColors.TitleFont);
            Assert.AreEqual<string>("500", foo.Timeout);

            DisableNetworkConnections();

            foo = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=FIAT001", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
            Assert.AreEqual<Color>(Color.Green, foo.UIColors.TableFont);
            Assert.AreEqual<Color>(Color.Yellow, foo.UIColors.TitleFont);
            Assert.AreEqual<string>("500", foo.Timeout);

            Thread.Sleep(15000);

            try {
                pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=FIAT001", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
            }
            catch {
            }

            EnableNetworkConnections();

            foo = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=FIAT001", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
            Assert.AreEqual<Color>(Color.Green, foo.UIColors.TableFont);
            Assert.AreEqual<Color>(Color.Yellow, foo.UIColors.TitleFont);
            Assert.AreEqual<string>("500", foo.Timeout);
        }

        //[TestMethod]
        //public void TestEscalation() {
        //    Console.WriteLine("Connection: {0}", ConfigurationManager.ConnectionStrings["ProfileStore"] != null ? ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString : "null");
        //    ProfileManager<FooProfile> pm = ProfileStore<FooProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
        //    FooProfile foo = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=FIAT001", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
        //    Assert.AreEqual<Color>(Color.Green, foo.UIColors.TableFont);
        //    Assert.AreEqual<Color>(Color.Yellow, foo.UIColors.TitleFont);
        //    Assert.AreEqual<string>("500", foo.Timeout);
        //    foo = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=Foo", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
        //    Assert.AreEqual<Color>(Color.Black, foo.UIColors.TableFont);
        //    Assert.AreEqual<Color>(Color.Yellow, foo.UIColors.TitleFont);
        //    Assert.AreEqual<string>("2000", foo.Timeout);
        //    ProfileManager<HTTPMainProcessProfile> pMain = ProfileStore<HTTPMainProcessProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
        //    HTTPMainProcessProfile mainProfile = pMain.GetProfile("H=TP,TPAs=Administrators,TPA=CC_HTTP_Main_User1", "WEB", TestEnvironment.Prefix + "urn:crif-cribiscom-mainprocess-2009-01-21");
        //    Assert.AreEqual<string>("DemoProcess", (mainProfile.Item as HMPPWSE2007L).PID);
        //    Assert.AreEqual<int>(60000, (mainProfile.Item as HMPPWSE2007L).T);
        //    Assert.AreEqual<string>("TestDocument", mainProfile.SDN);
        //}

        [TestMethod]
        public void TestCache() {
            ProfileManager<BarProfile> pm = ProfileStore<BarProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            BarProfile Bar = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=FIAT001", "MGS", TestEnvironment.Prefix + "urn:profile-Bar:2009");
            Assert.AreEqual<Color>(Color.Green, Bar.UIColors.TableFont);
            Assert.AreEqual<Color>(Color.Yellow, Bar.UIColors.TitleFont);
            Assert.AreEqual<string>("500", Bar.Timeout);
            Bar = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=Bar", "MGS", TestEnvironment.Prefix + "urn:profile-Bar:2009");
            Assert.AreEqual<Color>(Color.Black, Bar.UIColors.TableFont);
            Assert.AreEqual<Color>(Color.Yellow, Bar.UIColors.TitleFont);
            Assert.AreEqual<string>("2000", Bar.Timeout);

            Thread.Sleep(5000);

            Bar = pm.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=Bar", "MGS", TestEnvironment.Prefix + "urn:profile-Bar:2009");
            Assert.AreEqual<Color>(Color.Black, Bar.UIColors.TableFont);
            Assert.AreEqual<Color>(Color.Yellow, Bar.UIColors.TitleFont);
            Assert.AreEqual<string>("2000", Bar.Timeout);
        }

        [TestMethod]
        public void TestConcurrency() {
            ProfileManager<BarProfile> pmBar = ProfileStore<BarProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            ProfileManager<FooProfile> pmFoo = ProfileStore<FooProfile>.GetProfileManager(ConfigurationManager.ConnectionStrings["ProfileStore"].ConnectionString);
            Thread[] vWorkers = new Thread[MAX_THREADS];
            for (int i = 0; i < MAX_THREADS; ++i) {
                if (i % 2 == 1) {
                    vWorkers[i] = new Thread(FooWorker);
                    vWorkers[i].Name = String.Format("Foo{0}", i);
                    vWorkers[i].Start(pmFoo);
                }
                else {
                    vWorkers[i] = new Thread(BarWorker);
                    vWorkers[i].Name = String.Format("Bar{0}", i);
                    vWorkers[i].Start(pmBar);
                }
            }
            startEvent.Set();
            for (int i = 0; i < MAX_THREADS; ++i) {
                vWorkers[i].Join();
            }
        }

        private void FooWorker(object state) {
            startEvent.WaitOne();
            Random random = new Random((int)DateTime.Now.Ticks);
            Thread.Sleep(random.Next(200, 500));
            ProfileManager<FooProfile> pmFoo = (ProfileManager<FooProfile>)state;
            FooProfile foo = null;
            for (int i = 0; i < MAX_ITERATIONS; ++i) {
                foo = pmFoo.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=FIAT001", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
                Assert.AreEqual<Color>(Color.Green, foo.UIColors.TableFont);
                Assert.AreEqual<Color>(Color.Yellow, foo.UIColors.TitleFont);
                Assert.AreEqual<string>("500", foo.Timeout);
                foo = pmFoo.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=Foo", "MGS", TestEnvironment.Prefix + "urn:profile-foo:2009");
                Assert.AreEqual<Color>(Color.Black, foo.UIColors.TableFont);
                Assert.AreEqual<Color>(Color.Yellow, foo.UIColors.TitleFont);
                Assert.AreEqual<string>("2000", foo.Timeout);
            }
            Console.WriteLine("{0} - Finished at {1}", Thread.CurrentThread.Name, DateTime.Now.ToLongTimeString());
        }

        private void BarWorker(object state) {
            startEvent.WaitOne();
            Random random = new Random((int)DateTime.Now.Ticks);
            Thread.Sleep(random.Next(200, 500));
            ProfileManager<BarProfile> pmBar = (ProfileManager<BarProfile>)state;
            BarProfile bar = null;
            for (int i = 0; i < MAX_ITERATIONS; ++i) {
                bar = pmBar.GetProfile("H=CC,C=Crif,ASP=Crif,S=FIAT,O=FIAT-ACQ,CCU=Bar", "MGS", TestEnvironment.Prefix + "urn:profile-Bar:2009");
                Assert.AreEqual<Color>(Color.Black, bar.UIColors.TableFont);
                Assert.AreEqual<Color>(Color.Yellow, bar.UIColors.TitleFont);
                Assert.AreEqual<string>("2000", bar.Timeout);
            }
            Console.WriteLine("{0} - Finished at {1}", Thread.CurrentThread.Name, DateTime.Now.ToLongTimeString());
        }

        
    }
}

