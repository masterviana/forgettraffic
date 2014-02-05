using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using ForgetTraffic.Adminstration;
using ForgetTraffic.Autentication;
using ForgetTraffic.Autentication.AppSecurity;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Error;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.Interfaces;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Admin;
using ForgetTraffic.DataTypes.RestTypes.Incidents;
using ForgetTraffic.DataTypes.RestTypes.Users;
using ForgetTraffic.TrafficIncidences;

namespace ForgetTraffic.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ForgetTrafficService : ForgetTraffic.DataTypes.Interfaces.IRestService
    {
        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public ServiceOutput<ResponseUser> User(AddUser userProfile)
        {
            if (String.IsNullOrEmpty(userProfile.UserName))
                return new ServiceOutput<ResponseUser>()
                {
                    Error =  true,
                    Description = "The parameters username are empty or null! Please submit one valid username to update",
                };
            ServiceOutput<ResponseUser> _user = new ServiceOutput<ResponseUser>(){};
            try
            {
                _user = AccountOperations.CreateUser(new AddUser
                {
                    BirthDate = userProfile.BirthDate,
                    Email = userProfile.Email,
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    UserName = userProfile.UserName,
                    Password = userProfile.Password,
                    ConfirmPassword = userProfile.ConfirmPassword,
                    SecretAnswer = userProfile.SecretAnswer,
                    SecretQuestion = userProfile.SecretQuestion
                });

                GeneralManager.Commit();
            }
            catch (ForgetTrafficError ex )
            {
                return new ServiceOutput<ResponseUser>(){Error = true,Description = ex.Message, StatusCode = ex.Status,Title = ex.Title};
            }
            catch(Exception ex)
            {
                
            }
       

            return _user;
        }

        public ServiceOutput<ResponseUser> User(UpdateUser user)
        {
            ServiceOutput<ResponseUser> _ret = AccountOperations.UpdateUserProfile(user);

            GeneralManager.Commit();

            return _ret;
        }

        public ServiceOutput<ResponseUser> User(string loginToken)
        {
            SecurityUtils.ApplyCredentialCurrentThread(loginToken);

            try
            {
                return AccountOperations.GetUserProfile(loginToken);
            }
            catch (AuthenticationException ex)
            {
                return new ServiceOutput<ResponseUser>()
                           {
                               Description = "Your dont have permition for excute the action",
                               Error = true
                           };
            }
            catch (ForgetTrafficError ex)
            {
               return  new ServiceOutput<ResponseUser>()
                           {
                               Description = ex.Message,
                               StatusCode = ex.Status,
                               Title = ex.Title
                           };
            }
           

          
        }

        //Adicionar incidencia
        public ServiceOutput<Incident> Incident(AddIncident incident)
        {
            OccurenceOperations _operation = new OccurenceOperations();
            ServiceOutput<Incident> _retunr;
            try
            {
                _retunr = _operation.AddIncident(incident);

                GeneralManager.Commit();

            }
            catch (ForgetTrafficError ex)
            {
               return new ServiceOutput<Incident>()
                          {
                              Error = true,
                              StatusCode = ex.Status,
                              Description = ex.Message,
                              Title = ex.Title
                          };
            }
           
            return _retunr;
        }

        /// <summary>
        /// Votar na incidencia
        /// </summary>
        /// <param name="vote"></param>
        /// <returns></returns>
        public ServiceOutput<String> Incident(VoteSubmit vote)
        {
            if (String.IsNullOrEmpty(vote.LoginToken) || String.IsNullOrEmpty(vote.CodIncident))
            {
                return new ServiceOutput<string>()
                {
                    Error = true,
                    Description = "Parameters are empty or null",
                    StatusCode = ManagementErrors.PARAMETERS_ERROR
                };
            }
         
            try
            {

               ServiceOutput<tblIncidentVote> _vote = OccurenceOperations.VoteOnIncident(new VoteSubmit()
                {
                    CodIncident = vote.CodIncident,
                    Comment = vote.Comment,
                    LoginToken = vote.LoginToken,
                    PositiveVote = vote.PositiveVote
                });

                GeneralManager.Commit();
            }
            catch (ForgetTrafficError ex)
            {
                return   new ServiceOutput<string>()
                {
                    Error = true,
                    Description = ex.Message,
                    Title = ex.Title,
                    StatusCode = ex.Status
                };
            }

            return new ServiceOutput<string>()
                       {
                         Error = false,
                         Description = "Vote was added with sucess",
                         Title ="Vote added"
                       };
        }

        /// <summary>
        /// Retornar incidencias
        /// </summary>
        /// <param name="distrito"></param>
        /// <param name="concelho"></param>
        /// <param name="localidade"></param>
        /// <param name="lastVerifyDate"></param>
        /// <returns></returns>
        public ServiceOutput<IncidentReturnSet> Incident(string distrito, string concelho, string localidade, long lastVerifyDate)
        {
            //TimeSpan _span = new TimeSpan(lastVerifyDate);
            DateTime _now = new DateTime(lastVerifyDate);
            if(lastVerifyDate > 1 )
                _now = _now.Subtract(new TimeSpan(0, 0, 0, 4));

            ConsultIndicent criteria = new ConsultIndicent()
            {
                Concelho = concelho,
                Distrito = distrito,
                Localidade = localidade,
                LastVerifyDate = lastVerifyDate > 0 ? _now : (DateTime?)null
            };

            ServiceOutput<IncidentReturnSet> _returns = GetIncidentsOperations.GetIncidents(criteria);

            return _returns;
        }

        public ServiceOutput<String> User(UpdateAdministrator updated)
        {

            try
            {
                if (updated == null)
                    throw new ForgetTrafficError("Parameter criteria is null", ManagementErrors.PARAMETERS_ERROR, "Parameter is required");
                if (String.IsNullOrEmpty(updated.LoginToken))
                    throw new ForgetTrafficError("User Does Passing Login token", ManagementErrors.LOGIN_TOKEN_REQUIRED, "Login token is required");
            
                //Vou actualziar os users
                if (updated.User != null && updated.User.Count > 0)
                {
                    SecurityUtils.ApplyCredentialCurrentThread(updated.LoginToken);

                    ServiceOutput<String> outParam = UserAdministration.UpdateUserProfile(updated.User[0]);
                    if (!outParam.Error)
                    {
                        GeneralManager.Commit();
                    }

                    return new ServiceOutput<string>()
                               {
                                   Error = outParam.Error,
                                   Description = outParam.Description,
                                   Title = outParam.Title
                               };
                }
                if (updated.Configuration != null)
                {
                    SecurityUtils.ApplyCredentialCurrentThread(updated.LoginToken);
                    ServiceOutput<String> outParam = Configuration.UpdateConfiguration(updated.Configuration);
                    if (!outParam.Error)
                    {
                        GeneralManager.Commit();
                    }
                    return new ServiceOutput<string>()
                               {
                                   Error = outParam.Error,
                                   Description = outParam.Description,
                                   Title = outParam.Title
                               };

                }
            }
            catch (AuthenticationException ex)
            {
               return new ServiceOutput<String>()
                {
                    Error = true,
                    Description = ex.Message,
                    StatusCode = ManagementErrors.UNAUTHORIZED_ACTION,
                    Title ="You dont have permition to do this"
                };
            }
             catch (ForgetTrafficError ex)
            {
                return new ServiceOutput<String>()
                            {
                                Error = true,
                                Description = ex.Message,
                                StatusCode = ex.Status,
                                Title = ex.Title
                            };
            }
            catch (Exception ex)
            {
                return new ServiceOutput<String>()
                {
                    Error = true,
                    Description = ex.Message,
                    StatusCode = ManagementErrors.UNDEFINED_ERROR,
                    Title = "Undefined Error"
                };
            }
            
           
             return new ServiceOutput<string>()
                           {
                               StatusCode = ErrorConsts.ParameterEmptyNull,
                               Error = true,
                               Description = "Parameters are empty or null"
                           };
            
            
        }

        public ServiceOutput<ListItensSet> User(FilterItens criteria)
        {
            ListItensSet retunr = new ListItensSet(){};
            ServiceOutput<ListItensSet> _return = new ServiceOutput<ListItensSet>();
            try
            {
                if (criteria == null)
                    throw new ForgetTrafficError("Parameter criteria is null", ManagementErrors.PARAMETERS_ERROR, "Parameter is required");
                if (String.IsNullOrEmpty(criteria.LoginToken))
                    throw new ForgetTrafficError("User Does Passing Login token", ManagementErrors.LOGIN_TOKEN_REQUIRED, "Login token is required");


                SecurityUtils.ApplyCredentialCurrentThread(criteria.LoginToken);
                //Vou adminnistrar os utilizadores
                if (criteria.Users != null)
                {
                    AdminUser userAdmin = UserAdministration.GetUsersForAdmin(criteria.Users);
                    if (userAdmin == null)
                        throw new Exception("Error whrn try to fill user");
                    List<AdminUser> users = new List<AdminUser>();
                    users.Add(userAdmin);

                    retunr.Users = users;
                    _return = new ServiceOutput<ListItensSet>() { Value = retunr, Description = "Users for admin are returned" };
                }
                //Vou administrar as configurações
                if (criteria.Configuration != null)
                {

                    AdminConfiguration configuration = Configuration.GetConfiguration(criteria.Configuration);
                    if (configuration == null)
                        throw new Exception("Error when try get information about system configuration ");
                    retunr.Configuration = configuration;
                    _return = new ServiceOutput<ListItensSet>() { Description = "The System configuration are sucessed returned", Value = retunr };
                }

            }
            catch (AuthenticationException ex)
            {
                return new ServiceOutput<ListItensSet>()
                {
                    Error = true,
                    Description = ex.Message,
                    StatusCode = ManagementErrors.UNAUTHORIZED_ACTION,
                    Title ="You dont have permition to do this"
                };
            }
            catch (ForgetTrafficError ex)
            {
                return new ServiceOutput<ListItensSet>()
                            {
                                Error = true,
                                Description = ex.Message,
                                StatusCode = ex.Status
                            };
            }
            return _return;
        }

        public ServiceOutput<UserInfo> LogOn(LoginInfo login)
        {

            if (String.IsNullOrEmpty(login.UserName) || String.IsNullOrEmpty(login.Password))
            {

                return new ServiceOutput<UserInfo>()
                {
                    Error = true,
                    Description = "The user or password are empty or null! Please verify this parameters"
                };
            }
            //var json_serializer = new JavaScriptSerializer();
            //MyObj routes_list = json_serializer.Deserialize<MyObj>("{ \"test\":\"some data\" }");
            ServiceOutput<UserInfo> _out = AccountOperations.GetUserInfoByCredentials(login.UserName, login.Password);

            GeneralManager.Commit();
            return _out;
        }

       

        public ServiceOutput<string> LogOn(ResendPassword infoResend)
        {
            

          return  new ServiceOutput<string>(){Description = "This operation is under construction",Error = true };
        }

        public ServiceOutput<UserInfo> EmailConfirmation(string token)
        {
           
            try
            {
                ServiceOutput<tblUser> _user = ConfirmationsViaEmail.ConfirmationUserRegistration(token);

                GeneralManager.Commit();

                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://www.forgettraffic.net/docs/html/welcome_to_forget_about_traffic.html");
            }
            catch (Exception)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://www.forgettraffic.net/docs/html/Error_register.html");
            }
      
            return null;
        }


        public void EmailConfirmation(EmailOperations op)
        {
           
        }
    }
}
