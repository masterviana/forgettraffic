using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForgetTraffic.DataTypes.Authentication
{
    [DataContract]
    public class LoginInfo
    {
        [DataMember]
        public String UserName { get; set; }
        [DataMember]
        public String Password { get; set; }
    }
}
