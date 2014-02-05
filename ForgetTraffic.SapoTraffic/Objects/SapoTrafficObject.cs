using System;

namespace ForgetTraffic.SapoTraffic
{
    public class SapoTrafficObject
    {
        public string Title { get; set; }
        public int Category { get; set; }
        public DateTime PubDate { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public DateTime EndDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}