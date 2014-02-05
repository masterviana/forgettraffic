using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgetTraffic.DAL.Conctracts
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

    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetQuery();

        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> where);
        T Single(Func<T, bool> where);
        T First(Func<T, bool> where);

        void Delete(T entity);
        void Add(T entity);
        void Attach(T entity);
        void SaveChanges();
    }
}