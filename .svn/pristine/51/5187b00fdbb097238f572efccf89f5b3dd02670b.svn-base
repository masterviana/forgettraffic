using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using ForgetTraffic.Autentication;
using ForgetTraffic.Autentication.Secutity;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.RestTypes.Admin;
using ForgetTraffic.DataTypes.RestTypes.Users;

namespace ForgetTraffic.Adminstration
{
    public class UserAdministration
    {

        [Permission(System.Security.Permissions.SecurityAction.Demand, Name = SecurityPermition.ExcuteAdministrator)]
        public static AdminUser GetUsersForAdmin(FilterUser criteria)
        {

            //Sacar tods as informações do utilizar mais os seus rolos
            tblUser user;
            AdminUser retUser = null;

            try
            {
                user = UserManager.GetUser(criteria.Username, Guid.Empty);
                if (user != null)
                {
                    retUser = new AdminUser();
                    ResponseUser profiler = UserProfileOperations.GetRatioForUser(user);
                    retUser.BirthDate = user.BirthDate;
                    retUser.Email = user.Email;
                    retUser.Ratio = profiler.Ratio;
                    retUser.ReporedtIncident = profiler.ReporedtIncident;
                    retUser.PositiveIncidents = profiler.PositiveIncidents;
                    retUser.NegativeIncidents = profiler.NegativeIncidents;
                    retUser.UserName = user.UserName;
                    retUser.FirstName = user.FirstName;
                    retUser.CodState = user.SYS_STATE;

                    //Sacar o rolo que está associado
                    tblRole role = RoleManager.GetRoleForUSer(user);
                    if (role != null)
                    {
                        retUser.CodUserRole = role.CodRole;
                        retUser.DescrUserRole = role.RoleDescription;

                        ////Testar se o rolo é de administracao caso afirmativo actualizar o profile do user
                        //if( role.CodRole == 5 )
                        //{
                        //    tblUserProfile profile = UserProfileManager.GetUserProfile(user);
                        //    if (profile != null)
                        //        profile.IsAdmin = true;
                        //}
                    }

                    return retUser;

                }

            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }

       [Permission(System.Security.Permissions.SecurityAction.Demand, Name = SecurityPermition.ExcuteAdministrator)]
        public static ServiceOutput<String> UpdateUserProfile(UserAdminUpdate userUpdate)
        {
            try
            {
                //Testar se os estados
                tblSysState estado = StatusManager.GetByCodeAndParent(userUpdate.CodNewStatus.Trim(), SysCodes.SysStates);
                if( estado == null )return new ServiceOutput<string>(){Error = true,Description = "The Request New State for the User doest exist."};
                //Testar se os estados estao corectos
                tblRole role = RoleManager.GetRoleForCode(userUpdate.CodNewRole);
                if (role == null) return new ServiceOutput<string>() { Error = true, Description = "The Request New Role for the User doest exist." };

                tblUser user;
                user = UserManager.GetUser(userUpdate.UserName, Guid.Empty);
                
                if(user != null)
                {
                    user.tblRole = role;
                    user.SYS_STATE = userUpdate.CodNewStatus.Trim();

                }
                else
                {
                  return   new ServiceOutput<string>(){Error = true,Description = "The username doesnt exist on system",Title = "Username not valid"};
                }

                return new ServiceOutput<string>(){Description = "User Profile updated",Title = "Updaded"};
            }
            catch (Exception)
            {
                
                throw;
            }

        }


    }
}
