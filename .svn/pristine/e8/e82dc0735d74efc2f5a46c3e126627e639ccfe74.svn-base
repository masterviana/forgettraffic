using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.ServiceUtils;

namespace ForgetTraffic.TrafficIncidences.SolveIncidents
{
    public class UserOperations
    {

        public static void UpdateUserProfile(tblIncident incident)
        {
            try
            {
                tblUserProfile profile = UserProfileManager.GetUserProfile(incident.tblUser);
                VoteInfo info = IncidentVoteManager.GetVoteCountingByIncident(incident);

                if( profile != null  )
                {

                    if (info.Positive != info.Negative)
                    {
                        bool positive = info.Positive > info.Negative;

                        //Vou incrementar o numero de positivas ou negaticas
                        if (positive)
                            profile.ValidateIncidents += 1;
                        else
                            profile.InvalidatIncidents += 1;
                    }

                    //
                    double rat = (profile.InvalidatIncidents + profile.ValidateIncidents);
                    rat = profile.ValidateIncidents / rat;
                    rat *= 100;
                    //Actulizar o perfil do user com o  novo racio
                    profile.UserRatio = (int)rat;

                    CheckRatioLimites(incident, (int)rat);

                }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private static void CheckRatioLimites( tblIncident incident , int ratio)
        {
            tblConfiguration configuration = ConfigurationManager.GetConfiguration();

            if(configuration != null)
            {
                
                    if (ratio <= configuration.SecondStepRationAlert && incident.tblUser.SYS_STATE.Equals("A"))
                    {
                        //Mando o email a avisar o user
                        MailOperations.SendMailSmtp(
                            Consts.UserSmtp
                            , Consts.PassSmtp
                            , Consts.HostingAdress
                            , Consts.PortStmp
                            , incident.tblUser.Email
                            , Consts.UserSmtp
                            , MailOperations.AlertCancelUserLowRatio(incident.tblUser.UserName)
                            , Consts.ConfirmRegistSubject
                            );
                        //Vou cancelar o user
                        incident.tblUser.SYS_STATE = "X";
                    }
                    else
                    {
                        if( ratio <= configuration.FirsStepRatioAlert  )
                        {

                            MailOperations.SendMailSmtp(
                                Consts.UserSmtp
                                , Consts.PassSmtp
                                , Consts.HostingAdress
                                , Consts.PortStmp
                                , incident.tblUser.Email
                                , Consts.UserSmtp
                                , MailOperations.WarningLowRatio(incident.tblUser.UserName)
                                , Consts.ConfirmRegistSubject
                            );
                        }
                    }   
            }
        }

    }
}
