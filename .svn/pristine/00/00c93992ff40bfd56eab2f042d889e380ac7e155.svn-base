using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
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

    public class EfRepository<T> : IRepository<T> where T : class
    {
        private ObjectContext _context;
        private IObjectSet<T> _objectSet;

        protected ObjectContext Context
        {
            get { return _context ?? (_context = GetCurrentUnitOfWork<EfUnitOfWork>().Context); }
        }

        protected IObjectSet<T> ObjectSet
        {
            get
            {
                if (_objectSet == null)
                {
                    _objectSet = Context.CreateObjectSet<T>();
                }

                return _objectSet;
            }
        }

        public ForgetTraffic.DAL.Conctracts.IRepository<T> IRepository
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region IRepository<T> Members

        public IQueryable<T> GetQuery()
        {
            return ObjectSet;
        }

        public IEnumerable<T> GetAll()
        {
            return GetQuery().ToList();
        }

        public IEnumerable<T> Find(Func<T, bool> where)
        {
            return ObjectSet.Where(where);
        }

        public T Single(Func<T, bool> where)
        {
            return ObjectSet.SingleOrDefault(where);
        }

        public T First(Func<T, bool> where)
        {
            return ObjectSet.First(where);
        }

        public virtual void Delete(T entity)
        {
            ObjectSet.DeleteObject(entity);
        }

        public virtual void Add(T entity)
        {
            ObjectSet.AddObject(entity);
        }

        public void Attach(T entity)
        {
            ObjectSet.Attach(entity);
        }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (OptimisticConcurrencyException ex)
            {
                //Manage the concurreny problem 
                Context.Refresh(RefreshMode.ClientWins, _objectSet );
                Context.SaveChanges();
            }

        }

        #endregion

        public TUnitOfWork GetCurrentUnitOfWork<TUnitOfWork>()
            where TUnitOfWork : IUnitOfWork
        {
            return (TUnitOfWork) UnitOfWork.Current;
        }
    }
}