using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Users;
using ForgetTraffic.Site.Models;
using LoginInfo = ForgetTraffic.DataTypes.Authentication.LoginInfo;

namespace ForgetTraffic.Site.Business
{
    public static class HttpRequestToService
    {

        public static ServiceOutput<UserInfoSite> MakeLogin(LogOnModel model)
        {
            //Fazer login no serviço. Guardar o token... no estado sessão.... 

            // used to build entire input
            var sb = new StringBuilder();

            // used on each read operation
            var buf = new byte[8192];

            // prepare the web page we will be asking for
            var serializer = new JavaScriptSerializer();

            LoginInfo login = new LoginInfo()
                                  {
                                      UserName = model.UserName,
                                      Password = model.Password
                                  };

            var encoding = new UTF8Encoding();
            string postdata = serializer.Serialize(login);
            byte[] data = encoding.GetBytes(postdata);

            var myRequest =
                (HttpWebRequest)WebRequest.Create(Consts.BaseAdress + Consts.OpLogOn);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/json;";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            // execute the request
            ServiceOutput<UserInfoSite> responseObject = null; 

            HttpWebResponse response = null;
            Stream resStream =null;
            try
            {

                response = (HttpWebResponse)myRequest.GetResponse();
                resStream = response.GetResponseStream();

            }
            catch (Exception e)
            {
                responseObject = new ServiceOutput<UserInfoSite> {Error = true, Description = e.Message};
                

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
                    responseObject = json_serializer.Deserialize<ServiceOutput<UserInfoSite>>(sb.ToString());
                }
            } while (count > 0); // any more data to read?

            // print out page source

            //if (ModelState.IsValid)
            //{
            //    if (MembershipService.ValidateUser(model.UserName, model.Password))
            //    {
            //        FormsService.SignIn(model.UserName, model.RememberMe);
            //        if (!String.IsNullOrEmpty(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "The user name or password provided is incorrect.");
            //    }
            //}

            // If we got this far, something failed, redisplay form

            return responseObject; 
        }


        #region Update Profile

