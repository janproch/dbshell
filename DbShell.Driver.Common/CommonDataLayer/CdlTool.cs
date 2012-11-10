using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Xml;
using System.Globalization;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public static partial class CdlTool
    {
        public static bool GetValueAsXml(object value, ref string xtype, ref string xdata)
        {
            var holder = new CdlValueHolder();
            holder.ReadFrom(value);
            return GetValueAsXml(holder, ref xtype, ref xdata);
        }

        public static bool GetValueAsXml(ICdlValueReader rec, ref string xtype, ref string xdata)
        {
            var type = rec.GetFieldType();
            if (type == TypeStorage.Null) return false;
            switch (type)
            {
                case TypeStorage.Boolean:
                    xtype = "bool";
                    xdata = rec.GetBoolean() ? "1" : "0";
                    break;
                case TypeStorage.Byte:
                    xtype = "byte";
                    xdata = rec.GetByte().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Int16:
                    xtype = "i16";
                    xdata = rec.GetInt16().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Int32:
                    xtype = "i32";
                    xdata = rec.GetInt32().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Int64:
                    xtype = "i64";
                    xdata = rec.GetInt64().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.SByte:
                    xtype = "sbyte";
                    xdata = rec.GetSByte().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.UInt16:
                    xtype = "u16";
                    xdata = rec.GetUInt16().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.UInt32:
                    xtype = "u32";
                    xdata = rec.GetUInt32().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.UInt64:
                    xtype = "u64";
                    xdata = rec.GetUInt64().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.DateTime:
                    xtype = "datetime";
                    xdata = rec.GetDateTime().ToString("s", CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.DateTimeEx:
                    xtype = "dtex";
                    xdata = rec.GetDateTimeEx().ToStringNormalized();
                    break;
                case TypeStorage.DateEx:
                    xtype = "date";
                    xdata = rec.GetDateEx().ToStringNormalized();
                    break;
                case TypeStorage.TimeEx:
                    xtype = "time";
                    xdata = rec.GetTimeEx().ToStringNormalized();
                    break;
                case TypeStorage.Decimal:
                    xtype = "decimal";
                    xdata = rec.GetDecimal().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Float:
                    xtype = "float";
                    xdata = rec.GetFloat().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Double:
                    xtype = "double";
                    xdata = rec.GetDouble().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.String:
                    xtype = "str";
                    xdata = rec.GetString();
                    break;
                case TypeStorage.Guid:
                    xtype = "guid";
                    xdata = rec.GetGuid().ToString();
                    break;
                case TypeStorage.ByteArray:
                    {
                        xtype = "blob";
                        byte[] data = rec.GetByteArray();
                        xdata = Convert.ToBase64String(data);
                    }
                    break;
                //case TypeStorage.Array:
                //    {
                //        xtype = "array";
                //        xdata = CdlArray.ToString(rec.GetArray());
                //    }
                //    break;
            }
            return true;
        }

        public static void SaveToXml(TableInfo table, IEnumerable records, XmlWriter xw)
        {
            List<string> ids = new List<string>();
            foreach (var col in table.Columns) ids.Add(XmlTool.NormalizeIdentifier(col.Name));

            foreach (ICdlRecord rec in records)
            {
                xw.WriteStartElement("Row");
                for (int i = 0; i < rec.FieldCount; i++)
                {
                    rec.ReadValue(i);
                    string xdata = "", xtype = "";
                    if (!GetValueAsXml(rec, ref xtype, ref xdata)) continue;
                    xw.WriteStartElement(ids[i]);
                    xw.WriteAttributeString("t", xtype);
                    xw.WriteString(xdata);
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();
            }
        }

        public static object GetValueFromXml(string xtype, string xdata)
        {
            switch (xtype)
            {
                case "bool":
                    return xdata == "1";
                case "byte":
                    return Byte.Parse(xdata, CultureInfo.InvariantCulture);
                case "i16":
                    return Int16.Parse(xdata, CultureInfo.InvariantCulture);
                case "i32":
                    return Int32.Parse(xdata, CultureInfo.InvariantCulture);
                case "i64":
                    return Int64.Parse(xdata, CultureInfo.InvariantCulture);
                case "sbyte":
                    return SByte.Parse(xdata, CultureInfo.InvariantCulture);
                case "u16":
                    return UInt16.Parse(xdata, CultureInfo.InvariantCulture);
                case "u32":
                    return UInt32.Parse(xdata, CultureInfo.InvariantCulture);
                case "u64":
                    return UInt64.Parse(xdata, CultureInfo.InvariantCulture);
                case "datetime":
                    return DateTime.ParseExact(xdata, "s", CultureInfo.InvariantCulture);
                case "dtex":
                    return DateTimeEx.ParseNormalized(xdata);
                case "date":
                    return DateEx.ParseNormalized(xdata);
                case "time":
                    return TimeEx.ParseNormalized(xdata);
                case "str":
                    return xdata;
                case "decimal":
                    return Decimal.Parse(xdata, CultureInfo.InvariantCulture);
                case "float":
                    return Single.Parse(xdata, CultureInfo.InvariantCulture);
                case "double":
                    return Double.Parse(xdata, CultureInfo.InvariantCulture);
                case "guid":
                    return new Guid(xdata);
                case "blob":
                    return Convert.FromBase64String(xdata);
                //case "array":
                //    values[pos] = CdlArray.Parse(xdata);
                //    break;
            }
            return null;
        }

        public static IEnumerable<ICdlRecord> LoadFromXml(TableInfo table, XmlReader reader)
        {
            reader.MoveToContent();
            reader.Read();
            reader.MoveToContent();

            Dictionary<string, int> colPos = new Dictionary<string, int>();
            int index = 0;
            foreach (var col in table.Columns)
            {
                colPos[XmlTool.NormalizeIdentifier(col.Name)] = index;
                index++;
            }

            while (reader.NodeType == XmlNodeType.Element)
            {
                if (reader.LocalName != "Row") throw new XmlFormatError(String.Format("DBSH-00070 Bad xml, expected tag {0}, found {1}", "Row", reader.LocalName));
                reader.Read();
                reader.MoveToContent();
                object[] values = new object[table.Columns.Count];
                for (int i = 0; i < values.Length; i++) values[i] = DBNull.Value;
                while (reader.NodeType == XmlNodeType.Element)
                {
                    string colname = reader.LocalName;
                    int pos = colPos[colname];

                    string xtype = reader.GetAttribute("t");
                    reader.Read();
                    string xdata = "";
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        xdata = reader.Value;
                        reader.Read();
                    }

                    values[pos] = GetValueFromXml(xtype, xdata);

                    if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName == colname)
                    { // skip end of element
                        reader.Read();
                    }
                }
                yield return new ArrayDataRecord(table, values);
                if (reader.NodeType == XmlNodeType.EndElement) reader.Read();
            }
        }
        public static bool EqualRecords(object[] v1, object[] v2)
        {
            if (v1.Length != v2.Length) return false;
            for (int i = 0; i < v1.Length; i++)
            {
                if (!EqualValues(v1[i], v2[i])) return false;
            }
            return true;
        }
        public static bool EqualValues(object v1, object v2)
        {
            if (v1 == DBNull.Value || v1 == null) return v2 == DBNull.Value || v2 == null;
            if (v2 == DBNull.Value || v2 == null) return v1 == DBNull.Value || v1 == null;
            Type t1 = v1.GetType(), t2 = v2.GetType();
            TypeCode c1 = Type.GetTypeCode(t1), c2 = Type.GetTypeCode(t2);
            if (t1 == typeof(byte[]))
            {
                return t2 == typeof(byte[]) && ((byte[])v1).EqualSequence((byte[])v2);
            }
            // datetime - TBD
            return v1.ToString() == v2.ToString();
        }
        public static void SaveValueToXml(object value, XmlElement xml)
        {
            string xdata = "", xtype = "";
            if (GetValueAsXml(value, ref xtype, ref xdata))
            {
                xml.SetAttribute("t", xtype);
                xml.InnerText = xdata;
            }
        }
        public static object LoadValueFromXml(XmlElement xml)
        {
            string xtype = xml.GetAttribute("t"), xdata = xml.InnerText;
            return GetValueFromXml(xtype, xdata);
        }

        public static void SkipRecord(BinaryReader fr)
        {
            int len = fr.Read7BitEncodedInteger();
            fr.BaseStream.Seek(len, SeekOrigin.Current);
        }

        public static ArrayDataRecord LoadRecord(BinaryReader fr, TableInfo table)
        {
            var res = new ArrayDataRecord(table);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                res.SeekValue(i);
                res.ReadValue(fr);
            }
            return res;
        }

        public static void LoadRecord(BinaryReader fr, ArrayDataRecord record)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                record.SeekValue(i);
                record.ReadValue(fr);
            }
        }

        public static void SaveRecord(int fldcount, ICdlRecord record, BinaryWriter stream)
        {
            var fw = new StreamValueWriter(stream);
            if (fldcount != record.FieldCount) throw new InternalError("DBSH-00034 field count mitchmatch");
            for (int i = 0; i < fldcount; i++)
            {
                record.ReadValue(i);
                fw.ReadFrom(record);
            }
        }
    }
}
