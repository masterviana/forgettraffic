using System;

namespace ForgetTraffic.ServiceUtils{
    public class SapoTrafficObject
    {
        public string Title { get; set; }
        public int Category { get; set; }
        public DateTime PubDate { get; set; }
        public string Description { get; set; }
        public string place { get; set; }
        public string county { get; set; }
        public string district { get; set; }
        public DateTime endDate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}