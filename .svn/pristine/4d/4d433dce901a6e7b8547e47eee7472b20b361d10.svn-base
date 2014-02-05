using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using ForgetTraffic.Autentication.Secutity;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Error;

namespace ForgetTraffic.Autentication.AppSecurity
{
    public class SecurityUtils
    {


        public static void ApplyCredentialCurrentThread(String loginToken)
        {
            tblUser user = ValidationTokenManager.GetUserByValidTokenLogin(loginToken);
            if( user == null)
                throw new ForgetTrafficError("Problem when try acessing user with login token", ManagementErrors.IMPOSSIBLE_GET_USER_WITH_THIS_LOGIN_TOKEN , "Getting the user");

            IPrincipal principal = new UserPrincipal(user.UserName);
            Thread.CurrentPrincipal = principal;

        } 

    }
}
