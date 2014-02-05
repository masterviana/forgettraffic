using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.SapoTraffic.Objects;

namespace ForgetTraffic.SapoTraffic
{
    /**********************************************************************
      *
      *  Class Name      : ReaderXmlsapoTraffic
      *  Description     : ReaderXmlsapoTraffic
      * ------------------------------------------------------------------
      *  Date Created    : 11-06-2011
      *  Created By      : Fernando Vaz 
      * ------------------------------------------------------------------
      *  Copyright © 2011 - ISEL,Projecto Final
      * -------------------------------------------------------------------
      *  Revision History Log
      * 
      *  Date         Author            Description
      *  _______      ______________    ___________________________________________
      * 
      * 
      **********************************************************************/

    public class ReaderXmlsapoTraffic
    {
        private const string Title = "title";
        private const string Category = "category";
        private const string pubDate = "pubDate";
        private const string EndDate = "endDate";
        private const string description = "description";
        private const string location = "location";
        private const string point = "point";
        private const string localidade = "localidade";
        private const string concelho = "concelho";
        private const string distrito = "distrito";

        private const string Acident = "Acidente";
    //    private const string MaintenanceStreet = "Manutenção";
        private const string IntensiveTraffic = "Trânsito intenso";
        private const string SlowTraffic = "Trânsito lento";


        public static CultureInfo Portugal = new CultureInfo("pt-PT");

        public List<SapoTrafficObject> ReadSapoTrafficXml(string url)
        {
            XElement trafficNews = XElement.Load(url);

            XElement c = (from news in trafficNews.Elements("channel") select news).First();

            XNamespace iprss = "http://www.infoportugal.pt/iptrss";
            XNamespace georss = "http://www.georss.org/georss";

            List<SapoTrafficObject> sapoTrafficObjects = (from news in c.Elements("item")
                                                          select new SapoTrafficObject
                                                                     {
                                                                         Title = news.Element(Title).Value,
                                                                         Category =
                                                                             Convert.ToInt32(
                                                                                 news.Element(Category).Value),
                                                                         //PubDate =
                                                                         //    Convert.ToDateTime(
                                                                         //        news.Element(pubDate).Value),
                                                                         Description = news.Element(description).Value,
                                                                         Place =
                                                                             news.Element(iprss + location).Attribute(
                                                                                 localidade).Value,
                                                                         County =
                                                                             news.Element(iprss + location).Attribute(
                                                                                 concelho).Value,
                                                                         District =
                                                                             news.Element(iprss + location).Attribute(
                                                                                 distrito).Value,
                                                                         //EndDate = Convert.ToDateTime(
                                                                         //        news.Element(iprss + EndDate).Value),
                                                                         Latitude =
                                                                             GetCoordinates(
                                                                                 news.Element(georss + point).Value,
                                                                                 true),
                                                                         Longitude =
                                                                             GetCoordinates(
                                                                                 news.Element(georss + point).Value,
                                                                                 false),
                                                                     }).ToList();
            return sapoTrafficObjects;
        }

        private static double GetCoordinates(string geoRss, bool latitude)
        {
            string[] strs = geoRss.Split(new char[] { ' ', '.' });
            string strresult = String.Concat(latitude ? new string[] {strs[0], ',' + strs[1]} : new string[] { strs[2], ',' + strs[3] });
            double result = Convert.ToDouble(strresult, Portugal);

            return result;

        }

        public IncidentReturnSet ConvertSapoObjectsInOccurrenceReturn(List<SapoTrafficObject> sapoTrafficObjects, string token)
        {

            var incidentReturns = new IncidentReturnSet();

            Incident incident;

            for (int i = 0; i < sapoTrafficObjects.Count; ++i)
            {
                incident = new Incident
                               {
                                   Coordinates =
                                       {
                                           Latitude = sapoTrafficObjects[i].Latitude,
                                           Longitude = sapoTrafficObjects[i].Longitude
                                       },
                                   Title = sapoTrafficObjects[i].Title,
                                   Description = sapoTrafficObjects[i].Description,
                                   Localidade = sapoTrafficObjects[i].Place,
                                   Concelho = sapoTrafficObjects[i].County,
                                   Distrito = sapoTrafficObjects[i].District,
                                   EndDate = sapoTrafficObjects[i].EndDate
                               };

                incident.Type = GetIncidentType(incident.Description);

                incident.LoginToken = token;

                incidentReturns.AddedIncidents.Add(incident);
            }
            return incidentReturns;
        }

        public int GetIncidentType(string Description)
        {
            if (Description.Contains(Acident))
                return KindsIncident.Accident;
            if (Description.Contains(SlowTraffic) || Description.Contains(IntensiveTraffic))
                return KindsIncident.SlowTraffic;
            return KindsIncident.MaintenanceStreet;
        }
    }
}