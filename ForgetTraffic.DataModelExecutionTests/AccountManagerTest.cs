using ForgetTraffic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ForgetTraffic.DataModelExecutionTests
{
    
    
    /// <summary>
    ///This is a test class for AccountManagerTest and is intended
    ///to contain all AccountManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccountManagerTest
    {


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
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateUserTest()
        {
            AccountManager target = new AccountManager(); // TODO: Initialize to an appropriate value
            string userName = "fbenfica"; // TODO: Initialize to an appropriate value
            string firstName = "fernado"; // TODO: Initialize to an appropriate value
            string lastName = "benfica"; // TODO: Initialize to an appropriate value
            string email = "fernandobenfica@gmail.pt"; // TODO: Initialize to an appropriate value
            tblUser expected = null;

            tblUser actual = target.CreateUser(userName, firstName, lastName, email);
            using (ForgetTrafficEntities db = new ForgetTrafficEntities()) 
            {
                expected = db.tblUser.SingleOrDefault(u => u.UserName.Trim().Equals(userName));


               
            }

            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(actual, expected);


            target.RemoveUser(userName);

           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateUserProvider
        ///</summary>
        //[TestMethod()]
        public void CreateUserProviderTest()
        {
            //AccountManager target = new AccountManager(); // TODO: Initialize to an appropriate value
            //tblUser user = null; // TODO: Initialize to an appropriate value
            //string pass = string.Empty; // TODO: Initialize to an appropriate value
            //string SecretQuestion = string.Empty; // TODO: Initialize to an appropriate value
            //string SecretAnwser = string.Empty; // TODO: Initialize to an appropriate value
            //DateTime birthDate = new DateTime(); // TODO: Initialize to an appropriate value
            //tblUserProvider expected = null; // TODO: Initialize to an appropriate value
            //tblUserProvider actual;
            //actual = target.CreateUserProvider(user, pass, SecretQuestion, SecretAnwser, birthDate);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

     
    }
}
