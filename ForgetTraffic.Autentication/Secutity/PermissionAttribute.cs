using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using ForgetTraffic.DataTypes;

namespace ForgetTraffic.Autentication.Secutity
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    [Serializable]
    public class PermissionAttribute : CodeAccessSecurityAttribute
    {
        private String permitName;
        private Action<String> _action;
        public BehaviorDelegate _exe;

        public PermissionAttribute(SecurityAction sa) : base(sa) { }

        public String Name
        {
            get { return permitName; }
            set { permitName  = value; }
        }

        public override IPermission CreatePermission()
        {
            return new Permission(permitName , _action );
        }

    }
}
