using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DAL.EFRepository;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Interfaces;
using ForgetTraffic.TrafficIncidences.SolveIncidents;
using StructureMap;

namespace ForgetTraffic.InitializeStructure
{
    public class GeneralInitialize
    {
        public static void Initialize()
        {
            // Hook up the interception
            ObjectFactory.Initialize(
                x =>
                    {
                        x.ForRequestedType<IUnitOfWorkFactory>().TheDefaultIsConcreteType<EFUnitOfWorkFactory>();
                        x.ForRequestedType(typeof(IRepository<>)).TheDefaultIsConcreteType(typeof(EfRepository<>));
                        x.ForRequestedType(typeof(IGenericService<>)).TheDefaultIsConcreteType(typeof(GenericService));

                    }
                );

            // We tell the concrete factory what EF model we want to use
            EFUnitOfWorkFactory.SetObjectContext(() => new ForgetTrafficEntities());
        }

        public static void Commit()
        {
            UnitOfWork.Commit();
        }

        public static void Dispose()
        {
            UnitOfWork.Current.Dispose();
        }
    }
}
