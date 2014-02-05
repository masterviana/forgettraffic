using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetTraffic.DataTypes
{
    public delegate void BehaviorDelegate(String username );

    public class SecurityPermition
    {

        public const String ExcuteAdministrator =  "ExecuteAdmin"; 
        public const String ExcuteUser =  "ExecuteAdmin";
        public const String ExcuteService= "ExecuteAdmin";
        public const String LeastThen3Incident = "LeastThen3Incident"; 

    }
}
