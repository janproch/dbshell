using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DbShell.Driver.Common.Utility
{
    public enum PriorityLevel
    {
        Low, Normal, Hight
    }

    public class WaitQueue<T> : IDisposable
    {
        AutoResetEvent m_onPutEvent = new AutoResetEvent(false);
        AutoResetEvent m_onGetEvent = new AutoResetEvent(false);
        Dictionary<PriorityLevel, LinkedList<T>> m_queue = new Dictionary<PriorityLevel, LinkedList<T>>();
        int? m_maxSize = null;
        int m_length;
        //Queue<T> m_queue = new Queue<T>();

        static PriorityLevel[] m_priorities;
        bool m_closed;
        bool m_disposed;

        static WaitQueue()
        {
            List<PriorityLevel> levels = new List<PriorityLevel>();
            foreach (PriorityLevel lev in Enum.GetValues(typeof(PriorityLevel)))
            {
                levels.Add(lev);
            }
            levels.Reverse();
            m_priorities = levels.ToArray();
        }

        public WaitQueue(int maxSize)
            : this()
        {
            m_maxSize = maxSize;
        }

        public WaitQueue()
        {
            foreach (PriorityLevel lev in m_priorities) m_queue[lev] = new LinkedList<T>();
        }

        public void Put(T element)
        {
            Put(PriorityLevel.Normal, false, element);
        }

        private void DoPut(PriorityLevel priority, bool behaveAsStack, T element)
        {
            if (behaveAsStack) m_queue[priority].AddFirst(element);
            else m_queue[priority].AddLast(element);
            m_length++;
            m_onPutEvent.Set();
        }

        public void Put(PriorityLevel priority, bool behaveAsStack, T element)
        {
            for (; ; )
            {
                lock (m_queue)
                {
                    if (m_closed) throw new QueueClosedError("DBSH-00057");
                    if (m_maxSize != null && m_queue[priority].Count >= m_maxSize.Value)
                    {
                        goto wait;
                    }
                    else
                    {
                        DoPut(priority, behaveAsStack, element);
                        return;
                    }
                }
            wait:
                m_onGetEvent.WaitOne();
            }
        }

        private bool DoGet(bool remove, out T res)
        {
            if (m_closed) throw new QueueClosedError("DBSH-00058");
            foreach (PriorityLevel level in m_priorities)
            {
                if (m_queue[level].Count > 0)
                {
                    res = m_queue[level].First.Value;
                    if (remove)
                    {
                        m_queue[level].RemoveFirst();
                        m_length--;
                        m_onGetEvent.Set();
                    }
                    return true;
                }
            }
            res = default(T);
            return false;
        }

        //public T Get(TimeSpan timeout)
        //{
        //    for (; ; )
        //    {
        //        lock (m_queue)
        //        {
        //            T res;
        //            if (DoGet(true, out res)) return res;
        //        }
        //        m_onPutEvent.WaitOne(timeout, false);
        //    }
        //}

        public T Get()
        {
            for (; ; )
            {
                lock (m_queue)
                {
                    T res;
                    if (DoGet(true, out res)) return res;
                }
                m_onPutEvent.WaitOne();
            }
        }

        // waits for element in queue and returns it
        public T Peek()
        {
            for (; ; )
            {
                lock (m_queue)
                {
                    T res;
                    if (DoGet(false, out res)) return res;
                }
                m_onPutEvent.WaitOne();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            m_disposed = true;
            m_onPutEvent.Close();
            m_onGetEvent.Close();
        }

        #endregion

        public void Close()
        {
            if (m_disposed) return;
            lock (m_queue)
            {
                m_closed = true;
            }
            m_onPutEvent.Set();
            m_onGetEvent.Set();
        }

        public int Length
        {
            get { return m_length; }
        }
    }
}
