using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetTraffic.DataTypes.Error
{
    public class ForgetTrafficError : Exception
    {

        public ForgetTrafficError(String message , int status,String shortTitle) 
            : base(message)
        {

            Status = status;
            Title = shortTitle;
        }

        public String  Title { get; set; }
        public int Status { get; set; }


    }
}
