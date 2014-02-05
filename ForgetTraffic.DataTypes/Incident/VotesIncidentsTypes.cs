using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForgetTraffic.DataTypes.Incident
{

    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  25-05-2011  
     *              Name         :  VotesIncidentsTypes
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */
    [DataContract]
    public class VoteInfo
    {
        [DataMember]
        public int Positive { get; set; }
        [DataMember]
        public int Negative { get; set; }
        [DataMember]
        public int Ratio { get; set; }

        [DataMember(IsRequired = false)]
        public bool CantVote{ get; set; }

    }

    [DataContract]
    public class VoteSubmit
    {

        [DataMember]
        public String CodIncident { get; set; }
        [DataMember]
        public Guid   IdIncident { get; set; }
        [DataMember]
        public String LoginToken { get; set; }
        [DataMember]
        public Boolean PositiveVote { get; set; }
        [DataMember]
        public String Comment { get; set; }

    }

}
