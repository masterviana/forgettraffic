using System;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Error;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Users;
using ForgetTraffic.ServiceUtils;

namespace ForgetTraffic.Autentication
{
    public class AccountOperations
    {
        public static ServiceOutput<UserInfo> GetUserInfoByCredentials(String username, String pass)
        {
            ServiceOutput<tblValidationToken> _out = SessionCredentialProviderManager.CreateTokenForUserRequest(username, pass);

            if (!_out.Error)
            {
                //tblUser _user = ValidationTokenManager.GetUserByValidTokenLogin(_out.Value.ValidationToken);
                tblUser _user   = UserManager.GetUser(username, Guid.Empty);
                tblRole profile;
                
                if (_user == null)
                    return new ServiceOutput<UserInfo>
                               {
                                   Error = true,
                                   Description = "Problems to load user token " + _out.Value
                               };
                profile = RoleManager.GetRoleForUSer(_user);
                //Verificar se está no estado activo)
                if(!_user.SYS_STATE.Equals(SysCodes.StActive))
                {
                    return new ServiceOutput<UserInfo>()
                               {
                                   Error = true,
                                   Description = "The user "+_user.UserName+" is dont ACTIVE on system. Please check if the state or validate the link on email",
                                   Title = "The user is not in 'ACTIVE' state"
                               };
                }

                return new ServiceOutput<UserInfo>
                           {
                               Value = new UserInfo
                                           {
                                               FirstName = _user.FirstName,
                                               LastName = _user.LastName,
                                               LoginToken = _out.Value.ValidationToken,
                                               UserName = username,
                                               IsAdmin = profile !=null  ? profile.CodRole == 5 : false
                                           },
                               Error = false
                           };
            }
            return new ServiceOutput<UserInfo>
                       {
                           Error = true,
                           Description = _out.Description,
                           Title = _out.Title
                       };
        }

        public static ServiceOutput<ResponseUser> CreateUser(AddUser userProfile)
        {
            ServiceOutput<ResponseUser> _return;

            try
            {
                var accountManager = new AccountManager();

                ServiceOutput<tblUser> userOutput = accountManager.CreateUser(userProfile.UserName, userProfile.FirstName, userProfile.LastName,
                                                        userProfile.Email,
                                                        userProfile.BirthDate, null, ForgetTraffic.DataTypes.SysCodes.StWaiting);


                //Se existir erros na criação do utilizador retorno logo
                if (userOutput.Error)
                {
                    throw new ForgetTrafficError(userOutput.Description, 503, "Error when create user");
                }


                tblUser user = userOutput.Value;

                if (String.IsNullOrEmpty(userProfile.ConfirmPassword)
                        || String.IsNullOrEmpty(userProfile.Password)) throw new ForgetTrafficError("Parameters are null", ManagementErrors.PARAMETERS_ERROR, "Parameters are empty/null");

                if (!userProfile.Password.Equals(userProfile.ConfirmPassword)) throw new ForgetTrafficError("The password and Confirm password dont are equals", ManagementErrors.PASSWORD_AND_CONFIRM_PASSWORD_NOT_EQUALS, "Password not are equals");


                tblUserProvider userProvider = accountManager.CreateUpdateProviderUserProvider( user.UserName,
                                                                                               user.UserId,
                                                                                               userProfile.Password,
                                                                                               userProfile.SecretQuestion,
                                                                                               userProfile.SecretAnswer);


               

                //Send a confirmation via email 
                ConfirmationsViaEmail.SendConfirmationEmail(user);

                _return = new ServiceOutput<ResponseUser>
                              {
                                  Value = new ResponseUser
                                              {
                                                  Email = user.Email,
                                                  BirthDate = user.BirthDate,
                                                  FirstName = user.FirstName,
                                                  LastName = user.LastName,
                                                  UserName = user.UserName
                                              }
                                  ,
                                  Description = String.Format("User {0} are create with sucess. Please check your email ", user.UserName)
                              };
            }
            catch (Exception ex)
            {
              throw  new ForgetTrafficError(ex.Message,502,"Error");
            }
            return _return;
        }


