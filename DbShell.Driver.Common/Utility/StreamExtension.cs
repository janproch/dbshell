using System.IO;

namespace DbShell.Driver.Common.Utility
{
    public static class StreamExtension
    {
        public static void Write7BitEncodedInteger(this BinaryWriter stream, int value)
        {
            // Write out an int 7 bits at a time. The high bit of the byte,
            // when on, tells reader to continue reading more bytes.
            uint v = (uint)value; // support negative numbers
            while (v >= 0x80)
            {
                stream.Write((byte)(v | 0x80));
                v >>= 7;
            }
            stream.Write((byte)v);
        }

        public static int Read7BitEncodedInteger(this BinaryReader stream)
        {
            // Read out an int 7 bits at a time. The high bit
            // of the byte when on means to continue reading more bytes.
            int count = 0;
            int shift = 0;
            byte b;
            do
            {
                b = stream.ReadByte();
                count |= (b & 0x7F) << shift;
                shift += 7;
            } while ((b & 0x80) != 0);
            return count;
        }

        public static byte[] ReadAllBytes(this Stream fr)
        {
            var ms = new MemoryStream();
            IOTool.CopyStream(fr, ms);
            return ms.ToArray();
        }

        //public static void WriteStringEx(this BinaryWriter stream, string value)
        //{
        //    byte[] data = Encoding.UTF8.GetBytes(value);
        //    stream.Write7BitEncodedInt(data.Length);
        //    stream.Write(data);
        //}

        //public static string ReadStringEx(this BinaryReader stream)
        //{
        //    int len = stream.Read7BitEncodedInt();
        //    byte[] data = stream.ReadBytes(len);
        //    return Encoding.UTF8.GetString(data);
        //}
    }
}
