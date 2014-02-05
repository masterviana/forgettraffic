using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForgetTraffic.DataTypes.RestTypes.Admin
{
     [DataContract]
    public class FilterItens
    {
        [DataMember]
        public String LoginToken { get; set; }
        [DataMember]
        public FilterUser Users { get; set; }
        [DataMember]
        public FilterIncidents Incidents { get; set; }
        [DataMember]
        public FilterConfigurations Configuration { get; set; }
    }

     [DataContract]
    public class FilterUser
    {
         [DataMember]
        public String Username { get; set; }
    }

     [DataContract]
    public class FilterIncidents
    {

    }

     [DataContract]
     public class FilterConfigurations
     {
         [DataMember]
         public bool AdminInfo { get; set; }
     }
}
