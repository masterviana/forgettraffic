using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.Autentication.Secutity;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.RestTypes.Admin;

namespace ForgetTraffic.Adminstration
{
    public class Configuration
    {
        [Permission(System.Security.Permissions.SecurityAction.Demand, Name = SecurityPermition.ExcuteAdministrator)]
        public static AdminConfiguration GetConfiguration(FilterConfigurations configuration)
        {
            if(configuration == null) return null;

            AdminConfiguration ret = new AdminConfiguration();
            List<SeverityConfig> ServerityTimes;
            if( configuration.AdminInfo )
            {
                tblConfiguration config = ConfigurationManager.GetConfiguration();
                List<tblSeverityKind> servirysList = SeverityManager.GetAllSeveritys();

                if( config != null )
                {
                    ret.AlgoritmTimeInterval = config.AlgormitDefaultTimeInterval.HasValue ? config.AlgormitDefaultTimeInterval.Value : -1;
                    ret.LoginTokenValidationTime = config.LoginTokenValidationTime.HasValue ? config.LoginTokenValidationTime.Value : -1;
                    ret.LowRationWarning = config.FirsStepRatioAlert.HasValue ? config.FirsStepRatioAlert.Value : -1;
                    ret.LowRatioUserDisable = config.SecondStepRationAlert.HasValue ? config.SecondStepRationAlert.Value : -1;
                    ret.UserSpamRoleForHour = config.UserSpanRuleHours.HasValue ? config.UserSpanRuleHours.Value : -1;
                    ret.NegativeWeigthVotes = config.NegativeWeigthVotes.HasValue ? config.NegativeWeigthVotes.Value : -1;
                }
                ServerityTimes = new List<SeverityConfig>();
                foreach (var serverity in servirysList)
                {
                    //ServerityTimes.Add(new SeverityConfig()
                    //                       {
                    //                           Cod = serverity.SeverityID,
                    //                           Descr = serverity.SeverityDescr,
                    //                           Time = serverity.SeverityDefaultTimeMinutes
                    //                       });
                    if( serverity.SeverityCode ==  0)
                        ret.Low =  new SeverityConfig()
                                               {
                                                   Cod = serverity.SeverityCode,
                                                   Descr = serverity.SeverityDescr,
                                                   Time = serverity.SeverityDefaultTimeMinutes
                                               };
                    if (serverity.SeverityCode == 1)
                        ret.High = new SeverityConfig()
                        {
                            Cod = serverity.SeverityCode,
                            Descr = serverity.SeverityDescr,
                            Time = serverity.SeverityDefaultTimeMinutes
                        };
                    if (serverity.SeverityCode == 2)
                        ret.VeryHigh = new SeverityConfig()
                        {
                            Cod = serverity.SeverityCode,
                            Descr = serverity.SeverityDescr,
                            Time = serverity.SeverityDefaultTimeMinutes
                        };
                    
                }
                //ret.ServerityTimes = ServerityTimes;

                return ret;
            }

            return null;
        }

        [Permission(System.Security.Permissions.SecurityAction.Demand, Name = SecurityPermition.ExcuteAdministrator)]
        public static ServiceOutput<String> UpdateConfiguration(AdminConfiguration update)
        {
            bool response = true;
            try
            {
            
               tblConfiguration config = new tblConfiguration();
                config.AlgormitDefaultTimeInterval = update.AlgoritmTimeInterval;
                config.LoginTokenValidationTime = update.LoginTokenValidationTime;
                config.UserSpanRuleHours = update.UserSpamRoleForHour;
                config.FirsStepRatioAlert = update.LowRationWarning;
                config.SecondStepRationAlert = update.LowRatioUserDisable;
                config.NegativeWeigthVotes = update.NegativeWeigthVotes;
                response &= ConfigurationManager.UpdatedConfiguratByCode(config);

                
                tblSeverityKind low = new tblSeverityKind();
                low.SeverityDefaultTimeMinutes = update.Low.Time;

                tblSeverityKind high = new tblSeverityKind();
                high.SeverityDefaultTimeMinutes = update.High.Time;

                tblSeverityKind VeryHigh = new tblSeverityKind();
                VeryHigh.SeverityDefaultTimeMinutes = update.VeryHigh.Time;

                response &= SeverityManager.UpdateForCode(low, 0);
                response &= SeverityManager.UpdateForCode(high, 1);
                response &= SeverityManager.UpdateForCode(VeryHigh, 2);



            }
            catch (Exception ex)
            {
               return new ServiceOutput<string>()
                          {
                              Error = true,
                              Description = ex.Message
                          }; 
               
            }

            return new ServiceOutput<string>()
                       {
                           Error = !response,
                           Description = !response == false ? "The configuration are sucessfuly updaded":"Error when try updaped the configuration",
                           Value = !response == false ? "The configuration are sucessfuly updaded" : "Error when try updaped the configuration"
                       };
        }

    }
}
