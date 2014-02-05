using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Web.Security;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataTypes.Error;

namespace ForgetTraffic.Autentication.Secutity
{
    public class Permission : IPermission
    {
        private string _namepremission;
        private RoleProvider pdp;
        private Action<String> _action;

        public Permission(string namePremission , Action<String> action)
        {
            _action = _action;
            _namepremission = namePremission;
            pdp = new RolesManagement();
        }

        

        #region IPermission Members

        public IPermission Copy()
        {
            throw new NotImplementedException();
        }

        public void Demand()
        {
            string username = System.Threading.Thread.CurrentPrincipal.Identity.Name;

            List<string> permission = new List<string>();
            string[] rolesForUser = pdp.GetRolesForUser(username);

            foreach (string s in rolesForUser)
            {
                permission.AddRange( RoleManager.GetAllPermitionForOneRole(s));
            }

            if (_action != null)
                _action(username);

            if (!permission.Contains(_namepremission))
                throw new AuthenticationException();
        }

        public IPermission Intersect(IPermission target)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IPermission target)
        {
            return false;
        }

        public IPermission Union(IPermission target)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ISecurityEncodable Members

        public void FromXml(SecurityElement e)
        {
            throw new NotImplementedException();
        }

        public SecurityElement ToXml()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
