using System.Collections.Generic;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Incidents;

namespace ForgetTraffic.TrafficIncidences
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  25-05-2011  
     *              Name         :  FactoryValidateCordinates
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */


    public class FactoryValidateIncident : IOccurExist<tblIncident, AddIncident>
    {
        private static FactoryValidateIncident _singleton;
        private readonly List<IOccurExist<tblIncident, AddIncident>> _validateList;

        private FactoryValidateIncident()
        {
            _validateList = new List<IOccurExist<tblIncident, AddIncident>>
                                {
                                    new ValidadeOccurCoordinates()
                                };
        }

        #region IOccurExist<tblTrafficOcurrence,Incident> Members

        public void SetIncident(AddIncident incident)
        {
            foreach (var occurExist in _validateList)
            {
                occurExist.SetIncident(incident);
            }
        }

        public bool VerifyIfAlreadyExist(tblIncident occur)
        {
            bool _retVal = true;
            foreach (var occurExist in _validateList)
            {
                _retVal &= occurExist.VerifyIfAlreadyExist(occur);
            }
            return _retVal;
        }

        #endregion

        public static FactoryValidateIncident SINGLETON()
        {
            return _singleton ?? (_singleton = new FactoryValidateIncident());
        }
    }
}