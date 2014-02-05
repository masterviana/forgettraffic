using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ForgetTraffic.ServiceUtils
{
    public class MailOperations
    {

        public static void SendMailSmtp(
                                           String userCredentialsSmtp,
                                           String passCredentialsSmtp,
                                           String hostAdress,
                                           int port,
                                           String mailTo,
                                           String mailfrom,
                                           String link, 
                                           String subject

                                        )
        {
            System.Net.Mail.MailMessage _message = new System.Net.Mail.MailMessage();
            _message.From = new MailAddress(mailfrom);

            _message.To.Add(mailTo);


            _message.Subject = subject;

            _message.IsBodyHtml = true;
            _message.BodyEncoding = new UTF8Encoding();

            _message.Body = RequestRegister(link);

            SmtpClient smtpClient = new SmtpClient(hostAdress,port);
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(userCredentialsSmtp, passCredentialsSmtp);
            smtpClient.Credentials = credentials;

            smtpClient.Send(_message);


        }

        private static  String RequestRegister(String link)
        {
            return "<div> "
                           + "<p>Automatic Email - Please do not replay this email </p><br/>"
                           + "<p> You've required register on our site :  http://www.forgettraffic.net to confirm your registration please click on the link bellow </p>"
                           + "<p ><a href='"+link+"'> Click on Link -  This link only valid for 2 hour </a>  </p><br/>"
                           + "<p>If you dont request the registation please ignore this email  </p>"
                           + "<p> <a href='http://www.forgettraffic.net' ><img src='http://dl.dropbox.com/u/3343576/FtBannerWithoutBack.png' > </a> </p>"
                           + "<p>  Best Regards FORGET ABOUT TRAFFIC - 2011 </p><br/>"
                           + "<p>Automatic Email - Please do not replay this email </p><br/>"
                           + "</div>"
                      ;
        }


    }
}
