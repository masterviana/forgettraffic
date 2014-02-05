using System;
using ForgetTraffic.Autentication;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.ServiceUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForgetTraffic.ExecutionTests
{
    /// <summary>
    /// Summary description for ServiceAccount
    /// </summary>
    [TestClass]
    public class ServiceAccount
    {

        //Master - pass : vviana


        public String _birthDate = "01/01/1983";
        public String _email = "vitorviana141@hotmail.com";
        public String _firstName = "Vitor";
        public String _lastName = "Viana";
        public String _password = "vviana";
        public String _pergunta = "Qual o maior clube";
        public String _resposta = "benfica";
        public String _user = "vviana";


        public ServiceAccount()
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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
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

        [TestMethod]
        public void CreateUserAndProvider()
        {
            AccountOperations.CreateUser(new CdoUserProfile
                                             {
                                                 BirthDate = _birthDate,
                                                 Email = _email,
                                                 FirstName = _firstName,
                                                 LastName = _lastName,
                                                 Password = _password,
                                                 SecretAnswer = _resposta,
                                                 SecretQuestion = _pergunta,
                                                 UserName = _user
                                             });


            GeneralManager.Commit();
        }

        [TestMethod]
        public void UpdateUserProfile()
        {


            //CdoUserProfile _updated = new CdoUserProfile()
            //{
            //    UserName = "Master",
            //    Password = "vviana",
            //    OldPassword = "cenas"
            //};

            //AccountOperations.UpdateUserProfile(_updated);



            //ServiceOutput<UserInfo> _out = AccountOperations.GetUserInfoByCredentials("Master","vviana");

             ConfirmationEmail.ConfirmRegisterAccount("JKGfXn8yK6n44/WLZxbRPktSIvEFGE7yhrlqhXrk98XLpnBla9GnIkNPiIrXgVa+9ztgrQ3Lky6iHeVoAPkM55y6pasH");



            GeneralManager.Commit();
        }





    }
}