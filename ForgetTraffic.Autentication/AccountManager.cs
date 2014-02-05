using System;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.ServiceUtils;

namespace ForgetTraffic.Autentication
{
    /**********************************************************************
        *
        *  Class Name      : AccountManager
        *  
        *  Description     : Manage the user account 
        * -------------------------------------------------------------------
        *  Date Created    : 28-03-2011
        *  
        *  Created By      : Vitor Viana 
        * -------------------------------------------------------------------
        *  Copyright © 2011 - ISEL,Projecto Final
        * -------------------------------------------------------------------
        *  Revision History Log
        *  Date   Author          Description
        *  _______ ______________ ___________________________________________
        *  xxxxxxx xxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        * 
        **********************************************************************/

    public class AccountManager
    {
        #region Create Users

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="birthDate"></param>
        /// <param name="secondEmail"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ServiceOutput<tblUser> CreateUser(
            String userName,
            String firstName,
            String lastName,
            String email,
            String birthDate,
            String secondEmail,
            String state
            )
        {
            if (userName == null) throw new ArgumentNullException("userName cant be null or empty");
            if (firstName == null) throw new ArgumentNullException("firstName cant be null or empty");
            if (lastName == null) throw new ArgumentNullException("lastName cant be null or empty");
            if (email == null) throw new ArgumentNullException("email cant be null or empty");

            return UserManager.CreateUser(userName, firstName, lastName, email, birthDate, secondEmail,state );
        }


        public tblUserProvider CreateUpdateProviderUserProvider(
            String username,
            Guid idUser,
            String password,
            String secretQuestion,
            String secretAnwser
            )
        {
            ComputeResult result = CrypytUtils.ComputeHash(password,  ForgetTraffic.DataTypes.Consts.HashAlgoritm, null);

            //O user ainda estava em memoria por isso ainda não existia
            //tblUser user =  UserManager.GetUser(null, idUser);
            //if (user == null) throw new Exception( String.Format("User {0} with id {1} doesnt exist on the system or are deactived ",user,idUser));

            return UserProviderMananger.AddUserProvider
                (
                    idUser,
                    result.HashValue,
                    secretQuestion,
                    secretAnwser,
                    result.SaltHash
                );
        }

        #endregion

        #region Delete Section

        //public void DeactiveUser(String username)
        //{
        //    tblUser _user = UserManager.GetUser(username, Guid.Empty);
        //    if (_user == null)
        //        throw new Exception(String.Format("O utilizador com o username {0} não existe no sistema!", username));


        //    UserManager.UpdateUser(username, Guid.Empty, null, "X");
        //    UserProviderMananger.UpdateProvider(_user, Guid.Empty, null, "X");
        //}

        #endregion
    }
}