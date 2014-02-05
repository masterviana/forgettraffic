using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.TrafficIncidences;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.Authentication;

namespace ForgetTraffic.ExecutionTests
{
    
    
    /// <summary>
    ///This is a test class for GetIncidentsOperationsTest and is intended
    ///to contain all GetIncidentsOperationsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GetIncidentsOperationsTest
    {

        public GetIncidentsOperationsTest()
        {
            GeneralManager.Initialize();
        }


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetIncidents
        ///</summary>
        [TestMethod()]
        public void GetIncidentsTest()
        {
            ConsultIndicent filter = new ConsultIndicent()
                                         {
                                             Localidade = "",
                                             LastVerifyDate = Convert.ToDateTime("01/07/2011")
                                         }; // TODO: Initialize to an appropriate value
            ServiceOutput<IncidentReturnSet> expected = null; // TODO: Initialize to an appropriate value
            ServiceOutput<IncidentReturnSet> actual;

         

            actual = GetIncidentsOperations.GetIncidents(filter);

            GeneralManager.Commit();

            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