        public static ServiceOutput<ResponseUser> UpdateUserProfile(UpdateUser updateUser)
        {

            ServiceOutput<ResponseUser> _return;

            tblUser tryUser = null;
            try
            {
                var accountManager = new AccountManager();

                 tryUser = ValidationTokenManager.GetUserByValidTokenLogin(updateUser.LoginToken.Trim());
                if (tryUser == null)
                {
                    return new ServiceOutput<ResponseUser>
                    {
                        Error = true,
                        Description = "LoginToken is invalid, try logon before submit incident",
                        Title = "Login token invalid"
                    };
                }

                //Testar se a password antiga corresponde realmente
                tblUserProvider userProvider =  UserProviderMananger.GetActiveProvider(tryUser, Guid.Empty);
                //Caso não exista nenhum provider para o utilizador activo vai ser lançado um erro para o serviço
                if(userProvider == null)
                    return new ServiceOutput<ResponseUser>()
                               {
                                   Description =
                                       String.Format("Its impossible obtain the credentials provider for the user {0}",
                                                     tryUser.UserName),
                                                     Error = true
                               };


                if( !String.IsNullOrEmpty( updateUser.Password))
                {
                    if( !updateUser.ConfirmPassword.Equals(updateUser.Password,StringComparison.CurrentCultureIgnoreCase))
                        return new ServiceOutput<ResponseUser>()
                                   {
                                       Error = true ,
                                       Description = "Passord and ConfirmPassword dont are equivalent"
                                   };

                    ComputeResult result = CrypytUtils.ComputeHash(updateUser.OldPassword, ForgetTraffic.DataTypes.Consts.HashAlgoritm, userProvider.PassSalt);

                    //if (result.HashValue != userProvider.PassHash)
                    //    return new ServiceOutput<ResponseUser>()
                    //    {
                    //        Description = String.Format("Impossible updade User profile because the old password and the new not equals! Please submit the correct old password for user"),
                    //        Error = true,
                    //        Title = "The old password is not correct"

                    //    };

                    result = CrypytUtils.ComputeHash(updateUser.Password, ForgetTraffic.DataTypes.Consts.HashAlgoritm, userProvider.PassSalt);
                    //Actualizar os dados do perfil do utilizador!
                    UserProviderMananger.UpdateProvider(tryUser, Guid.Empty, result.HashValue, result.SaltHash, SysCodes.StActive, updateUser.SecretQuestion, updateUser.SecretAnswer);

                    //Invalidar o Login token
                    ValidationTokenManager.MakeLoginTokenDirty(tryUser);

                }

                if (!string.IsNullOrEmpty(updateUser.SecretQuestion) || !string.IsNullOrEmpty(updateUser.SecretQuestion))
                {
                    UserProviderMananger.UpdateProvider(tryUser, Guid.Empty, null, null, SysCodes.StActive, updateUser.SecretQuestion, updateUser.SecretAnswer);
                }

                String displayName = tryUser.UserName;
                if(updateUser.HidenUserName)
                {
                    displayName = StringOperations.PrivacyName(displayName);
                }

                //Actualizar dados do perfile do utilizador!
                UserManager.UpdateUser(tryUser.UserName,tryUser.UserId,SysCodes.StActive,updateUser.FirstName,updateUser.LastName,updateUser.LastName,updateUser.BirthDate,displayName);

                //Actualizar o userProfile com o 
                UserProfileManager.UpdateUserProfile(tryUser, updateUser.HidenUserName);

                tryUser = UserManager.GetUser(tryUser.UserName, Guid.Empty);

            }
            catch (Exception ex)
            {

                new ServiceOutput<ResponseUser>()
                    {
                        Description = ex.Message,
                        Error = true,
                        Title = String.Format("Error when try update user {0}.Please check the atribute 'Descriton to found more information'", tryUser.UserName ?? "Undefined")
                    };

            }

            return new ServiceOutput<ResponseUser>()
            {
                Error = false,
                Description = "User profile Update with Sucess",
                Title = "Updaded with Sucess",
                Value = new ResponseUser()
                            {
                                BirthDate = updateUser.BirthDate,
                                Email = tryUser.Email,
                                FirstName = updateUser.FirstName,
                                LastName = updateUser.LastName,
                                UserName = tryUser.UserName
                            }
            };
        }


        public static ServiceOutput<ResponseUser> GetUserProfile(String loginToken)
        {
            tblUser _user;

            try
            {
                _user = ValidationTokenManager.GetUserByValidTokenLogin(loginToken);
                
                if(_user != null)
                {
                    ResponseUser profiler =  UserProfileOperations.GetRatioForUser(_user);
                    return new ServiceOutput<ResponseUser>()
                               {
                                   Value = new ResponseUser()
                                               {
                                                   BirthDate = _user.BirthDate,
                                                   Email = _user.Email,
                                                   FirstName = _user.FirstName,
                                                   LastName = _user.LastName,
                                                   UserName = _user.UserName,
                                                   NegativeIncidents = profiler.NegativeIncidents,
                                                   PositiveIncidents = profiler.PositiveIncidents,
                                                   Ratio = profiler.Ratio,
                                                   HideUserName = profiler.HideUserName,
                                                   ReporedtIncident = profiler.ReporedtIncident,
                                                   SubmitedVotes = profiler.SubmitedVotes
                        },
                        Error = false
                    };
                }
                else
                    {
                        return new ServiceOutput<ResponseUser>()
                                  {
                                      Description = "Error when try obatain the user for this token" + loginToken,
                                      Title = "Invalid Login Token ",
                                      Error = true
                                  };
                     }

            }
            catch (Exception ex)
            {

                return new ServiceOutput<ResponseUser>()
                           {
                               Error = true,
                               Description = ex.Message,
                               Title = "Error with login Token"
                           }; 
            }
            

            

        }

        /// <summary>
        /// Testa o token de login e verifica se utilizador tem permissoes para continuar a 
        /// executar codigo
        /// </summary>
        /// <param name="logginToken"></param>
        /// <returns></returns>
       public static bool  CheckCredentialsByToken (String logginToken )
       {
           

            return true;
       }

    }
}