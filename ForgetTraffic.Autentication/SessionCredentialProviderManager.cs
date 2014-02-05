using System;
using System.Collections.Generic;
using System.Linq;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.ServiceUtils;

namespace ForgetTraffic.Autentication
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  31-05-2011  
     *              Name         :  SessionCredentialProviderManager
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */

    public class SessionCredentialProviderManager
    {
        private const double AllocationTimeHour = 2;
        private static int _comunitationLimit = 2;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static ServiceOutput<tblValidationToken> CreateTokenForUserRequest(String user, String pass)
        {
            tblValidationToken ret;

            ServiceOutput<tblUser> _user;
            tblUserProvider _provider;

            if (!(_user = ValidateUserExistent(user, pass)).Error)
            {
                _provider = UserProviderMananger.GetActiveProvider(_user.Value, Guid.Empty);
                _provider.LastLoggegDate = DateTime.Now;
                _provider.Islogged = true;
                _provider.LoginCount++;


                //No caso de ainda haver um token que seja válido para este user;
                if ((ret = GetTokenIfExist(_user.Value).Value) != null)
                {
                    return new ServiceOutput<tblValidationToken>
                               {
                                   Error = false,
                                   Value = ret,
                                   Description = "User token is valid"
                               };
                }

                DateTime _now = DateTime.Now;
                String computeString = _user.Value.UserName + ";" + _provider.PassHash + ";" + _now.ToShortTimeString() +
                                       ";";
                ComputeResult result = CrypytUtils.ComputeHash(computeString, ForgetTraffic.DataTypes.Consts.HashAlgoritm, null);

                byte[] saltPass = result.SaltHash;
                String hashValue = result.HashValue;

                DateTime _expirationDate = _now.AddHours(AllocationTimeHour);

                //Actualizar o profile do user
                tblUserProfile _profile =  UserProfileManager.GetUserProfile(_user.Value);
                _profile.LoginCount += ForgetTraffic.DataTypes.Consts.PointsForLogin;
                _profile.SYS_LAST_MODIFY_DATE = DateTime.Now;
                

                tblValidationToken token =  ValidationTokenManager.Create(
                                                                                _expirationDate,
                                                                                _user.Value.UserId,
                                                                                computeString,
                                                                                hashValue,
                                                                                _comunitationLimit
                                                                            );


                return new ServiceOutput<tblValidationToken>
                           {
                               Value = token,
                               Error = false,
                               Description = "Invalid Token"
                           };
            }
            else
            {
                return new ServiceOutput<tblValidationToken>
                           {
                               Error = true,
                               Description = _user.Description,
                               Title = _user.Title
                           };
            }
        }


        public static ServiceOutput<tblValidationToken> GetTokenIfExist(tblUser user)
        {
            List<tblValidationToken> tokenList = ValidationTokenManager.Find(
                t =>
                t.ExperitionTime > DateTime.Now
                && t.UserId == user.UserId
                ).OrderBy(t => t.SYS_CREATE_DATE).ToList();


            if (tokenList.Count != 1)
                return new ServiceOutput<tblValidationToken>
                           {
                               Error = true,
                               Description = "Doesnt exist any user token active for the user "+user.UserName
                           };
            else
            {
                return new ServiceOutput<tblValidationToken>
                           {
                               Error = false,
                               Value = tokenList[0]
                           };
            }
        }


        /// <summary>
        /// Testa se o utilizador e a password do pedido é válido!
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static ServiceOutput<tblUser> ValidateUserExistent(String username, String pass)
        {
            ServiceOutput<tblUser> _value;

            tblUser user = UserManager.GetUser(username, Guid.Empty);

            if (user == null)
                return new ServiceOutput<tblUser>
                           {
                               Title = String.Format("The user {0} doesnt exist on system", username),
                               Description = String.Format("Please use this operations for a valid user"),
                               Error = true
                           };


            tblUserProvider userProvider = UserProviderMananger.GetActiveProvider(user, Guid.Empty);

            bool hashVerify = CrypytUtils.VerifyHash(pass, ForgetTraffic.DataTypes.Consts.HashAlgoritm, userProvider.PassHash.Trim());
            bool userVerify = username.Trim().Equals(user.UserName.Trim());

            if (userVerify && hashVerify)
                _value = new ServiceOutput<tblUser>
                             {
                                 Error = false,
                                 Value = user
                             };
            else
            {
                _value = new ServiceOutput<tblUser>
                             {
                                 Error = true,
                                 Description = String.Format("Invalid passor to user {0}. Please try again", username)
                             };
            }

            return _value;
        }
    }
}