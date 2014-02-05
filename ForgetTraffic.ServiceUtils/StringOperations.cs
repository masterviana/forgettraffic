using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetTraffic.ServiceUtils
{
    public class StringOperations
    {
        public static string PrivacyName(String username)
        {
            StringBuilder builder = new StringBuilder(username.Length);
            builder.Append(username.ElementAt(0));

            for (int i = 0; i < username.Length - 3; i++)
            {
                builder.Append('*');
            }

            builder.Append(username.ElementAt(username.Length - 1));
            return builder.ToString();
        }
    }
}
