using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.ServiceUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Authentication;

namespace ForgetTraffic.ExecutionTests
{
    
    
    /// <summary>
    ///This is a test class for ConfirmationEmailTest and is intended
    ///to contain all ConfirmationEmailTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfirmationEmailTest
    {

        public ConfirmationEmailTest()
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
        ///A test for GenerateUserRegisterMailValidation
        ///</summary>
        [TestMethod()]
        public void GenerateUserRegisterMailValidationTest()
        {
            tblUser user = UserManager.GetUser("Master", Guid.Empty);
            ServiceOutput<tblConfirmActions> expected = null; // TODO: Initialize to an appropriate value
            ServiceOutput<tblConfirmActions> actual;
            actual = ConfirmationEmail.GenerateUserRegisterMailValidation(user);
            
            
            GeneralManager.Commit();
            
            Assert.AreEqual(expected, actual);


            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConfirmRegisterAccount
        ///</summary>
        [TestMethod()]
        public void ConfirmRegisterAccountTest()
        {
            string token = string.Empty; // TODO: Initialize to an appropriate value
            ServiceOutput<tblUser> expected = null; // TODO: Initialize to an appropriate value
            ServiceOutput<tblUser> actual;
            actual = ConfirmationEmail.ConfirmRegisterAccount(token);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
