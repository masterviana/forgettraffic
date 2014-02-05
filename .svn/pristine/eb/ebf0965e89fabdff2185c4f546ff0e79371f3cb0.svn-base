using System.Web.Script.Serialization;
using ForgetTraffic.Site.Models;

namespace ForgetTraffic.Site.Business
{
    public class RaperToForgetService
    {
        public static string CreateUser(RegisterModel model)
        {
            var json_serializer = new JavaScriptSerializer();

            return json_serializer.Serialize(model);
        }
    }
}