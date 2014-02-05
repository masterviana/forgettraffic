using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.IO;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace ForgetTraffic.Logger
{
   public enum WriteType
    {
        Error,
        Information,
        Warning,
        ConnectionFail
    }
    public class Logger
    {

        private static String FILE_NAME = "ForgetTrafficLogger";


        private StreamWriter _writer;
        private FileStream _fileToStream;
        private bool _isOpened;
        private String _partialPath;


        

        public static Logger SINGLETON = new Logger();

        //public static Logger SINGLETON()
        //{
        //    if(_singleton == null)
        //        _singleton = new Logger();
        //    return _singleton;
        //}

        public Logger()
        {

            try
            {
                FILE_NAME = ConfigurationManager.AppSettings["Logger.Name"];
                _partialPath = ConfigurationManager.AppSettings["Logger.Path"];
            }
            catch 
            {
                _partialPath= Path.GetDirectoryName( Assembly.GetAssembly(typeof(Logger)).CodeBase);
                FILE_NAME = "Logger"+"_"+DateTime.Now.ToShortDateString()+".txt";
            }

            if (_partialPath == null) 
            {
                _partialPath = AppDomain.CurrentDomain.BaseDirectory;
                FILE_NAME = "Logger" + "_" + DateTime.Now.ToShortDateString() + ".txt";
            }


        }

        public Logger(String partialPath)
        {
            _partialPath = partialPath;
        }

        public Logger(String FileName, String path) 
        {

            FILE_NAME = FileName;
            _partialPath = path;
        }

        private void init()
        {
            String path;
            if (!_isOpened)
            {
                path  =  _partialPath+"\\"+FILE_NAME;

                _fileToStream = new FileStream( path, FileMode.Append, FileAccess.Write);
                _writer = new StreamWriter(_fileToStream);
                _isOpened = true;
            }
    }

        private  void close()
        {
         if (_isOpened) 
          {
            _writer.Flush();
            _writer.Close();
            _isOpened = false;
        }
    }

        public void  writeEvent(String evt, WriteType type)
        {

            init();

            _writer.WriteLine(" ------------------------------------------------------------------------------");
            _writer.WriteLine(" ------------------------------------------------------------------------------");
            _writer.WriteLine("         *****   Event  : "+type+ " on date : " + DateTime.Now+"  *****        ");
            _writer.WriteLine(" ");
            _writer.WriteLine(evt);
            _writer.WriteLine("################################################################################ ");

            close();

        }

    }
}
