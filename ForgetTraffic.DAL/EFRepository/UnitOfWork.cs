using System;
using System.Collections;
using System.Threading;
using System.Web;
using ForgetTraffic.DAL.Conctracts;
using StructureMap;

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

    public static class UnitOfWork
    {
        private const string HTTPCONTEXTKEY = "ForgetTraffic.DAL.EFRepository.Base.HttpContext.Key";

        private static IUnitOfWorkFactory _unitOfWorkFactory;
        private static readonly Hashtable _threads = new Hashtable();

        public static IUnitOfWork Current
        {
            get
            {
                IUnitOfWork unitOfWork = GetUnitOfWork();

                if (unitOfWork == null)
                {
                    _unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();

                    unitOfWork = _unitOfWorkFactory.Create();
                    SaveUnitOfWork(unitOfWork);
                }

                return unitOfWork;
            }
        }

        public static void Commit()
        {
            IUnitOfWork unitOfWork = GetUnitOfWork();

            if (unitOfWork != null)
            {
                unitOfWork.Commit();

                if (_threads.ContainsKey(Thread.CurrentThread.Name))
                {
                    _threads.Remove(Thread.CurrentThread.Name);
                    //_threads[Thread.CurrentThread.Name] = null;
                }
                    
                    
            }
        }

        private static IUnitOfWork GetUnitOfWork()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items.Contains(HTTPCONTEXTKEY))
                {
                    return (IUnitOfWork) HttpContext.Current.Items[HTTPCONTEXTKEY];
                }

                return null;
            }
            else
            {
                Thread thread = Thread.CurrentThread;
                String aux = thread.Name;
                if (string.IsNullOrEmpty(thread.Name))
                {
                    thread.Name = Guid.NewGuid().ToString();
                    return null;
                }
                else
                {
                    lock (_threads.SyncRoot)
                    {
                        if (!_threads.ContainsKey(Thread.CurrentThread.Name))
                            return null;

                        IUnitOfWork _ret = _threads[Thread.CurrentThread.Name] as IUnitOfWork;
                        return _ret;
                    }
                }
            }
        }

        private static void SaveUnitOfWork(IUnitOfWork unitOfWork)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[HTTPCONTEXTKEY] = unitOfWork;
            }
            else
            {
                lock (_threads.SyncRoot)
                {
                    _threads[Thread.CurrentThread.Name] = unitOfWork;
                }
            }
        }
    }
}