using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.Site.Business;
using ForgetTraffic.Site.Models;

namespace ForgetTraffic.Site.Controllers
{
    public class InformationController : Controller
    {
        //
        // GET: /Information/

        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Autores()
        {
            var _autores = new AutoresSet
                               {
                                   Authors = new List<Autor>
                                                 {
                                                     new Autor
                                                         {
                                                             Nome = "Fernando Vaz",
                                                             Foto = Url.Content("~/Content/images/autores/fmlvaz.png"),
                                                             MailContact = "fmlvaz@forgettraffic.net"
                                                         },
                                                     new Autor
                                                         {
                                                             Nome = "Vitor Viana",
                                                             Foto = Url.Content("~/Content/images/autores/vviana.png"),
                                                             MailContact = "vviana@forgettraffic.net"
                                                         }
                                                 }
                               };
            return View(_autores);
        }

        public ActionResult FAQ()
        {
            return View();
        }


        public ActionResult API()
        {
            return View();
        }

        public ActionResult InterestingLinks()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View("ConctaUs", null);
        }

        [HttpPost]
        public JsonResult VoteInfo(String  stringData )
        {
              var json_serializer = new JavaScriptSerializer();
              VoteSubmit vote = json_serializer.Deserialize<VoteSubmit>(stringData.ToString());

            ServiceOutput<string > _vote = HttpRequestToService.VoteIncident(vote);

            return Json(_vote, JsonRequestBehavior.AllowGet);
        }
    }
}