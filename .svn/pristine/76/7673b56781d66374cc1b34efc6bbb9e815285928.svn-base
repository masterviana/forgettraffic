using System;
using ForgetTraffic.Autentication;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.TrafficIncidences;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForgetTraffic.ExecutionTests
{
    /// <summary>
    ///This is a test class for OccurenceOperationsTest and is intended
    ///to contain all OccurenceOperationsTest Unit Tests
    ///</summary>
    [TestClass]
    public class OccurenceOperationsTest
    {
        public OccurenceOperationsTest()
        {
            GeneralManager.Initialize();
        }


        String username = "Master";
        String pass = "vviana";


    


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
        ///A test for OccurenceOperations Constructor
        ///</summary>
        [TestMethod]
        public void OccurenceOperationsConstructorTest()
        {
            var target = new OccurenceOperations();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddIncident
        ///</summary>
        [TestMethod]
        public void AddIncidentTest()
        {
            //tblUser _user = UserManager.GetUser("Master", Guid.Empty);

            //ServiceOutput<string > _provider 
            //    = SessionCredentialProviderManager.CreateTokenForUserRequest("Master","vviana@2011");


            ServiceOutput<UserInfo> userInfo = AccountOperations.GetUserInfoByCredentials ( username, pass );

            var target = new OccurenceOperations(); // TODO: Initialize to an appropriate value
            var incident = new Incident
                               {
                                   Concelho = "Faro",
                                   Coordinates = new Cord
                                                     {
                                                         Latitude = 5,
                                                         Longitude = 5
                                                     },
                                   Description = "Manuntenao de teste",
                                   Distrito = "Faro",
                                   Title = "Manutenção Faro",
                                   Localidade = "Faro",
                                   LoginToken = userInfo.Value.LoginToken,
                                   PublicationDate = DateTime.Now,
                                   Type = IncidentType.Accident
                               };



            target.AddIncident(incident);

            GeneralManager.Commit();

            //Assert.AreEqual(actual.Error, expected.Error);
        }

        

        /// <summary>
        ///A test for VoteOnIncident
        ///</summary>
        [TestMethod ( )]
        public void VoteOnIncidentTest ()
        {



            ServiceOutput<UserInfo> userInfo =  AccountOperations.GetUserInfoByCredentials ( username, pass );


            String CodIncident = "D3A2BFB0-2AB7-4207-B87E-DAD795F9E839";


           ServiceOutput<tblIncidentVote> vote  =  OccurenceOperations.VoteOnIncident(new VoteSubmit()
                                                   {
                                                       CodIncident = CodIncident,
                                                       Comment = "Confirmo",
                                                       LoginToken = userInfo.Value.LoginToken,
                                                       PositiveVote = true
                                                   });

            GeneralManager.Commit();

        }
    }
}