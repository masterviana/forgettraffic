using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Incidents;

namespace ForgetTraffic.TrafficIncidences
{
    public class ValidadeOccurCoordinates : IOccurExist<tblIncident, AddIncident>
    {
        private AddIncident _incident;

        #region IOccurExist<tblTrafficOcurrence,Incident> Members

        public void SetIncident(AddIncident incident)
        {
            _incident = incident;
        }

        public bool VerifyIfAlreadyExist(tblIncident incident)
        {
            return incident.tblCoordinates.Latitude == _incident.Coordinates.Latitude
                && incident.tblCoordinates.Longitude == _incident.Coordinates.Longitude
                && incident.SYS_STATE == ForgetTraffic.DAL.EntitiesManagers.StatusManager.GetByCodeAndParent(SysCodes.StActive, SysCodes.SysStates).Id ;
        }

        #endregion
    }
}