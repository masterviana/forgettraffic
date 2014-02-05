using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.RestTypes.Users;

namespace ForgetTraffic.Autentication
{
    public class UserProfileOperations
    {
        /// <summary>
        /// Calcula o ratio de incidencias por utilizador
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static ResponseUser GetRatioForUser(tblUser user)
        {
            try
            {
                tblUserProfile profile =  UserProfileManager.GetUserProfile(user);
                ResponseUser ret = new ResponseUser();
                double rat;
                if(profile != null)
                {
                    ret.PositiveIncidents = profile.ValidateIncidents;
                    ret.NegativeIncidents = profile.InvalidatIncidents;
                    try
                    {
                        rat = (ret.NegativeIncidents + ret.PositiveIncidents);
                        rat = ret.PositiveIncidents / rat ;
                        rat *= 100;
                        ret.Ratio = (int)rat;
                    }
                    catch (System.DivideByZeroException ex)
                    {
                        ret.Ratio = 0;
                    }
                  
                    ret.HideUserName = profile.HiddenInformation ;
                    ret.ReporedtIncident = profile.SubimtIncidents;
                    ret.SubmitedVotes = profile.VotesCount; 

                }
                return ret;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

    }
}
