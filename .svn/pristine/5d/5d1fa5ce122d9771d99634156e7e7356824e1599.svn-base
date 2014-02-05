using System;
using System.Collections.Generic;
using ForgetTraffic.Autentication;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataModel;

namespace ForgetTraffic.TrafficIncidences
{
    public class GetIncidentsOperations
    {
        #region Getting incidents

        public static ServiceOutput<IncidentReturnSet> GetIncidents(ConsultIndicent filter)
        {
          
            if( !AccountOperations.CheckCredentialsByToken(filter.LoginToken) )
                return new ServiceOutput<IncidentReturnSet>()
                           {
                               Error =true,
                               Description = "You need autentication for this operations please login on the system",
                               Title ="This loggin token are empty/null or is invalid"
                           };


            List<tblIncident> addeds = GetAddedIncidents(filter);
            List<tblIncident> Updateds = GetUpdatedIncidents(filter);
            List<tblIncident> Deletes = GetDeletedIncidents(filter);


            List<Incident> wrapperAdds = WrappeToIncidentList(addeds,filter.LoginToken);
            List<Incident> wrapperUpdates = WrappeToIncidentList(Updateds, filter.LoginToken);
            List<Incident> wrapperDeleteds = WrappeToIncidentList(Deletes, filter.LoginToken);

            DateTime _now = DateTime.Now;
            TimeSpan span = new TimeSpan(_now.Ticks);

            return new ServiceOutput<IncidentReturnSet>()
                       {
                           Value = new IncidentReturnSet()
                                       {
                                           AddedIncidents = wrapperAdds,
                                           RemovedIncidents = wrapperDeleteds,
                                           UpdatedIncidents = wrapperUpdates,
                                           LastVerifyDate = _now.Ticks
                                       },
                            Error = false,
                            Description = "The requested incedents are sended with sucess"
                       };
        }

        /// <summary>
        /// Retorna todas as incidencias adicionadas desde que o utilizador testou pela ultima vez
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static List<tblIncident> GetAddedIncidents(ConsultIndicent filter )
        {
            tblSysState activeState =  StatusManager.GetByCodeAndParent(SysCodes.StActive, SysCodes.SysStates);

            var list = new List<tblIncident>
                                                    (DAL.EntitiesManagers.IncidenceManager.Find(
                                                      x =>
                                                                        (String.IsNullOrEmpty(filter.Localidade)    || x.tblLocalization.Locality.Trim().Contains(filter.Localidade))
                                                                  &&    (String.IsNullOrEmpty(filter.Concelho)      || x.tblLocalization.County.Trim().Contains(filter.Concelho))
                                                                  &&    (String.IsNullOrEmpty(filter.Distrito)      || x.tblLocalization.District.Trim().Contains(filter.Distrito))
                                                                  &&    (String.IsNullOrEmpty(filter.Pais)          ||  x.tblLocalization.tblCountry.Country.Trim().Contains(filter.Pais))
                                                                  &&    GetActiveState(x.tblSysState)
                                                                  &&    ( filter.LastVerifyDate == null              || x.SYS_CREATE_DATE > filter.LastVerifyDate)
                                                     ));
            return list;
        }

        /// <summary>
        /// Get deleted incident since the last verify of user 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static List<tblIncident> GetDeletedIncidents(ConsultIndicent filter)
        {

            tblSysState inactiveState = StatusManager.GetByCodeAndParent(SysCodes.StDelete, SysCodes.SysStates);

            var list = new List<tblIncident>
                                         (DAL.EntitiesManagers.IncidenceManager.Find(
                                           x =>
                                                               (String.IsNullOrEmpty(filter.Localidade) || x.tblLocalization.Locality.Trim().Contains(filter.Localidade))
                                                       && (String.IsNullOrEmpty(filter.Concelho) || x.tblLocalization.County.Trim().Contains(filter.Concelho))
                                                       && (String.IsNullOrEmpty(filter.Distrito) || x.tblLocalization.District.Trim().Contains(filter.Distrito))
                                                        && (String.IsNullOrEmpty(filter.Pais) || x.tblLocalization.tblCountry.Country.Trim().Contains(filter.Pais))
                                                       && GetInactiveState(x.tblSysState)
                                                       && ( ( filter.LastVerifyDate != null && x.SYS_LAST_MODIFY_DATE != null ) && (  x.SYS_LAST_MODIFY_DATE.Value > filter.LastVerifyDate ) )
                                          ));


            return list;
        }

