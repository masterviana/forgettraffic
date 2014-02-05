using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForgetTraffic.Site.Business
{
    public class ResponseObject<T>
    {
            public String Title { get; set; }
            public String Description { get; set; }
            public T Value { get; set; }
            public bool Error { get; set; }
    }
}