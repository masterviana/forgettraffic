using ForgetTraffic.Autentication;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForgetTraffic.ExecutionTests
{
    /// <summary>
    ///This is a test class for SessionCredentialProviderManagerTest and is intended
    ///to contain all SessionCredentialProviderManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class SessionCredentialProviderManagerTest
    {
        private string pass = "vviana@2011"; // TODO: Initialize to an appropriate value
        private string user = "Master"; // TODO: Initialize to an appropriate value


        public SessionCredentialProviderManagerTest()
        {
            GeneralManager.Initialize();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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
        ///A test for SessionCredentialProviderManager Constructor
        ///</summary>
        [TestMethod]
        public void SessionCredentialProviderManagerConstructorTest()
        {
            var target = new SessionCredentialProviderManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreateTokenForUserRequest
        ///</summary>
        [TestMethod]
        public void CreateTokenForUserRequestTest()
        {
            ServiceOutput<string> expected = null; // TODO: Initialize to an appropriate value
            ServiceOutput<string> actual;

            //actual = SessionCredentialProviderManager.CreateTokenForUserRequest(user, pass);
            //GeneralManager.Commit();


            //Assert.AreEqual(false, actual.Error);
        }

        /// <summary>
        ///A test for GetTokenIfExist
        ///</summary>
        [TestMethod]
        public void GetTokenIfExistTest()
        {
            tblUser user = null; // TODO: Initialize to an appropriate value
            ServiceOutput<string> expected = null; // TODO: Initialize to an appropriate value
            ServiceOutput<string> actual;
            //actual = SessionCredentialProviderManager.GetTokenIfExist(user);
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidateUserExistent
        ///</summary>
        [TestMethod]
        public void ValidateUserExistentTest()
        {
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string pass = string.Empty; // TODO: Initialize to an appropriate value
            ServiceOutput<tblUser> expected = null; // TODO: Initialize to an appropriate value
            ServiceOutput<tblUser> actual;
            actual = SessionCredentialProviderManager.ValidateUserExistent(username, pass);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        ~SessionCredentialProviderManagerTest()
        {
            //ForgetTraffic.DAL.EntitiesManagers.GeneralManager.Initialize();
        }
    }
}