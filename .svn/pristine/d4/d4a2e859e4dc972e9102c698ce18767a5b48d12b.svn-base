using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using Data = ForgetTraffic.DataTypes;

namespace ForgetTraffic.Runner
{
    internal class WsRequest
    {
        private String _contentType;
        private String _url;

        public WsRequest()
        {
            _url = "http://localhost:6565/WsForgetTraffic/ForgetTrafficService.svc/PutingTest";
        }


        public String SerializeToJson(Incident serialize)
        {
            var jsondata = new DataContractJsonSerializer(typeof (Incident));
            var mem = new MemoryStream();
            jsondata.WriteObject(mem, serialize);
            string josnserdata = Encoding.UTF8.GetString(mem.ToArray(), 0, (int) mem.Length);

            return josnserdata;
        }

        public void MakeJsonRequest(String StringJsonParameter)
        {
            var request = WebRequest.Create(_url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";


            byte[] byteData = Encoding.UTF8.GetBytes(StringJsonParameter);

            // Set the content length in the request headers  
            request.ContentLength = byteData.Length;

            // Write data  
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            // Get response  
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                var reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        public void MakeJsonReturn()
        {
            _url = "http://localhost:6565/WsForgetTraffic/ForgetTrafficService.svc/PutingTest";

            var request = WebRequest.Create(_url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
        }
    }
}