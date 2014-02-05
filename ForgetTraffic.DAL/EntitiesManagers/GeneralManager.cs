using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DAL.EFRepository;
using ForgetTraffic.DataModel;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    /*
 * ----------------------------------------------------------------------------------------
 * ----------------------------------------------------------------------------------------
 *              Author       :  Vitor Viana
 *              Date         :  25-05-2011  
 *              Name         :  IRepository
 *              Description  :  Manage the User Entities
 * ----------------------------------------------------------------------------------------
 * ----------------------------------------------------------------------------------------
 *                      Revison List
 *--------------------------------------------------------------------------------------             
 * Author           |       Date                
 * 
 * 
 * */

    public class GeneralManager
    {
        public static void Initialize()
        {
            // Hook up the interception
            ObjectFactory.Initialize(
                x =>
                    {
                        x.ForRequestedType<IUnitOfWorkFactory>().TheDefaultIsConcreteType<EFUnitOfWorkFactory>();
                        x.ForRequestedType(typeof (IRepository<>)).TheDefaultIsConcreteType(typeof (EfRepository<>));

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