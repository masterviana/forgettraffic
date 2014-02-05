using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ForgetTraffic.SapoTraffic
{
    public class Logger
    {

        // Falta definir caminho...  
        // private readonly String _logDirectory = System.Configuration.ConfigurationSettings.AppSettings["logging.directory"].ToString();

        private const string LogName= "ServiceSapo.log";

        private readonly String _filePath;

        public Logger()
        {
            _filePath = "D:\\" + LogName;

            if (!File.Exists(_filePath))
            {
                FileStream fs = File.Create(_filePath);
                fs.Close();
            }
        }

        public void LoggingData(string message)
        {
            // Adiciona a data e a messagem 


            DateTime dt = DateTime.Now;

            try
            {
                StreamWriter sw = File.AppendText(_filePath);
                sw.WriteLine(dt.ToString("dd/MM/yyyy HH:mm:ss") + "|" + message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
