using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using ForgetTraffic.AnsycLibrary;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.Interfaces;

namespace ForgetTraffic.TrafficIncidences.SolveIncidents
{
    /// <summary>
    /// Class que gere as incidencias! No caso de já teram sido resolvidas!
    /// 
    /// </summary>
    public class GenericService : IGenericService<tblIncident>
    {
        public void Solve(tblIncident tInput, Object obj)
        {

            DateTime _nowDate = DateTime.Now;
            //Resolver todas as incidencias que tenhm já passado o endDate
            List<tblIncident> endTimeIncidents = IncidenceManager.Find(
                                                                             x =>
                                                                                      x.tblSysState.Id == ForgetTraffic.DAL.EntitiesManagers.StatusManager.GetByCodeAndParent(SysCodes.StActive, SysCodes.SysStates).Id
                                                                                      && ( _nowDate > x.EstimatedEndDate)
                                                                           );

            List<tblIncident> negativeVotos = IncidenceManager.Find(
                                                                        x =>
                                                                                      x.tblSysState.Id == ForgetTraffic.DAL.EntitiesManagers.StatusManager.GetByCodeAndParent(SysCodes.StActive, SysCodes.SysStates).Id
                                                                                      && GotMoreOfFive(x)
                                                                    );


            //Agora vou colocar essas incidencias marcadas como 'Anuladas'
            foreach (var incident in endTimeIncidents)
            {
                incident.SYS_LAST_MODIFY_DATE = DateTime.Now;
                incident.tblSysState = ForgetTraffic.DAL.EntitiesManagers.StatusManager.GetByCodeAndParent(SysCodes.StDelete, SysCodes.SysStates);
                UserOperations.UpdateUserProfile(incident);
            }

            //Vou anular as incidencias negativas mas tenh tambem de mandar mail para os utilizadores em certos casos
            foreach (var negativeVoto in negativeVotos)
            {
                negativeVoto.SYS_LAST_MODIFY_DATE = DateTime.Now;
                negativeVoto.tblSysState = ForgetTraffic.DAL.EntitiesManagers.StatusManager.GetByCodeAndParent(SysCodes.StDelete, SysCodes.SysStates);
                UserOperations.UpdateUserProfile(negativeVoto);
            }
            
        }


        private static bool GotMoreOfFive( tblIncident incident)
        {
            VoteInfo info=  IncidentVoteManager.GetVoteCountingByIncident(incident);
            bool ret = (info.Positive - info.Negative) > 4;
            return ret;
        }
    }



}
