using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Interfaces;
using ForgetTraffic.TrafficIncidences.SolveIncidents;
using StructureMap;
using ForgetTraffic.ParallelsServices.Interfaces;

namespace ForgetTraffic.ParallelsServices
{
    public class ServiceManager
    {
        public static void Initialize()
        {

            ObjectFactory.Initialize(
               x =>
                   {
                       x.ForRequestedType(typeof(IGenericService<>)).TheDefaultIsConcreteType(typeof(GenericService)) ;
                   }
               );

        }


    }
}
