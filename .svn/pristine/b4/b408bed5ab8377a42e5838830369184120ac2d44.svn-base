using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using DAL= ForgetTraffic.DAL;
using ForgetTraffic.DataModel;
using ForgetTraffic.ServiceUtils;

namespace ForgetTraffic.Autentication
{
    public class ConfirmationsViaEmail
    {

        public static ServiceOutput<tblConfirmActions> SendConfirmationEmail(tblUser user)
        {

            ServiceOutput<tblConfirmActions> actions = ConfirmationEmail.GenerateUserRegisterMailValidation(user);

            String link = Consts.ServiceAdress + Consts.ConfMailOperation + actions.Value.IdConfirmActions;


            MailOperations.SendMailSmtp( 
                Consts.UserSmtp
                ,Consts.PassSmtp
                ,Consts.HostingAdress
                ,Consts.PortStmp
                ,user.Email
                ,Consts.UserSmtp
                ,MailOperations.RequestRegister(link)
                ,Consts.ConfirmRegistSubject 
            );

            return actions;
        }

        public static ServiceOutput<tblUser> ConfirmationUserRegistration(String token)
        {
            ServiceOutput<tblUser> _user = ConfirmationEmail.ConfirmRegisterAccount(token);

            if( !_user.Error )
            {
                _user.Value.SYS_STATE = SysCodes.StActive;
                
            }
            return _user;
        }

    }
}
