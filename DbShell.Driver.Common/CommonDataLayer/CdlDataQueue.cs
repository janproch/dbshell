using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlDataQueue
    {
        class Element
        {
            internal bool IsEof;
            internal ICdlRecord Record;
            //internal Exception Error;
        }

        const int MAX_SIZE = 0x1000;
        WaitQueue<Element> m_queue = new WaitQueue<Element>(MAX_SIZE);
        bool m_wasEof;
        Exception m_error;

        public CdlDataQueue(TableInfo format)
        {
            Format = format;
        }

        public ICdlRecord GetRecord()
        {
            try
            {
                Element res = m_queue.Get();
                if (res.IsEof) throw new Exception("DBSH-00000 Eof reached");
                ICdlRecord rec = res.Record;
                return rec;
            }
            catch (QueueClosedError)
            {
                if (m_error != null) throw new QueueClosedError("DBSH-00000", m_error);
                throw new QueueClosedError("DBSH-00000");
            }
        }

        public void PutError(Exception e)
        {
            m_error = e;
        }

        public void CloseReading()
        {
            m_queue.Close();
        }

        public void CloseWriting()
        {
            if (m_wasEof) return;
            m_queue.Close();
        }

        public void PutRecord(ICdlRecord record)
        {
            object[] values = new object[record.FieldCount];
            record.GetValues(values);
            ICdlRecord copy = new ArrayDataRecord(Format, values);
            m_queue.Put(new Element { Record = copy });
        }

        public TableInfo Format { get; private set; }

        public void PutEof()
        {
            m_queue.Put(new Element { IsEof = true });
            m_wasEof = true;
        }

        public bool IsEof
        {
            get { return m_queue.Peek().IsEof; }
        }
    }
}
