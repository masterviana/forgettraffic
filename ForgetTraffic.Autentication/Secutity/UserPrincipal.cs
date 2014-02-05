using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace ForgetTraffic.Autentication.Secutity
{
    public class UserPrincipal : IPrincipal
    {
        private IIdentity _identity;
        public UserPrincipal(String username)
        {
               _identity = new UserIdentity(username);
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
         }
         
        public IIdentity Identity
        {
            get { return _identity; }
        }
    }
}
