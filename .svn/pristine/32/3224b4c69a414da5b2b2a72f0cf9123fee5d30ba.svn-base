
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForgetTraffic.DataTypes.RestTypes.Admin
{
   [DataContract]
    public class AdminConfiguration
    {
       [DataMember]
        public int AlgoritmTimeInterval { get; set; }
        [DataMember]
        public int LoginTokenValidationTime { get; set; }
        [DataMember]
        public int UserSpamRoleForHour { get; set; }
        [DataMember]
        public int LowRationWarning { get; set; }
        [DataMember]
        public int LowRatioUserDisable { get; set; }
        [DataMember]
        public int NegativeWeigthVotes { get; set; }
        [DataMember]
        public SeverityConfig Low { get; set; }
        [DataMember]
        public SeverityConfig High { get; set; }
        [DataMember]
        public SeverityConfig VeryHigh{ get; set; }


    }
    [DataContract]
    public class SeverityConfig
    {
        [DataMember]
        public int Cod { get; set; }
        [DataMember]
        public String Descr { get; set; }
        [DataMember]
        public int Time { get; set; }
    }
}
