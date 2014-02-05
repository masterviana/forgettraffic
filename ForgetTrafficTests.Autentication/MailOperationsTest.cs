using ForgetTraffic.ServiceUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForgetTraffic.ExecutionTests
{
    
    
    /// <summary>
    ///This is a test class for MailOperationsTest and is intended
    ///to contain all MailOperationsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MailOperationsTest
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
        ///A test for SendMailSmtp
        ///</summary>
        [TestMethod()]
        public void SendMailSmtpTest()
        {
            //string userCredentialsSmtp = ForgetTraffic.DataTypes.Consts.UserSmtp;
            //string passCredentialsSmtp = ForgetTraffic.DataTypes.Consts.PassSmtp;
            //string hostAdress = ForgetTraffic.DataTypes.Consts.HostingAdress;
            //string mailTo = "";
            //string mailfrom = ForgetTraffic.DataTypes.Consts.UserSmtp;
            //string link = "http://www.forgettraffic.net";
            //string subject = "Register Forgettraffic";
            //int port;
            //MailOperations.SendMailSmtp(userCredentialsSmtp, passCredentialsSmtp, hostAdress,26, mailTo, mailfrom, "", link, subject);

            //int a = 0;
            //a *= 3;

            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MailOperations Constructor
        ///</summary>
        [TestMethod()]
        public void MailOperationsConstructorTest()
        {
            MailOperations target = new MailOperations();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for RequestRegister
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ForgetTraffic.ServiceUtils.dll")]
        public void RequestRegisterTest()
        {
            string link = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = MailOperations_Accessor.RequestRegister(link);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SendMailSmtp
        ///</summary>
        [TestMethod()]
        public void SendMailSmtpTest1()
        {
            string userCredentialsSmtp = string.Empty; // TODO: Initialize to an appropriate value
            string passCredentialsSmtp = string.Empty; // TODO: Initialize to an appropriate value
            string hostAdress = string.Empty; // TODO: Initialize to an appropriate value
            int port = 0; // TODO: Initialize to an appropriate value
            string mailTo = string.Empty; // TODO: Initialize to an appropriate value
            string mailfrom = string.Empty; // TODO: Initialize to an appropriate value
            string message = string.Empty; // TODO: Initialize to an appropriate value
            string link = string.Empty; // TODO: Initialize to an appropriate value
            //string subject = string.Empty; // TODO: Initialize to an appropriate value
            //MailOperations.SendMailSmtp(userCredentialsSmtp, passCredentialsSmtp, hostAdress, port, mailTo, mailfrom, message, link, subject);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
