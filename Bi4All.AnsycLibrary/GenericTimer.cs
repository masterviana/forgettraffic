 using System;
using System.Threading;

namespace ForgetTraffic.AnsycLibrary
{
    /// <summary>
    /// Create by Vítor Viana 25.01.2011
    /// Class responsavel por gerir um timer, usando o thread pool 
    /// para manter a aplicavel o mais escalavel possivel;
    /// </summary>
    public class GenericTimer<T> : IDisposable
    {
        private TimeSpan _intervalDue;
        private int _initalDelay;
        private volatile bool _sleep;
        private volatile bool _goingDie;
        private volatile Object _snyc;
        private volatile bool _paused;
        private DoAction<T> _action;
        private T _owner;

        public GenericTimer(T owner,TimeSpan interval , int initalDelay, DoAction<T> action) 
        {
            _paused = false;
            _intervalDue = interval;
            _initalDelay = initalDelay;
            _snyc = new Object();
            _action = action;
            _owner = owner;

            ThreadPool.QueueUserWorkItem(consumer);
        }

        private void consumer(Object state) 
        {
            lock (_snyc) 
            {
                Monitor.Exit(_snyc);
                Thread.Sleep(_initalDelay);
                Monitor.Enter(_snyc);

                while (!_goingDie)
                {
                    try
                    {
                        _sleep = true;
                        Monitor.Wait(_snyc,_intervalDue);
                    }
                    catch (Exception ex) 
                    {
                        _sleep = false;
                        if (_goingDie) return;
                    }
                    _sleep = false;
                    if (_goingDie) return;
                    if (!_paused) 
                    {
                        Monitor.Exit(_snyc);
                        _action(_owner, state);
                        Monitor.Enter(_snyc);
                    }
                }
            }
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Resume() 
        {
            lock (_snyc)
            {
                _paused = false;
                Monitor.PulseAll(_snyc);
            }
        }

        public void Dispose()
        {
            lock(_snyc)
            {
                _goingDie = true;
                Monitor.PulseAll(_snyc);
            }
        }
    }
}
