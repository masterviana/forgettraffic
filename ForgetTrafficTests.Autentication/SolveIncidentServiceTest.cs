﻿using ForgetTraffic.ParallelsServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForgetTraffic.ExecutionTests
{
    
    
    /// <summary>
    ///This is a test class for SolveIncidentServiceTest and is intended
    ///to contain all SolveIncidentServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SolveIncidentServiceTest
    {


        private TestContext testContextInstance;


        public SolveIncidentServiceTest()
        {
            ForgetTraffic.ParallelsServices.ServiceManager.Initialize();
        }

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
        ///A test for SolveIncidentService Constructor
        ///</summary>
        [TestMethod()]
        public void SolveIncidentServiceConstructorTest()
        {
            SolveIncidentService target = new SolveIncidentService();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Run
        ///</summary>
        [TestMethod()]
        public void RunTest()
        {
            SolveIncidentService target = new SolveIncidentService(); // TODO: Initialize to an appropriate value
            object snyc = null; // TODO: Initialize to an appropriate value
            target.Run(snyc);

            




            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Solve
        ///</summary>
        [TestMethod()]
        public void SolveTest()
        {
            SolveIncidentService target = new SolveIncidentService(); // TODO: Initialize to an appropriate value
            object i = null; // TODO: Initialize to an appropriate value
            object tInput = null; // TODO: Initialize to an appropriate value
            target.Solve(i, tInput);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
