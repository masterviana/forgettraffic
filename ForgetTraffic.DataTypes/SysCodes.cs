using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetTraffic.DataTypes
{
    public class SysCodes
    {

        //Generics Parent Code's
        public const String SysStates = "States";
        public const String SysEmailConfirm = "ConfMail";


        //Generics Child Code's

        //States
        public static String StActive = "A";
        public static String StDelete = "X";
        public static String StWaiting = "W";

        //ConfirmationActions

        public static String ActConfirmMail = "ConfMail_Resg";

        public const  int SeverityByDefault =2;
        public const int TypeByDefault = 1;

        public const int RoleAdministration = 5;
        public const int RoleUtilizadores = 9;
        public const int RoleServicos = 10;
    }
}
