using System;
using System.Data;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using ForgetTraffic.Autentication;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Users;
using ForgetTraffic.TrafficIncidences;
using ForgetTraffic.DataModel;

namespace ForgetTraffic.WsService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ForgetTrafficService : IForgetTraffic
    {
       
        public ServiceOutput<UserInfo> LogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
               
                return new ServiceOutput<UserInfo>()
                           {
                               Error = true,
                               Description ="The user or password are empty or null! Please verify this parameters"
                           } ;
            }

            //var json_serializer = new JavaScriptSerializer();
            //MyObj routes_list = json_serializer.Deserialize<MyObj>("{ \"test\":\"some data\" }");


            ServiceOutput<UserInfo> _out = AccountOperations.GetUserInfoByCredentials(userName, password);

            GeneralManager.Commit();

            return _out;
        }

        public ServiceOutput<CdoUserProfile> AddUser(CdoUserProfile userProfile)
        {
            if (String.IsNullOrEmpty(userProfile.UserName))
                return new ServiceOutput<CdoUserProfile>()
                           {
                               Description = "The parameters username are empty or null! Please submit one valid username to update"
                           };

            ServiceOutput<CdoUserProfile> _user = AccountOperations.CreateUser(new CdoUserProfile
                                                                                  {
                                                                                      BirthDate = userProfile.BirthDate,
                                                                                      Email = userProfile.Email,
                                                                                      FirstName = userProfile.FirstName,
                                                                                      LastName = userProfile.LastName,
                                                                                      Password = userProfile.Password,
                                                                                      SecretAnswer = userProfile.SecretAnswer,
                                                                                      SecretQuestion =
                                                                                          userProfile.SecretQuestion,
                                                                                      UserName = userProfile.UserName
                                                                                  });

            GeneralManager.Commit();

            return _user;
        }

        public ServiceOutput<CdoUserProfile> GetUserProfile(string loginToken)
        {

           return  AccountOperations.GetUserProfile( loginToken);

        }

        public ServiceOutput<UserInfo> EmailConfirmation(string token)
        {
           ServiceOutput<tblUser> _user =   ConfirmationsViaEmail.ConfirmationUserRegistration(token);

            if( _user.Error )
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://www.forgettraffic.net/docs/html/welcome_to_forget_about_traffic.html");
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://www.forgettraffic.net/docs/html/Error_register.html");
            }

            return null;
        }


        public string Geting()
        {
     
            //WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
            //WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://www.microsoft.com");

            try
            {
                tblSysState state = ForgetTraffic.DAL.EntitiesManagers.StatusManager.GetByCodeAndParent("U", "States");
                //state.Description = "O_Ze_Gay";
                ForgetTraffic.InitializeStructure.GeneralInitialize.Commit();
            }
            catch (OptimisticConcurrencyException ex)
            {

                
                throw ex;
            }
           


            return "<div>Foi pedido as " + DateTime.Now.ToShortTimeString() +"  </div>";
        }

        public string ConcurrenyTest(string code, string oldCode)
        {
            throw new NotImplementedException();
        }

        public  ServiceOutput<CdoUserProfile> UpdateUserProfile(CdoUserProfile userProfile)
        {
            ServiceOutput<CdoUserProfile> _ret = AccountOperations.UpdateUserProfile(userProfile);



            GeneralManager.Commit();

            return  _ret ;
        }

        ServiceOutput<Incident> IForgetTraffic.PutIncidentJson(Incident occur)
        {
            OccurenceOperations _operation = new OccurenceOperations();

            ServiceOutput<Incident> _retunr =  _operation.AddIncident(occur);

           GeneralManager.Commit();

            return _retunr;
        }

        public ServiceOutput<Incident> PutIncidentJson(int codIncident)
        {
            return new ServiceOutput<Incident>(){Description = "Merda para isto..."};
        }


        public void PutIncidentXml(Incident occur)
        {
            throw new NotImplementedException();
        }

        public void PutingTest(Incident occur)
        {
            //IncidenceStubs.IncidenceStubsSingleton().putIncident(occur);

        }

        public ServiceOutput<IncidentReturnSet> GetIncidents(string distrito, string concelho, string localidade, long lastVerifyDate )
        {

            //TimeSpan _span = new TimeSpan(lastVerifyDate);
            DateTime _now = new DateTime(lastVerifyDate);

            ConsultIndicent criteria = new ConsultIndicent()
                                           {
                                               Concelho = concelho,
                                               Distrito = distrito,
                                               Localidade = localidade,
                                               LastVerifyDate = lastVerifyDate > 0 ? _now  : (DateTime?)null
                                           };


            ServiceOutput<IncidentReturnSet > _returns =GetIncidentsOperations.GetIncidents(criteria);

            return _returns;

        }

        public ServiceOutput<string> VoteIncident(VoteSubmit vote)
        {

            if(String.IsNullOrEmpty(vote.LoginToken) || String.IsNullOrEmpty(vote.CodIncident) )
            {
                return new ServiceOutput<string>()
                           {
                               Error =  true,
                               Description = "Parameters are empty or null"
                           };
            }

            ServiceOutput<tblIncidentVote> _vote = OccurenceOperations.VoteOnIncident(new VoteSubmit()
            {
                CodIncident = vote.CodIncident,
                Comment = vote.Comment,
                LoginToken = vote.LoginToken,
                PositiveVote = vote.PositiveVote
            });

            GeneralManager.Commit();

            return new ServiceOutput<string>()
                       {
                           Error = _vote.Error,
                           Description =  _vote.Description,
                           Title = _vote.Title
                       };
        }



        public void PutOccurrence(Incident occur)
        {
            IncidenceStubs.IncidenceStubsSingleton().putIncident(occur);
        }
    }
}