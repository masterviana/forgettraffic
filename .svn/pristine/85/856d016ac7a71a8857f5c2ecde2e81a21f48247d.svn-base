using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;


namespace ForgetTraffic.ServiceUtils
{
    public class ConfirmationEmail
    {


        public static ServiceOutput<tblConfirmActions> GenerateUserRegisterMailValidation(tblUser user)
        {
            
            DateTime _date = DateTime.Now;

            String unprocessToken = user.UserId + ";" + user.UserName + ";" + SysCodes.SysEmailConfirm + ";" +
                                    _date.ToLongTimeString() + ";";

            DateTime _endDate = _date.AddHours(Consts.ValidationTokenActiveTime);

            String processString = CrypytUtils.ComputeHash(unprocessToken, ForgetTraffic.DataTypes.Consts.HashAlgoritm, null).HashValue;

            tblSysState state =  StatusManager.GetByCodeAndParent(SysCodes.ActConfirmMail, SysCodes.SysEmailConfirm);

            tblConfirmActions _ret =  ActionManager.AddConfirmaAction(user, state, processString, _endDate);

            return new ServiceOutput<tblConfirmActions>()
                       {
                           Error = false,
                           Description = "You'll send you a email confirmation. Please check your email account",
                           Value = _ret
                       };
        }


        public static ServiceOutput<tblUser> ConfirmRegisterAccount(String token)
        {

            tblConfirmActions actions =  ActionManager.FindByTokenId(token.Trim());

            if(actions == null)
                return new ServiceOutput<tblUser>()
                           {
                               Error = true,
                               Description = "This token dont exist on our system! Please resquest a new Token on Site"
               
                           };

            if( DateTime.Now >  actions.ValidateEndTime )
                return new ServiceOutput<tblUser>()
                           {
                               Error = true,
                               Description ="The validity of the token has expired. Please request a new token "
                           };


            return new ServiceOutput<tblUser>()
                       {
                           Value = actions.tblUser,
                           Description = "The token is correct"
                       };

        }

    }
}
