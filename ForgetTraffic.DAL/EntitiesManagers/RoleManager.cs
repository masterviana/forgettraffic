using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class RoleManager
    {
        private static IRepository<tblRole> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblRole>>(); }
        }

        public static  tblRole GetRoleForUSer( tblUser user )
        {
            return user.tblRole;
        }

        public static tblRole GetDefaultRole()
        {
            return _repository.Single(x => x.CodRole == SysCodes.RoleUtilizadores);
        }

        public static  tblRole GetRoleForCode(int CodRole)
        {
            return _repository.Find(x => x.CodRole == CodRole).First();
        }

        public static List<String> GetUsersInRole( string roleName )
        {
            tblRole role = _repository.Single(x => x.RoleTitle.Equals(roleName.Trim(), StringComparison.InvariantCultureIgnoreCase));

            List<String> users= role.tblUser.Select(x => x.UserName).ToList();
            return users;
        }

        //public static List<String> GetUsersInRole(String roleName)
        //{
        //    List<String> users = new List<String>();

        //    foreach (var role in _repository.GetAll())
        //    {
        //        if (role.RoleTitle.Trim().Equals(roleName.Trim()))
        //        {
        //            users = role.tblUser.Select(x => x.UserName.Trim()).ToList();
        //        }
        //    }
        //    return users;
        //}

        public static List<String> GetAllRoles()
        {
            List<String> roles = _repository.GetAll().Select(x => x.RoleTitle).ToList();
            return roles;
        }

        

        public static bool IsUserInRole(string username, string roleName)
        {
            tblRole role = _repository.Single(x => x.RoleTitle.Trim().Equals(roleName.Trim()));
            if (role == null) return false;

            tblUser user = role.tblUser.First(x => x.UserName.Trim().Equals(username));
            if (user == null) return false;

            return user.UserName.Trim().Equals(username.Trim(),StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool RoleExist(String roleName)
        {
            tblRole role =
                _repository.Single(
                    x => x.RoleTitle.Trim().Equals(roleName.Trim(), StringComparison.InvariantCultureIgnoreCase));

            return role != null;
        }


        public static List<String> GetAllPermitionForOneRole(String role)
        {
            tblRole tblRole = _repository.Single(x => x.RoleTitle.Equals(role));

            List<String> permition = tblRole.tblPermission.Select(p => p.PermissionTitle).ToList();

            return permition;
        }




    




    }
}
