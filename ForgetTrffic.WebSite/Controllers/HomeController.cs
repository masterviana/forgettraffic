using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.SapoTraffic;

namespace ForgetTrffic.WebSite.Controllers
{


    [HandleError]
    public class HomeController : Controller
    {

        private static IncidentsReturn[] GetIncidents()
        {
            string urlTeste = "c:\\Users\\Fmlvaz\\Desktop\\teste.xml";
            string urlsapo = "http://services.sapo.pt/Traffic/GeoRSS";
            var readerXmlsapoTraffic = new ReaderXmlsapoTraffic();

            List<SapoTrafficObject> sapoTrafficObjects = readerXmlsapoTraffic.ReadSapoTrafficXml(urlTeste);

            IncidentsReturn[] occurrenceReturns =
                readerXmlsapoTraffic.ConvertSapoObjectsInOccurrenceReturn(sapoTrafficObjects.ToArray());
            return occurrenceReturns;

        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public JsonResult GetMapIncidents()
        {

            var incidents = GetIncidents();
            // get Incidencîas

            var temp = Json(incidents);
            return Json(incidents, JsonRequestBehavior.AllowGet);
        }
    }
}
