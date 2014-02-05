using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetTraffic.DataTypes
{
    public class Consts
    {

        public static String ServiceAdress = "http://www.runner2.forgettraffic.net/ForgetTrafficService.svc/";
        public static String Incident= "Incident";
        public static String LogOn = "LogOn";

        public static int GetOldIncident = 2;


        //Timespan para indicar o tempo por defeito que uma incidencia fica activa
        public static readonly TimeSpan DefaultEndDateTime = new TimeSpan(0,2,0,0);

        //Profile points Configuration
        public static int PointsForLogin = 1;
        public static int PointsForVote =  1;
        public static int PointsForAddingIncidents = 10;


        //Validation token time
        public static int ValidationTokenActiveTime = 2;

        //Email Configuration
        //public static String UserSmtp = "info@forgettraffic.net";
        //public static String PassSmtp = "forgettraffic@2011";

        public const String UserSmtp = "noreply@forgettraffic.net";
        public const String PassSmtp = "noreply@2011";
        public const int PortStmp = 26;
        public const String HostingAdress = "mail.forgettraffic.net";
        public const String ConfirmRegistSubject = "Confirm register Account - Forget About Traffic";
        public const String ConfMailOperation = "EmailConfirmation?token=";


        public  static String CrpySh512 = "SHA512";

        //Intervalo do servico para actualizar as entidades
        public static readonly TimeSpan SolveIncidentInterval = new TimeSpan(0,0,5,0);
        public static readonly TimeSpan SapoRunnerInterval= new TimeSpan(0, 0, 33, 0);

        public const String HashAlgoritm = "";
    }



}
