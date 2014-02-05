using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetTraffic.SapoTraffic.Objects
{
    public class ResponseService<T>
    {
            public String Title { get; set; }
            public String Description { get; set; }
            public T Value { get; set; }
            public bool Error { get; set; }
    }
}
