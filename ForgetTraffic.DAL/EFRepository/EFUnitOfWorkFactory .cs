using System;
using System.Data.Objects;
using ForgetTraffic.DAL.Conctracts;

namespace ForgetTraffic.DAL.EFRepository
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

    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private static Func<ObjectContext> _objectContextDelegate;
        private static readonly Object _lockObject = new object();

        public EFUnitOfWorkFactory(){}


        #region IUnitOfWorkFactory Members

        

        public IUnitOfWork Create()
        {
            ObjectContext context;

            lock (_lockObject)
            {
                context = _objectContextDelegate();
            }


            return new EfUnitOfWork(context);
        }

        #endregion

        public static void SetObjectContext(Func<ObjectContext> objectContextDelegate)
        {

            _objectContextDelegate = objectContextDelegate;
        }


    }
}