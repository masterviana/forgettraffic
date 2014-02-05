using System.Collections.Generic;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;

namespace ForgetTraffic.Site.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private static IncidentReturnSet GetIncidents()
        {
          //  string urlTeste = "c:\\Users\\Fmlvaz\\Desktop\\teste.xml";
          // Fazer get do register... 

            return null;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

      //      SapoToService st = new SapoToService();
      //      st.ContactToService();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult community()
        {
            return View();
        }

        public JsonResult GetMapIncidents()
        {
            IncidentReturnSet incidents = GetIncidents();
            // get Incidencîas

            return Json(incidents, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUpdateIncidents()
        {
            // Update ao serviço...
           // return Json(occurrenceReturns, JsonRequestBehavior.AllowGet);
            return null; 
        }


        public ActionResult ViewTraffic()
        {
            return View();
        }
    }
}