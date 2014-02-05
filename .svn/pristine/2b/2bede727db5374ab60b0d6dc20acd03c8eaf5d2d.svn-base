using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.SapoTraffic.Objects;


namespace ForgetTraffic.SapoTraffic
{
    public static class HttpRequestToService
    {

        public static string MakeLogin()
        {

            const string userName = "Sapo";
            string pass = "sapo123";


            // used to build entire input
            var sb = new StringBuilder();

            // used on each read operation
            var buf = new byte[8192];

            // prepare the web page we will be asking for
            var serializer = new JavaScriptSerializer();

            LoginInfo login = new LoginInfo()
            {
                UserName = userName,
                Password = pass
            };

            UTF8Encoding encoding = new UTF8Encoding();
            string postdata = serializer.Serialize(login);
            byte[] data = encoding.GetBytes(postdata);

            var myRequest =
                (HttpWebRequest)WebRequest.Create(Consts.ServiceAdress + Consts.LogOn);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/json;";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            // execute the request
            ServiceOutput<UserInfo> responseObject = null;

            HttpWebResponse response = null;
            Stream resStream = null;
            try
            {

                response = (HttpWebResponse)myRequest.GetResponse();
                resStream = response.GetResponseStream();

            }
            catch (Exception e)
            {
                responseObject = new ServiceOutput<UserInfo> { Error = true, Description = e.Message };


            }


            int count = 0;

            do
            {
                // fill the buffer with data
                if (resStream != null) count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    string tempString = Encoding.UTF8.GetString(buf, 0, count);

                    // continue building the string
                    sb.Append(tempString);

                    var json_serializer = new JavaScriptSerializer();
                    responseObject = json_serializer.Deserialize<ServiceOutput<UserInfo>>(sb.ToString());
                }
            } while (count > 0); // any more data to read?

            return responseObject.Value.LoginToken; 
        }

         public static ResponseService<Incident> RegisterIncident(Incident incident)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            var jsonSerializer = new JavaScriptSerializer(); 
            var sb = new StringBuilder();

            var buf = new byte[8192];

             // Converte para Json a incidência pretendida

            string postdata = jsonSerializer.Serialize(incident); ;
            byte[] data = encoding.GetBytes(postdata);


             var myRequest = (HttpWebRequest)
                          WebRequest.Create(Consts.ServiceAdress+Consts.Incident);

            myRequest.Method = "POST";
            myRequest.ContentType = "application/Json; charset=utf-8";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            ResponseService<Incident> responseObject = null; 

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)myRequest.GetResponse();
            }
            catch (Exception re)
            {
                throw re;
            }

            Stream resStream = response.GetResponseStream();

            int count = 0;

            do
            {
                if (resStream != null) count = resStream.Read(buf, 0, buf.Length);


                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    string tempString = encoding.GetString(buf, 0, count);

                    sb.Append(tempString);


                    responseObject = jsonSerializer.Deserialize<ResponseService<Incident>>(sb.ToString());
                }
            } while (count > 0);

            return responseObject; 
        }
    }

    }