        private static List<tblIncident> GetUpdatedIncidents(ConsultIndicent filter)
        {
            tblSysState activeState = StatusManager.GetByCodeAndParent(SysCodes.StActive, SysCodes.SysStates);

            var list = new List<tblIncident>
                                                    (DAL.EntitiesManagers.IncidenceManager.Find(
                                                      x =>
                                                                         (String.IsNullOrEmpty(filter.Localidade) || x.tblLocalization.Locality.Trim().Contains(filter.Localidade))
                                                                  && (String.IsNullOrEmpty(filter.Concelho) || x.tblLocalization.County.Trim().Contains(filter.Concelho))
                                                                  && (String.IsNullOrEmpty(filter.Distrito)  || x.tblLocalization.District.Trim().Contains(filter.Distrito))
                                                                   && (String.IsNullOrEmpty(filter.Pais) || x.tblLocalization.tblCountry.Country.Trim().Contains(filter.Pais))
                                                                  &&  GetActiveState(x.tblSysState)
                                                                  && ( (filter.LastVerifyDate != null && x.SYS_LAST_MODIFY_DATE != null )  && (x.SYS_CREATE_DATE < filter.LastVerifyDate && x.SYS_LAST_MODIFY_DATE.Value  >  filter.LastVerifyDate)))
                                                     );


            return list;

        }
        #endregion 



        public static bool GetInactiveState( tblSysState state )
        {
            tblSysState inactive = StatusManager.GetByCodeAndParent(SysCodes.StDelete, SysCodes.SysStates);

            bool ret = inactive == state;
            return ret;
        }

        public static bool GetActiveState(tblSysState state)
        {
            tblSysState active = StatusManager.GetByCodeAndParent(SysCodes.StActive, SysCodes.SysStates);

            bool ret = active == state;
            return ret;
        }

        #region Wrapper to the Reponses types


        private static List<Incident> WrappeToIncidentList(List<tblIncident> list, String loginToken)
        {
            List<Incident> _returned = new List<Incident>();
            Incident incident;
            String date;
            tblUser user;
            foreach (var tblTrafficOcurrence in list)
            {
                date = tblTrafficOcurrence.SYS_CREATE_DATE.ToLongDateString();
                tblUserProfile profile = UserProfileManager.GetUserProfile(tblTrafficOcurrence.tblUser);
                incident = new Incident()
                               {
                                   CodIncident = tblTrafficOcurrence.IncidentID.ToString(),
                                   Concelho = tblTrafficOcurrence.tblLocalization.County ,
                                   Coordinates = new Cord()
                                                     {
                                                         Latitude = tblTrafficOcurrence.tblCoordinates.Latitude,
                                                         Longitude = tblTrafficOcurrence.tblCoordinates.Longitude
                                                     },
                                                     Description = tblTrafficOcurrence.Description,
                                                     Distrito = tblTrafficOcurrence.tblLocalization.District,
                                                     PublicationDate =tblTrafficOcurrence.SYS_CREATE_DATE,
                                                     Type = tblTrafficOcurrence.tblOccurrenceType.CodOccurrenceType  ,
                                                     Localidade = tblTrafficOcurrence.tblLocalization.Locality,
                                                     EndDate = tblTrafficOcurrence.EstimatedEndDate,
                                                     Title = tblTrafficOcurrence.Title,
                                                     UserName = tblTrafficOcurrence.tblUser.DisplayName,
                                                     Votes = IncidentVoteManager.GetVoteInfoWithUserInformation( tblTrafficOcurrence, loginToken),
                                                     UserRatio = profile.UserRatio, //UserProfileOperations.GetRatioForUser(tblTrafficOcurrence.tblUser).Ratio,
                                                     Severity = tblTrafficOcurrence.tblSeverityKind.SeverityCode
                               };
                _returned.Add(incident);
            }

            return _returned;
        }

        private static int GetIncidentType(int e)
        {
            //if (e == 0)
            //    return IncidentType.SlowTraffic;
            //if (e == 1)
            //    return IncidentType.MaintenanceStreet;
            //if (e == 2)
            //    return IncidentType.PoliceTrap;
            //if (e == 2)
            //    return IncidentType.Accident;

            return e;
        }
      


        #endregion



        public static void VoteVitor( tblOccurrenceType incident , tblUser user )
        {
            
                    //Numero de positvos
            // --------------------------------------    *   100
                    //Nº Positivos * Nº Negativos 
        }
    }
}