using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Security;
using ForgetTraffic.DAL.EntitiesManagers;

namespace ForgetTraffic.Autentication.Secutity
{
    public class RolesManagement : RoleProvider
    {
        public RolesManagement() { }

       

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            //adicionar na base de dados..
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            //criar na base de dados
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            //Apagar na base de dados
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return RoleManager.GetAllRoles().ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            return UserManager.GetRolesForUser(username).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return RoleManager.GetUsersInRole(roleName).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return RoleManager.IsUserInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return RoleManager.RoleExist(roleName);
        }
    }
}
