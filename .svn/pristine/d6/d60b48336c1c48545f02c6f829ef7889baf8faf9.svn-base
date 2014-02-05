using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ForgetTraffic.DataTypes.Incident
{
    [DataContract]
    public enum IncidentType
    {
        [EnumMember] SlowTraffic = 0,
        [EnumMember] MaintenanceStreet = 1,
        [EnumMember] PoliceTrap = 2,
        [EnumMember] Accident = 3
    }

   
    [DataContract]
    public class ConsultIndicent
    {
        [DataMember]
        public DateTime? LastVerifyDate { get; set; }

        [DataMember(IsRequired = false)]
        public String Distrito { get; set; }

        [DataMember(IsRequired = false)]
        public String Concelho { get; set; }

        [DataMember(IsRequired = false)]
        public String Localidade { get; set; }

        [DataMember(IsRequired = false)]
        public String Pais { get; set; }

        [DataMember(IsRequired = false)]
        public IncidentType TypeIncident { get; set; }

        [DataMember(IsRequired = false)]
        public String LoginToken { get; set; }
    }


    [DataContract]
    public class IncidentReturnSet
    {

        private List<Incident> _addedList;
        private List<Incident> _removededList;
        private List<Incident> _updatedList;

        [DataMember]
        public List<Incident> AddedIncidents
        {
            get { return _addedList ?? (_addedList = new List<Incident>()); }
            set { _addedList = value; }
        }

        [DataMember]
        public List<Incident> RemovedIncidents
        {
            get { return _removededList ?? (_removededList = new List<Incident>()); }
            set { _removededList = value; }
        }

        [DataMember]
        public List<Incident> UpdatedIncidents
        {
            get { return _updatedList ?? (_updatedList = new List<Incident>()); }
            set { _updatedList = value; }
        }

        [DataMember]
        public Double LastVerifyDate { get; set; }

    }

    [DataContract]
    public class Incident
    {
        public Incident()
        {
            Coordinates = new Cord();
        }

        private DateTime _publicationDate;

        //Só para preencher quando se for retornar 
        [DataMember(IsRequired = false)]
        public String CodIncident { get; set; }

        [DataMember]
        public Cord Coordinates { get; set; }

        //[DataMember]
        //public IncidentType Type { get; set; }

        [DataMember]
        public int Type { get; set; }

        [DataMember]
        public int Severity   { get; set; }

        [DataMember]
        public String UserName { get; set; }

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

        [DataMember ( IsRequired = false )]
        public VoteInfo Votes { get; set; }

        [DataMember(IsRequired = false)]
        public int UserRatio { get; set; }

        [DataMember]
        public DateTime  PublicationDate
        {
            get { return _publicationDate; }
            set { _publicationDate = value; }

        }

        [DataMember]
        public double PublicationDateTicks { get; set; }

        [DataMember]
        public String PublicationDateString{ get; set; }

        [DataMember(IsRequired = false)]
        public DateTime? EndDate { get; set; }

        [DataMember(IsRequired = false)]
        public long EndDateTicks { get; set; }

    }


    [DataContract]
    public class Cord
    {
        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        public override bool Equals(object obj)
        {
            var _cor = obj as Cord;

            if (_cor != null)
            {
                return _cor.Latitude == Latitude && _cor.Longitude == Longitude;
            }

            return false;
        }
    }
}