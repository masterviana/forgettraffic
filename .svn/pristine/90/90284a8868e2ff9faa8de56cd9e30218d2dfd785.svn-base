using System.Linq;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class IncidentTypeMananger
    {
        private static IRepository<tblOccurrenceType> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblOccurrenceType>>(); }
        }

        public static tblOccurrenceType GetTrafficOccorrence(int incidentType)
        {
            var value = (int) incidentType;

            tblOccurrenceType _type = _repository.Find(x => x.CodOccurrenceType == value).First();

            if (_type == null) return null;
            else
                return _type;
        }

        public static  tblOccurrenceType GetTypeOrDefault(int type)
        {
            tblOccurrenceType ret = _repository.Find(x => x.CodOccurrenceType == type).First();
            if (ret == null)
                ret = _repository.Find(x => x.CodOccurrenceType == SysCodes.TypeByDefault).First();
            return ret;
        }
    }
}