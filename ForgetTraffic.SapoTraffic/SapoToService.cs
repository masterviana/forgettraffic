using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.SapoTraffic.Objects;

namespace ForgetTraffic.SapoTraffic
{
    public class SapoToService
    {
        public static List<SapoTrafficObject> _sapoTrafficObjects;
        private static readonly ReaderXmlsapoTraffic readerXmlsapoTraffic = new ReaderXmlsapoTraffic();

        private readonly Logger log;

        

        private bool StopSapoService; 

        public SapoToService()
        {
            log = new Logger();
            StopSapoService = false; 

        }

        //System.Threading.Timer Timer;
        public void Run()
        {
            //Timer = new System.Threading.Timer(TimerCallback, null, 0, 5000);
        }

        private void TimerCallback(object state)
        {
            if (StopSapoService)
            {
                //Timer.Dispose();
                return;
            }
            ContactToService();
        }
        public void Stop()
        {
            StopSapoService = true; 
        }

        public static void ContactToService()
        {
           //log.LoggingData("Initialize Process from Read from SAPO and Insert to Service");
            IncidentReturnSet incidents;
            try
            {
                _sapoTrafficObjects = readerXmlsapoTraffic.ReadSapoTrafficXml(Links.Urlsapo);
                string token = HttpRequestToService.MakeLogin();
                incidents = readerXmlsapoTraffic.ConvertSapoObjectsInOccurrenceReturn(_sapoTrafficObjects, token);
            }
            catch (Exception e)
            {
                // Erro a ler returna de imediato
                //log.LoggingData("Don´t Insert Any Incident Because: " + e.Message);
                return;
            }
           int count=0;
           for (int i = 0; i < incidents.AddedIncidents.Count(); ++i)
           {
               ResponseService<Incident> responseObject; 
               try{
                   // Avaliar a resposta.... 
                   responseObject = HttpRequestToService.RegisterIncident(incidents.AddedIncidents[i]);
               }
               catch (Exception e)
               {
                   //log.LoggingData("Don´t Insert Any Incident Because: " + e.Message);return;
               }

               
               //if(responseObject.Error){log.LoggingData("Don´t Insert Incident Because: " +  responseObject.Description);}
               //else{count++;}
           }
           //log.LoggingData("Add: " + count + "Incidents");
       }
    }



}