        public static ServiceOutput<ResponseUser> GetUserProfile(String loginToken)
        {
            //Fazer login no serviço. Guardar o token... no estado sessão.... 


            // used to build entire input
            var sb = new StringBuilder();

            // used on each read operation
            var buf = new byte[8192];


            var encoding = new UTF8Encoding();


            var json_serializer_ = new JavaScriptSerializer();

            String parameter = json_serializer_.Serialize(loginToken);

            byte[] data = encoding.GetBytes(parameter);

            // prepare the web page we will be asking for
            var request = (HttpWebRequest)
                          WebRequest.Create(
                             Consts.BaseAdress + Consts.OpUser + "?loginToken=" + loginToken);


            request.ContentType = "application/json; charset=utf-8";

            ServiceOutput<ResponseUser> responseObject = null;

            HttpWebResponse response = null;

            try
            {

                response = (HttpWebResponse)request.GetResponse();

            }
            catch (Exception e)
            {
                responseObject = new ServiceOutput<ResponseUser> { Error = true, Description = e.Message };
            }

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

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
                    responseObject = json_serializer.Deserialize<ServiceOutput<ResponseUser>>(sb.ToString());
                }
            } while (count > 0); // any more data to read?
      


            return responseObject;
        }

        #endregion

        public static ServiceOutput<CdoUserProfile> Register(RegisterModel registerModel)
        {


            String urlCreateUser = Consts.BaseAdress + Consts.OpUser;

            var encoding = new UTF8Encoding();

            string postdata = RaperToForgetService.CreateUser(registerModel);
            byte[] data = encoding.GetBytes(postdata);

            var myRequest =
                (HttpWebRequest)WebRequest.Create(urlCreateUser);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/Json;";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            // used to build entire input
            var sb = new StringBuilder();

            // used on each read operation
            var buf = new byte[8192];

            var response = (HttpWebResponse)
                           myRequest.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

            string tempString = null;
            int count = 0;

            ServiceOutput<CdoUserProfile> responseObject = null; 

            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.UTF8.GetString(buf, 0, count);

                    // continue building the string
                    sb.Append(tempString);

                    var json_serializer = new JavaScriptSerializer();
                    responseObject = json_serializer.Deserialize<ServiceOutput<CdoUserProfile>>(sb.ToString());
                }
            } while (count > 0);


            /*   teste 

                        private void OnPostInfoClick(object sender, System.EventArgs e)
            {
                string strId = UserId_TextBox.Text;
                string strName = Name_TextBox.Text;

                ASCIIEncoding encoding=new ASCIIEncoding();
                string postData="userid="+strId;
                postData += ("&username="+strName);
                byte[]  data = encoding.GetBytes(postData);

                // Prepare web request...
                HttpWebRequest myRequest =
                  (HttpWebRequest)WebRequest.Create("http://localhost/MyIdentity/Default.aspx");
                myRequest.Method = "POST";
                myRequest.ContentType="application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                Stream newStream=myRequest.GetRequestStream();
                // Send the data.
                newStream.Write(data,0,data.Length);
                newStream.Close();
            }

                        if (ModelState.IsValid)
                        {
                            // Attempt to register the user
                            MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                            if (createStatus == MembershipCreateStatus.Success)
                            {
                                FormsService.SignIn(model.UserName, false  ); // createPersistentCookie
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                            }
                        }

                        / If we got this far, something failed, redisplay form
                        ViewData["PasswordLength"] = MembershipService.MinPasswordLength;


            */

            return responseObject; 
        }



        public static ServiceOutput<CdoUserProfile> UpdateUserProfile(RegisterModel registerModel)
        {


            String urlCreateUser = Consts.BaseAdress + Consts.OpUser;

            var encoding = new UTF8Encoding();

            string postdata = RaperToForgetService.CreateUser(registerModel);
            byte[] data = encoding.GetBytes(postdata);

            var myRequest =
                (HttpWebRequest) WebRequest.Create(urlCreateUser);
            myRequest.Method = "PUT";
            myRequest.ContentType = "application/Json";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            // used to build entire input
            var sb = new StringBuilder();

            // used on each read operation
            var buf = new byte[8192];

            var response = (HttpWebResponse)
                           myRequest.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

            string tempString = null;
            int count = 0;

            ServiceOutput<CdoUserProfile> responseObject = null;

            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.UTF8.GetString(buf, 0, count);

                    // continue building the string
                    sb.Append(tempString);

                    var json_serializer = new JavaScriptSerializer();
                    responseObject = json_serializer.Deserialize<ServiceOutput<CdoUserProfile>>(sb.ToString());
                }
            } while (count > 0);

            return responseObject;
        }


        public static ServiceOutput<String> VoteIncident(VoteSubmit vote)
        {
            String urlCreateUser = Consts.BaseAdress + Consts.OpIncident;

            var encoding = new UTF8Encoding();

            var serie = new JavaScriptSerializer();
            string postdata = serie.Serialize(vote);
            byte[] data = encoding.GetBytes(postdata);

            var myRequest =
                (HttpWebRequest)WebRequest.Create( urlCreateUser );
            myRequest.Method = "PUT";
            myRequest.ContentType = "application/Json";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            // used to build entire input
            var sb = new StringBuilder();

            // used on each read operation
            var buf = new byte[8192];

            var response = (HttpWebResponse)
                           myRequest.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            ServiceOutput<String> responseObject = null;

            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.UTF8.GetString(buf, 0, count);
                    // continue building the string
                    sb.Append(tempString);
                    var json_serializer = new JavaScriptSerializer();
                    responseObject = json_serializer.Deserialize<ServiceOutput<String>>(sb.ToString());
                }
            } while (count > 0);

            return responseObject;
        }

    }
}