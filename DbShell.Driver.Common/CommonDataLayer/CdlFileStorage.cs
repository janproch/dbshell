using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlFileStorage : ICdlWriter
    {
        private Stream _cache;
        private string _file;
        private const int BUFFER_SIZE = 50;
        private int _serializedRows = 0;
        private List<long> _directory = new List<long>();
        private TableInfo _table;
        private Chunk _currentChunk;

        private class Chunk
        {
            internal List<int> Lengths = new List<int>();
            internal MemoryStream Data = new MemoryStream();

            internal int Count
            {
                get { return Lengths.Count; }
            }

            private BinaryWriter m_writer;

            internal Chunk()
            {
                m_writer = new BinaryWriter(Data);
            }

            internal void SaveRecord(ICdlRecord rec)
            {
                long pos0 = Data.Length;
                CdlTool.SaveRecord(rec.FieldCount, rec, m_writer);
                Lengths.Add((int) (Data.Length - pos0));
            }

            internal void Save(Stream fw)
            {
                BinaryWriter bw = new BinaryWriter(fw);
                bw.Write(Count);
                foreach (int i in Lengths) bw.Write(i);
                byte[] data = Data.ToArray();
                bw.Write(data);
            }
        }

        internal class ChunkInfo
        {
            internal int[] Lengths;
            internal int ChunkSize;

            internal int Count
            {
                get { return Lengths.Length; }
            }

            internal static ChunkInfo LoadInfo(BinaryReader br)
            {
                int size = br.ReadInt32();
                var res = new ChunkInfo();
                res.Lengths = new int[size];
                for (int i = 0; i < size; i++)
                {
                    int s = br.ReadInt32();
                    res.Lengths[i] = s;
                    res.ChunkSize += s;
                }
                return res;
            }
        }

        public CdlFileStorage(TableInfo table)
        {
            _file = Path.GetTempFileName();
            _cache = new FileStream(_file, FileMode.Create);
            _table = table;
        }


        private void FlushChunk(Chunk chunk)
        {
            lock (_directory)
            {
                _cache.Seek(0, SeekOrigin.End);
                _directory.Add(_cache.Position);
                chunk.Save(_cache);
                _serializedRows += chunk.Count;
            }
        }


        public CdlTable LoadTableData(int start = 0, int? count = null)
        {
            lock (_directory)
            {
                CdlTable table = new CdlTable(_table);

                if (count == null) count = _serializedRows;

                if (start >= _serializedRows) return table;
                int curdic = start/BUFFER_SIZE, skiprec = start%BUFFER_SIZE;
                _cache.Seek(_directory[curdic], SeekOrigin.Begin);

                int availtables = _directory.Count - curdic;
                BinaryReader br = new BinaryReader(_cache);
                while (table.Rows.Count < count && availtables >= 1)
                {
                    ChunkInfo info = ChunkInfo.LoadInfo(br);
                    if (skiprec > 0)
                    {
                        int skipbytes = 0;
                        for (int i = 0; i < skiprec; i++) skipbytes += info.Lengths[i];
                        _cache.Seek(skipbytes, SeekOrigin.Current);
                    }
                    int rec = skiprec;

                    while (rec < info.Count)
                    {
                        table.AddRowInternal(CdlTool.LoadRecord(br, _table));
                        rec++;
                    }
                    availtables--;
                    skiprec = 0;
                }
                return table;
            }
        }

        public TableInfo Structure
        {
            get { return _table; }
        }

        public int RowCount
        {
            get { return _serializedRows; }
        }


        public void Write(ICdlRecord row)
        {
            if (_currentChunk == null)
            {
                _currentChunk = new Chunk();
            }

            _currentChunk.SaveRecord(row);

            if (_currentChunk.Count >= BUFFER_SIZE)
            {
                FlushChunk(_currentChunk);
                _currentChunk = null;
            }
        }

        public void Flush()
        {
            if (_currentChunk == null) return;
            FlushChunk(_currentChunk);
            _currentChunk = null;
        }

        public event Action Disposing;

        public void Dispose()
        {
            _directory = null;
#if !NETSTANDARD2_0
            _cache.Close();
#else
            _cache.Dispose();
#endif
            System.IO.File.Delete(_file);

            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        public IEnumerable<ICdlRecord> EnumRows(ArrayDataRecord record)
        {
            int page = 0;
            while (page < _directory.Count)
            {
                lock (_directory)
                {
                    BinaryReader br = new BinaryReader(_cache);
                    _cache.Seek(_directory[page], SeekOrigin.Begin);
                    ChunkInfo info = ChunkInfo.LoadInfo(br);
                    for (int i = 0; i < info.Count; i++)
                    {
                        if (record == null)
                        {
                            yield return CdlTool.LoadRecord(br, _table);
                        }
                        else
                        {
                            CdlTool.LoadRecord(br, record);
                            yield return record;
                        }
                    }
                }
                page++;
            }
        }

        public ICdlReader CreateReader()
        {
            var reader = new CdlStorageReader(Structure);
            reader.SetEnumerator(EnumRows(reader));
            return reader;
        }
    }
}
