using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace ForgetTraffic.Autentication.Secutity
{
    public class UserIdentity :  IIdentity
    {
        private String _username;
        public UserIdentity(String user)
        {
            _username = user;
        }

        public string Name
        {
            get { return _username; }
        }

        public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
    }
}
