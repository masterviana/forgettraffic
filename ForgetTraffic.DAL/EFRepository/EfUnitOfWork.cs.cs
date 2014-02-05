using System;
using System.Data;
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

    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        public EfUnitOfWork(ObjectContext context)
        {
            Context = context;
            context.ContextOptions.LazyLoadingEnabled = true;
        }

        public ObjectContext Context { get; private set; }

        #region IUnitOfWork Members

        public void Commit()
        {

            try
            {
                Context.SaveChanges();
            }
                //DbUpdateConcurrencyException
                //OptimisticConcurrencyException
            catch (OptimisticConcurrencyException ex)
            {
                Context.SaveChanges();
            }
        }

        //public void Refresh()
        //{
        //    Context.Refresh( RefreshMode.ClientWins, null);
        //}

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}