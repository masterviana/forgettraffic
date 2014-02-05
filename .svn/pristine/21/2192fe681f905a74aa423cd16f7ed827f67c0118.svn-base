using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class ConfigurationManager
    {

        private static IRepository<tblConfiguration> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblConfiguration>>(); }
        }


        public static tblConfiguration GetConfiguration()
        {
            return _repository.Single(x => x.SYS_STATUS.Equals("A", StringComparison.InvariantCultureIgnoreCase));
        } 


        public static bool UpdatedConfiguratByCode( tblConfiguration updateConfig )
        {

            tblConfiguration config =
                _repository.Single(x => x.SYS_STATUS.Equals("A", StringComparison.CurrentCultureIgnoreCase));
            if (config == null) return false;

            config.AlgormitDefaultTimeInterval = updateConfig.AlgormitDefaultTimeInterval;
            config.LoginTokenValidationTime = updateConfig.LoginTokenValidationTime;
            config.UserSpanRuleHours = updateConfig.UserSpanRuleHours;
            config.FirsStepRatioAlert = updateConfig.FirsStepRatioAlert;
            config.SecondStepRationAlert = updateConfig.SecondStepRationAlert;
            config.NegativeWeigthVotes = updateConfig.NegativeWeigthVotes;

            return true;
        }
    }
}
