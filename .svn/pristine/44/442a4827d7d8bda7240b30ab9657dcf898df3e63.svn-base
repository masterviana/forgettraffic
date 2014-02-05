using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ForgetTraffic.AnsycLibrary
{
   

    /// <summary>
    /// Create by Vítor Viana 24-01-2011
    /// 
    /// Esta classe representa um fila, de trabalho assincrona.Quer isto dizer que 
    /// quando se deposita, algum trabalho nesta fila, é garantido que esse trabalho é 
    /// executado numa thread à parte. E paralelamente à thread que colocou a requisição de execução.
    /// Com o metodo de interface public a receber um delegate doAction<T> garante-se que so se aceita
    /// metodos com este definição. E esse método é o metodo que vai, processar o trabalho.
    /// 
    /// É usado o threadPool para garantir a escalabilidade da aplicação. Uma vez que desta forma 
    /// delage-se para o CLR a responsabilidade de gerir o tempo de vida das threads
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericWorkedQueue<T> : IDisposable
    {
        /// <summary>
        /// Fila que guarda as requisições.
        /// </summary>
        private readonly List<T> _list;
        /// <summary>
        /// Dá a ultima leitura, se a thread responsavel por despachar as requisões está a dormir ou activa;
        /// </summary>
        private volatile bool _isSleep;
        private volatile bool _goingDie;
        private DoAction<T> _action;
        private ThreadPriority _priority;

        /// <summary>
        /// Construtor publico
        /// </summary>
        /// <param name="_event"> Terá de ver passado o evento, que vai executado na fila de requisição!</param>
        public GenericWorkedQueue(DoAction<T> _event , ThreadPriority priority) 
        {
            _priority = priority;
            _action = _event;
            _list = new System.Collections.Generic.List<T>();
            ThreadPool.QueueUserWorkItem(processQueue);

        }


        private void processQueue(Object snyState)
        {
            Thread.CurrentThread.Priority = _priority;

            lock (_list) 
            {
                try
                {
                    T actionValue;
                    while (!_goingDie)
                    {
                        try
                        {
                            if (_list.Count == 0)
                            {
                                _isSleep = true;
                                Monitor.Wait(_list);
                            }
                        }
                        catch (Exception ex)
                        {
                            _isSleep = false;
                            return;
                        }

                        _isSleep = false;
                        if (_list.Count > 0)
                        {
                            actionValue = _list.ElementAt(0);
                            _list.RemoveAt(0);

                            Monitor.Exit(_list);
                            _action(actionValue, snyState);
                            Monitor.Enter(_list);

                        }

                    }
                }
                catch (Exception ex) { throw ex; }
            }
        }

        /// <summary>
        /// Metodo que vai fazer de interface publica, rebece um elemento do 
        /// </summary>
        /// <param name="action"></param>
        public void addWork(T action) 
        {
            lock (_list) 
            {
                _list.Add(action);
                if (_isSleep) Monitor.Pulse(_list);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            lock (_list)
            {
                _goingDie = true;
                Monitor.PulseAll(_list);
            }
        }
    }
}
