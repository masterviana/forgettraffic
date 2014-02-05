using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForgetTraffic.DataTypes.RestTypes.Admin
{
    [DataContract]
    public class UpdateAdministrator
    {

        [DataMember]
        public String LoginToken { get; set; }
        [DataMember]
        public List<UserAdminUpdate> User { get; set; }
        [DataMember]
        public List<IncidentAdmin> Incident { get; set; }
        [DataMember]
        public AdminConfiguration Configuration { get; set; }

    }

    [DataContract]
    public class UserAdminUpdate
    {
        [DataMember] public String UserName { get; set; }
        [DataMember] public int CodOldRole { get; set; }
        [DataMember] public int DesrcOldRole { get; set; }
        [DataMember] public int CodNewRole{ get; set; }
        [DataMember] public int DescrNewRole { get; set; }
        [DataMember]public String CodOldStatus { get; set; }
        [DataMember]public String DescrOldStatus { get; set; }
        [DataMember]public String CodNewStatus { get; set; }
        [DataMember]public String DescrNewStatus { get; set; }
    }

    [DataContract]
    public class IncidentAdmin
    {
        [DataMember]public String CodOldStatus { get; set; }
        [DataMember]public String DescrOldStatus { get; set; }
        [DataMember] public String CodNewStatus { get; set; }
        [DataMember]public String DescrNewStatus { get; set; }
        [DataMember] public String OldEndTime { get; set; }
        [DataMember]public String NewEndTime { get; set; }
    
    }

    [DataContract]
    public class ConfigurationAdmin
    {
        
    }

}
