using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForgetTraffic.DataTypes.RestTypes.Users
{
    [DataContract]
    public class UpdateUser
    {

        [DataMember]
        public String LoginToken { get; set; }

        [DataMember]
        public String FirstName { get; set; }

        [DataMember]
        public String LastName { get; set; }

        [DataMember]
        public String BirthDate { get; set; }

        [DataMember]
        public String Password { get; set; }

        [DataMember]
        public bool   HidenUserName { get; set; }

        [DataMember]
        public String ConfirmPassword { get; set; }

        [DataMember]
        public String SecretQuestion { get; set; }

        [DataMember]
        public String SecretAnswer { get; set; }

        [DataMember]
        public String OldPassword { get; set; }
    }

 

}
