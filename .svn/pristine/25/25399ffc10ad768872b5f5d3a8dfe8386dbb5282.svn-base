using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Error;
using ForgetTraffic.Logger;
using Log = ForgetTraffic.Logger;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  25-05-2011  
     *              Name         :  UserManager
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */

    public class UserManager
    {
        private static IRepository<tblUser> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblUser>>(); }
        }


        public static ServiceOutput<tblUser> CreateUser(String userName, String firstName, String lastName, String email,
                                         String birthDate, String secondMail, String state)
        {

            


            tblUser _user = GetUser(userName, Guid.Empty);

            if (_user != null)
                return new ServiceOutput<tblUser>()
                           {
                               Error = true,
                               Description = "This user already exist on the system user " + userName
                           };

            //Testar se já existe o mail
            _user = _repository.Single(x => x.Email.Trim().Equals(email, StringComparison.InvariantCultureIgnoreCase));
            if(_user != null)
                return new ServiceOutput<tblUser>()
                           {
                               Error = true,
                               Description = String.Format("The email {0} already exist on system.", email)
                           };

            //Testar se o mail vem bem formatado
            if (!email.Contains("@") || !email.Substring(email.IndexOf("@")).Contains(".") )
            {
                return new ServiceOutput<tblUser>()
                {
                    Error = true,
                    Description = String.Format("The email {0} was not valid" , email)
                };
            }
            //Associar este utilizador a um rolo
            tblRole role = RoleManager.GetDefaultRole();

            List<tblRole> roles = new List<tblRole>();
            roles.Add(role);
      
            try
            {

                _user = new tblUser();
                _user.CreateDate = DateTime.Now;
                _user.Email = email;
                _user.FirstName = firstName;
                _user.LastName = lastName;
                _user.BirthDate = birthDate;
                _user.UserId = Guid.NewGuid();
                _user.SecondEmail = secondMail;
                _user.UserName = userName;
                _user.SYS_CREATE_DATE = DateTime.Now;
                _user.SYS_USER_CREATE = "application";
                _user.SYS_STATE = state;
                _user.tblRole = role;
                _user.DisplayName = userName;


                _repository.Add(_user);
                

                return new ServiceOutput<tblUser>()
                           {
                               Value = _user,
                               Description = "User create with sucess"
                           };
            }
            catch (Exception ex)
            {
                throw new ForgetTrafficError("Exception when added user to system", 500,
                                             "Create the user before commited");
            }
        }


        public static void UpdateUser
            (
                String username,
                Guid idUser,
                String state,
                String firstName,
                String lastName,
                String secondName,
                String birthDate,
                String displayUserName
            )
        {
            tblUser _user = GetUser(username, idUser);
            if (_user == null)
                throw new Exception("User does not exist on system. Please try update an exist user!");


            if (!String.IsNullOrEmpty(state)) _user.SYS_STATE = state;
            if (!String.IsNullOrEmpty(firstName)) _user.FirstName= firstName;
            if (!String.IsNullOrEmpty(lastName)) _user.LastName = lastName;
            if (!String.IsNullOrEmpty(secondName)) _user.SecondEmail = secondName;
            if (!String.IsNullOrEmpty(birthDate)) _user.BirthDate= birthDate;
            if (!String.IsNullOrEmpty(displayUserName)) _user.DisplayName= displayUserName;

            _user.SYS_LAST_UPDATE_DATE = DateTime.Now;
            _user.SYS_LAST_UPDATE_USER = "application";
        }

        /// <summary>
        /// Return user for two parameter search
        /// if one is null search by other
        /// </summary>
        /// <param name="username">username using in the search</param>
        /// <param name="idUser"> unique id for user </param>
        /// <returns></returns>
        public static tblUser GetUser(
            String username,
            Guid idUser
            )
        {
            if (username == null && idUser == Guid.Empty)
                return null;


            if (username != null && idUser != Guid.Empty)
                return _repository.Single(x =>
                                          x.UserId == idUser
                                          && x.UserName.Trim().Equals(username)
                    );

            return username == null
                       ? _repository.Single(x => x.UserId == idUser  )
                       : _repository.Single(x => x.UserName.Trim().Equals(username.Trim()));
        }


        public static ICollection<tblUser> Find(Func<tblUser, bool> where)
        {
            return new List<tblUser>(_repository.Find(where));
        }

        public static void Delete(tblUser user)
        {
            _repository.Delete(user);
        }


        public static List<String> GetRolesForUser(String username)
        {
            List<String> roles = new List<string>();
            
            tblUser user = GetUser(username, Guid.Empty);
            roles.Add(user.tblRole.RoleTitle);
            //foreach (var role in user.tblRole)
            //{
            //    roles.Add(role.RoleTitle);                
            //}
            //return roles;

            return roles;
        }
    }
}