using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class CountryManager
    {
        private static IRepository<tblCountry> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblCountry>>(); }
        }

        public static tblCountry GetCountryByCode(String countryCode)
        {
            tblCountry country = _repository.Single(x => x.CountryCode.Trim().ToLower().Equals(countryCode.Trim().ToLower(), StringComparison.InvariantCultureIgnoreCase));
            return country;
        }

        public static bool CountryCodeExist(String countryCode)
        {
            tblCountry country = _repository.Single(x => x.CountryCode.Trim().ToLower().Equals(countryCode.Trim().ToLower(), StringComparison.InvariantCultureIgnoreCase));
            return country != null;
        }

        public static tblCountry GetCountyByID(int a)
        {
            return _repository.Single(x => x.CountryID == a);
        }

    }
}
