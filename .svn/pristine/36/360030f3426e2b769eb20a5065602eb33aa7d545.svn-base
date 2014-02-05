using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DataTypes.RestTypes;

namespace AboutTraffic.WsRestService
{
    public interface IAboutTrafficRestOperations
    {

        #region Manage User Manage

        String LogOn(String userName , String password);
        String CreateUser(String userName, String password, String email, String birthDate);
        String Update(String userName, String password, String newPass);

        #endregion

        #region Traffic Ocurrence Manage

       void PutOccurrence(Incidence info);

       IncidenceReturn[] GetAllOccurrence();

       IncidenceReturn[] GetOccurrenceByDistrict( String distrito );

        #endregion


    }
}
