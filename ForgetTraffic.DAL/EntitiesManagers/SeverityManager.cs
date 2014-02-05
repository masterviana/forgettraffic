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
    public class SeverityManager
    {

        private static IRepository<tblSeverityKind> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblSeverityKind>>(); }
        }

        public static tblSeverityKind GetSeverityByCode(int codSeverity)
        {
            return _repository.Single(x => x.SeverityCode == codSeverity);
        }

        public static tblSeverityKind GetSeverityOrDefault(int codSeverity)
        {
            tblSeverityKind severityKind =  _repository.Single(x => x.SeverityCode == codSeverity);

            if (severityKind == null)
                severityKind = _repository.Single(x => x.SeverityCode == SysCodes.SeverityByDefault);

            return severityKind;
        }

        public static List<tblSeverityKind> GetAllSeveritys()
        {
            List<tblSeverityKind> list = new List<tblSeverityKind>(_repository.GetAll() );

            return list;
        }

        public static bool UpdateForCode(tblSeverityKind sererity , int code)
        {
            tblSeverityKind sv = _repository.Single(x => x.SeverityCode == code);
            if (sv == null) return false;
            sv.SeverityDefaultTimeMinutes = sererity.SeverityDefaultTimeMinutes;
            return true;
        }
    }
}
