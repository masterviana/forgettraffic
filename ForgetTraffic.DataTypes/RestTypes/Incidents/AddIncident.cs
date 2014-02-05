using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ForgetTraffic.DataTypes.Incident;

namespace ForgetTraffic.DataTypes.RestTypes.Incidents
{
    [DataContract]
    public class AddIncident
    {

        public AddIncident()
        {
            Coordinates = new Cord();
        }

        [DataMember]
        public Cord Coordinates { get; set; }

        [DataMember]
        public int Type { get; set; }

        [DataMember]
        public int Severity{ get; set; }

        [DataMember]
        public String LoginToken { get; set; }

        [DataMember(IsRequired = false)]
        public String Title { get; set; }

        [DataMember(IsRequired = false)]
        public String Description { get; set; }

        [DataMember(IsRequired = false)]
        public String Distrito { get; set; }

        [DataMember(IsRequired = false)]
        public String Concelho { get; set; }

        [DataMember(IsRequired = false)]
        public String Localidade { get; set; }

        [DataMember(IsRequired = false)]
        public String Pais { get; set; }

        [DataMember(IsRequired = false)]
        public String CodePais { get; set; }

        [DataMember(IsRequired = false)]
        public String CodePostal { get; set; }

        [DataMember(IsRequired = false)]
        public String Adress { get; set; }

        [DataMember ( IsRequired = false )]
        public VoteInfo Votes { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime? EndDate { get; set; }

        [DataMember(IsRequired = false)]
        public long EndDateTicks { get; set; }
    }
}
