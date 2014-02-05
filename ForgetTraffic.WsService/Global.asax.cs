using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Web;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataTypes;
using System.Threading;
using ForgetTraffic.ParallelsServices;

namespace ForgetTraffic.WsService
{
    public class Global : HttpApplication
    {

        protected void Application_Start(Object sender, EventArgs e)
        {
            ForgetTraffic.InitializeStructure.GeneralInitialize.Initialize();

            //ForgetTraffic.ParallelsServices.SolveIncidentService.SINGLETON();
           
            //FileStream fs = new 
            //FileStream(Server.MapPath("~/logfiles/traceLog.txt"),FileMode.OpenOrCreate,FileAccess.ReadWrite, FileShare.ReadWrite);
            //StreamWriter sw = new StreamWriter(fs,System.Text.Encoding.UTF8);
            //System.Diagnostics.TextWriterTraceListener txtListener = new 
            //System.Diagnostics.TextWriterTraceListener(sw, "txt_listener");
            ////System.Diagnostics.XmlWriterTraceListener xml = new XmlWriterTraceListener(sw,"xml_listener");
            //System.Diagnostics.Trace.Listeners.Add(txtListener);

            //System.Diagnostics.Trace.AutoFlush = true;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            CultureInfo portugal = new CultureInfo("pt-PT");
            Thread.CurrentThread.CurrentCulture = portugal;

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            EnableCrossDmainAjaxCall();

           

        }


        private void EnableCrossDmainAjaxCall()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

            GeneralManager.Dispose();

        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            string err = "Error Caught in Application_Error event\n" +
                         "Error in: " + Request.Url +
                         "\nError Message:" + objErr.Message +
                         "\nStack Trace:" + objErr.StackTrace;
            EventLog.WriteEntry("Sample_WebApp", err, EventLogEntryType.Error);
            Server.ClearError();

            Response.Write(err);

        }
    }
}