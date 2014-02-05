using System;
using System.Collections.Generic;
using System.Linq;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Incidents;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  25-05-2011  
     *              Name         :  IncidenceManager
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */

    public class IncidenceManager
    {
        private static IRepository<tblIncident> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblIncident>>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="occur"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static ServiceOutput<tblIncident> AddIncidence(AddIncident occur, tblUser user)
        {
            //Get the type of traffic incident

            DateTime createDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            //Era usado para 
            ////Caso o fim da incidencia não tenha sido definido
            //if( occur.EndDate == null && (occur.EndDateTicks <= 0) )
            //{
            //    endDate = createDate.Add(Consts.DefaultEndDateTime);
            //}
            //// Verifico se a endDate não vem definida como miliseconds
            //else
            //{
            //    if (occur.EndDate.HasValue)
            //        endDate = occur.EndDate.Value;
            //    if( occur.EndDateTicks > 0  )
            //    {
            //        endDate =  new DateTime(occur.EndDateTicks);
            //    }
            //}


            //Testar se o pais existe ou nao na nossa tabela)
            if(!CountryManager.CountryCodeExist(occur.CodePais.Trim()))
                return new ServiceOutput<tblIncident>() {Error =true,Description = "The County Code Dont Exist on System"};
            tblIncident _incidente;
            try
            {

                //Preencher o pais e a localização
                tblCountry country = CountryManager.GetCountryByCode(occur.CodePais.Trim()); 
                tblLocalization localization = new tblLocalization()
                                                   {
                                                       tblCountry =  country,
                                                       County = occur.Concelho,
                                                       Locality = occur.Localidade,
                                                       District = occur.Distrito,
                                                       Adress = occur.Adress,
                                                       PostalCode = occur.CodePostal,
                                                       LocalizationID = Guid.NewGuid()
                                                   };
                //Preenchar a tabela das cordenadas
                tblCoordinates coord = new tblCoordinates()
                                           {
                                               Latitude = occur.Coordinates.Latitude,
                                               Longitude = occur.Coordinates.Longitude
                                           };
                //Preencher a tabela da severidade
                tblSeverityKind severity = SeverityManager.GetSeverityOrDefault(occur.Severity);
                //Estimar a data final da incidente de acordo com o se tippo
                endDate = endDate.AddMinutes(severity.SeverityDefaultTimeMinutes);
                String toString = endDate.ToString("G");

                //Preenchar o tipo da incidencia
                tblOccurrenceType type = IncidentTypeMananger.GetTypeOrDefault(occur.Type);

                 _incidente = new tblIncident
                                     {
                                         SYS_CREATE_DATE = createDate,
                                         EstimatedEndDate =  endDate ,
                                         Description = occur.Description,
                                         IncidentID = Guid.NewGuid(),
                                         UserID = user.UserId,
                                         tblOccurrenceType = type,
                                         Title = occur.Title,
                                         tblSysState = StatusManager.GetByCodeAndParent(SysCodes.StActive,SysCodes.SysStates),
                                         tblSeverityKind   = severity,
                                         tblUser = user,
                                         tblLocalization = localization,
                                         tblCoordinates = coord

                                     };


                _repository.Add(_incidente);
            }
            catch (Exception ex)
            {

               return new ServiceOutput<tblIncident>(){Error = true,Description = ex.Message,Title = "Problem when try added on BD"};
            }

            return new ServiceOutput<tblIncident>()
                       {
                           Error = false,
                           Description = "Incident is added on system",
                           Value = _incidente
                       };
        }


        public static List<tblIncident> Find(Func<tblIncident, bool> where)
        {
            List<tblIncident> _ret = new List<tblIncident>();
            try
            {
                _ret =_repository.Find(where).ToList() ;
            }
            catch (Exception  ex)
            {
                
                throw ex;
            }

            return _ret;
        }


        public static tblIncident GetIncidentById(String id)
        {

            Guid guid = new Guid(id);
            var queryable = _repository.GetQuery ( ).Where (  x=> x.IncidentID == guid   ).First();
            return queryable;
        }

        public static bool UserMakeSpam( tblUser user)
        {

            DateTime now = DateTime.Now ;
            TimeSpan subTime = new TimeSpan(0,1,0,0);
            DateTime lowDate = now.Subtract(subTime);

            int count = _repository.Find(x => (x.SYS_CREATE_DATE > lowDate && x.SYS_CREATE_DATE < now) && x.tblUser.UserId.Equals(user.UserId) ).Count();

            tblConfiguration config = ConfigurationManager.GetConfiguration();
            int maxPerHour = config == null || !config.UserSpanRuleHours.HasValue ? 4 : config.UserSpanRuleHours.Value;

            return  count >=  maxPerHour;

        }

    }
}