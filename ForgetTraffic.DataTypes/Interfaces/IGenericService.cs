using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetTraffic.DataTypes.Interfaces
{

    public interface IGenericService<T> where T : class
    {
        void Solve(T tInput , Object snyc);
    }
   
}
