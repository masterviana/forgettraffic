using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Users;
using ForgetTraffic.Site.Business;
using ForgetTraffic.Site.Models;

namespace ForgetTraffic.Site.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {


        // **************************************
        // URL: /Account/LogOn
        // **************************************

        //public ActionResult LogOn()
        //{
        //    return View();
        //}

        [HttpPost]
        public ViewResult LogOn(LogOnModel model)
        {

           ServiceOutput<UserInfoSite> responseObject = HttpRequestToService.MakeLogin(model);
            if (responseObject.Error ==false)
            {

              UserInfoSite userInfo = responseObject.Value;
               responseObject.Value = userInfo;
                HttpCookie cookieInfoUser = Request.Cookies["InfoUser"];
                var cookieLoginToken = new HttpCookie("LoginToken") { Value = userInfo.LoginToken };

                if (cookieInfoUser == null)
                {
                    cookieInfoUser = new HttpCookie("InfoUser");
                }

                cookieInfoUser["FirstName"] = userInfo.FirstName;
                cookieInfoUser["LastName"] = userInfo.LastName;
                cookieInfoUser["UserName"] = userInfo.UserName;
                cookieInfoUser["LoginToken"] = userInfo.LoginToken;
                cookieInfoUser["IsAdmin"] = userInfo.IsAdmin.ToString();

                if (model.RememberMe)
                {
                    cookieInfoUser.Expires = DateTime.Now.AddYears(1);
                    cookieLoginToken.Expires = DateTime.Now.AddHours(2);
                }
                else
                {
                    cookieLoginToken.Expires = DateTime.Now.AddMinutes(60);
                    cookieInfoUser.Expires = DateTime.Now.AddMinutes(60);
                }

                Response.Cookies.Add(cookieInfoUser);
                Response.Cookies.Add(cookieLoginToken);
            }
            else
            {
                var error = new GenericError()
                                {
                                    PageTitle = "Error on LogOn Operations",
                                    PageDescriction = responseObject.Description,
                                    TypeError = responseObject.Title
                                };
                return View("GenericView" , error );
            }
            return View("Index");
            //return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {

            HttpCookie cookie = Response.Cookies["InfoUser"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.MinValue;
            }
            cookie = Response.Cookies["LoginToken"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.MinValue;
            }
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            //ViewData["PasswordLength"] = "";
            ViewData["Title"] = "Create a New Account";
            ViewData["subTitle"] = "Use the form below to update the account. ";
            ViewData["button"] = "Register";
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            RegisterModel teste = model;

            ServiceOutput<CdoUserProfile> userInfo = HttpRequestToService.Register(model);

            if(userInfo.Error )
            {
               GenericError error = new GenericError()
                                        {
                                            PageDescriction = userInfo.Description,
                                            PageTitle = "Error On User Registration",
                                            TypeError = "Register Error"
                                        };
                return View("GenericView", error);
            }
            else
            {
                GenericError message = new GenericError()
                                           {
                                               PageDescriction = userInfo.Description + " - Please check our email to confirm register!",
                                               PageTitle = userInfo.Title,
                                               TypeError = "Thanks for our register"
                                           };

                return  View("GenericView", message);
            }


            
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************
        [HttpGet]
        public ActionResult UpdateRegister()
        {
            //Buscar ao serviço os dados.... 
            try
            {
                HttpCookie loginTokenCookie = Request.Cookies["InfoUser"];

                ServiceOutput<ResponseUser> _userProfiler = HttpRequestToService.GetUserProfile(loginTokenCookie["LoginToken"]);    

                if(!_userProfiler.Error )
                {
                    RegisterModel _model = new RegisterModel();
                    _model.BirthDate = _userProfiler.Value.BirthDate;
                    _model.FirstName = _userProfiler.Value.FirstName;
                    _model.LastName= _userProfiler.Value.LastName;
                    _model.Email = _userProfiler.Value.Email;
                    _model.UserName = _userProfiler.Value.UserName;
                    _model.PostIncidents = _userProfiler.Value.ReporedtIncident;
                    _model.PostVotes = _userProfiler.Value.SubmitedVotes;
                    _model.InvalideIncident = _userProfiler.Value.NegativeIncidents;
                    _model.ValidadeIncidents = _userProfiler.Value.PositiveIncidents;
                    _model.Ratio = _userProfiler.Value.Ratio;
                    _model.HidenUserName = _userProfiler.Value.HideUserName;


                    return View("UpdateProfile",_model);
                }
                throw new Exception(_userProfiler.Description);

            }
            catch (Exception ex)
            {
                GenericError error = new GenericError()
                                         {
                                             PageTitle = "Update Register Error",
                                             PageDescriction = ex.Message,
                                             TypeError = "Error when try getting LoginToken or Profile Info on the server"
                                         };

                return View("GenericView", error);
            }
        }
        [HttpPost]
        public ActionResult UpdateRegister(RegisterModel model)
        {

            HttpCookie loginTokenCookie = Request.Cookies["InfoUser"];
            String loginToken = loginTokenCookie["LoginToken"];


            model.LoginToken = loginToken;
           ServiceOutput<CdoUserProfile> _userProfiler = HttpRequestToService.UpdateUserProfile(model );    



            if(_userProfiler.Error)
            {
                GenericError error = new GenericError()
                {
                    PageTitle = "Update Register Error",
                    PageDescriction = _userProfiler.Description,
                    TypeError = "Error when try getting LoginToken or Profile Info on the server"
                };

                return View("GenericView", error);
            }

            GenericError sucess = new GenericError()
                                      {
                                          PageTitle = "Update Profile Sucess",
                                          PageDescriction = "Your profile is update"
                                      };

            return View("GenericView", sucess);
        }


        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            RegisterModel _model = new RegisterModel();

            try
            {
                HttpCookie loginTokenCookie = Request.Cookies["InfoUser"];

                ServiceOutput<ResponseUser> _userProfiler = HttpRequestToService.GetUserProfile(loginTokenCookie["LoginToken"]);

                if (_userProfiler.Error)
                {   throw new Exception(_userProfiler.Description);}
                else
                {
                    _model.BirthDate = _userProfiler.Value.BirthDate;
                    _model.FirstName = _userProfiler.Value.FirstName;
                    _model.LastName = _userProfiler.Value.LastName;
                    _model.Email = _userProfiler.Value.Email;
                    _model.UserName = _userProfiler.Value.UserName;
                    _model.ConfirmPassword = model.ConfirmPassword;
                    _model.Password = model.NewPassword;
                    _model.OldPassword = model.OldPassword;
                    _model.SecretQuestion = model.SecretQuestion;
                    _model.SecretAnswer = _model.SecretAnswer;
                    _model.LoginToken= loginTokenCookie["LoginToken"];
                    
                }
                ServiceOutput<CdoUserProfile> Resp_userProfiler = HttpRequestToService.UpdateUserProfile(_model);
                if (Resp_userProfiler.Error)
                { throw new Exception(Resp_userProfiler.Description); }
                else
                {
                    return View("ChangePasswordSuccess");
                }
            }
            catch (Exception ex)
            {
                GenericError error = new GenericError()
                {
                    PageTitle = "Update Register Error",
                    PageDescriction = ex.Message,
                    TypeError = "Error when try getting LoginToken or Profile Info on the server"
                };

                return View("GenericView", error);
            }
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}