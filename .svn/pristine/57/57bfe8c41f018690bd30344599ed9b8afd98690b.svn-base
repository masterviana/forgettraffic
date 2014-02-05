using System;
using ForgetTraffic.Autentication;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForgetTraffic.ExecutionTests
{
    /// <summary>
    ///This is a test class for AccountManagerTest and is intended
    ///to contain all AccountManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class AccountManagerTest
    {
        private String _username = "fmlvaz";
        private string birthDate = "05/06/1986"; // TODO: Initialize to an appropriate value
        private string email = "fmlvaz@gmail.com"; // TODO: Initialize to an appropriate value
        private string firstName = "Fernando "; // TODO: Initialize to an appropriate value
        private string lastName = "Vaz"; // TODO: Initialize to an appropriate value


        public AccountManagerTest()
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
        ///A test for CreateUser
        ///</summary>
        [Priority(1), TestMethod]
        public void CreateUserTest()
        {
            //var target = new AccountManager(); // TODO: Initialize to an appropriate value


            //tblUser expected; // TODO: Initialize to an appropriate value
            //tblUser actual;

            //actual = target.CreateUser(_username, firstName, lastName, email, birthDate, null,"A");

            //GeneralManager.Commit();

            //expected = UserManager.GetUser(_username, Guid.Empty);


            //Assert.AreEqual(expected.UserId, actual.UserId);
            //Assert.AreEqual(expected.UserName.Trim(), actual.UserName.Trim());
        }


        /// <summary>
        ///A test for CreateUpdateProviderUserProvider
        ///</summary>
        [Priority(2), TestMethod]
        public void CreateUpdateProviderUserProviderTest()
        {
            var target = new AccountManager(); // TODO: Initialize to an appropriate value
            Guid idUser; // TODO: Initialize to an appropriate value
            string password = "befica"; // TODO: Initialize to an appropriate value
            string secretQuestion = "Qual o teu clube"; // TODO: Initialize to an appropriate value
            string secretAnwser = "sporting"; // TODO: Initialize to an appropriate value
            tblUserProvider expected = null; // TODO: Initialize to an appropriate value
            tblUserProvider actual;

            tblUser _user = UserManager.GetUser(_username, Guid.Empty);
            if (_user == null) Assert.Equals(1, 2);

            actual = target.CreateUpdateProviderUserProvider(_user.UserName, _user.UserId, password, secretQuestion,
                                                             secretAnwser);

            GeneralManager.Commit();

            //Sacar as cenas para testar!! 
            expected = UserProviderMananger.GetActiveProvider(_user, actual.IdProvider);


            Assert.AreEqual(expected.PassHash, actual.PassHash);
            Assert.AreEqual(expected.SecretAnwser, actual.SecretAnwser);
        }

        //[Priority(3), TestMethod]
        //public void DeactiveUser()
        //{
        //    var target = new AccountManager();

        //    tblUser _user = UserManager.GetUser(_username, Guid.Empty);
        //    if (_user == null) throw new Exception("Não pode ser desactivado pois o utilizador não existe");

        //    target.DeactiveUser(_username);

        //    GeneralManager.Commit();

        //    int userCount =
        //        UserManager.Find(x => x.UserName.Trim().Equals(_username) && x.SYS_STATE.Trim().Equals("A")).Count;
        //    int providerCount =
        //        UserProviderMananger.Find(x => x.UserId == _user.UserId && x.SYS_STATE.Trim().Equals("A")).Count;


        //    Assert.AreEqual(userCount, 0);
        //    Assert.AreEqual(providerCount, 0);
        //}

        [Priority(4), TestMethod]
        public void DeleteUser()
        {
            var target = new AccountManager();

            tblUser _user = UserManager.GetUser(_username, Guid.Empty);
            Guid olderID;
            if (_user == null) throw new Exception("Não pode ser Removido pois o utilizador não existe");

            olderID = _user.UserId;

            foreach (tblUserProvider i in UserProviderMananger.Find(x => x.UserId == _user.UserId))
            {
                UserProviderMananger.Delete(i);
            }


            UserManager.Delete(_user);

            GeneralManager.Commit();
            _user = UserManager.GetUser(_username, Guid.Empty);

            Assert.IsNull(_user);

            int count = UserProviderMananger.Find(x => x.UserId == olderID) == null
                            ? 0
                            : UserProviderMananger.Find(x => x.UserId == olderID).Count;

            Assert.Equals(0, count);
        }


        ~AccountManagerTest()
        {
            GeneralManager.Dispose();
        }
    }
}