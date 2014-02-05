using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ForgetTraffic.DataTypes.RestTypes;

namespace AboutTraffic.WsRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IAboutTrafficRestOperations
    {
        public string LogOn(string userName, string password)
        {
            return String.Format(" chamou para o user {0} e com a pass {1} ",userName,password);
        }

        public string CreateUser(string userName, string password, string email, string birthDate)
        {
            throw new NotImplementedException();
        }

        public string Update(string userName, string password, string newPass)
        {
            throw new NotImplementedException();
        }

        public void PutOccurrence(Incidence info, OccurrenceInfoOptional optional)
        {
            throw new NotImplementedException();
        }

        public IncidenceReturn[] GetAllOccurrence()
        {
            throw new NotImplementedException();
        }

        public IncidenceReturn[] GetOccurrenceByDistrict(string distrito)
        {
            throw new NotImplementedException();
        }
    }
}
