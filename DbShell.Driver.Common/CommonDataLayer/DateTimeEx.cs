using System;
using System.IO;
using System.Globalization;

namespace DbShell.Driver.Common.CommonDataLayer
{
    [Flags]
    public enum DateExFlags : byte
    {
        SkipDate = 1,
    }

    public struct DateEx
    {
        short m_year;

        byte m_month;
        byte m_day;

        DateExFlags m_flags;

        public int Day
        {
            get { return m_day; }
            set { m_day = (byte)value; }
        }
        public int Month
        {
            get { return m_month; }
            set { m_month = (byte)value; }
        }
        public int Year
        {
            get { return m_year; }
            set { m_year = (short)value; }
        }
        public bool SkipDate
        {
            get { return (m_flags & DateExFlags.SkipDate) != 0; }
            set { if (value) m_flags |= DateExFlags.SkipDate; else m_flags &= ~DateExFlags.SkipDate; }
        }
        public bool IsNull
        {
            get { return SkipDate; }
        }
        public bool IsValid
        {
            get
            {
                try
                {
                    new DateTime(m_year, m_month, m_day);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
        public void SetNull()
        {
            SkipDate = true; 
        }
        public DateTimeEx AsDateTime
        {
            get
            {
                DateTimeEx res = new DateTimeEx();
                res.DatePart = this;
                return res;
            }
            set
            {
                this = value.DatePart;
            }
        }

        public void WriteTo(BinaryWriter stream)
        {
            stream.Write((byte)m_flags);
            if (!SkipDate)
            {
                stream.Write(m_year);
                stream.Write(m_month);
                stream.Write(m_day);
            }
        }

        public static DateEx FromStream(BinaryReader stream)
        {
            DateEx res = new DateEx();
            res.m_flags = (DateExFlags)stream.ReadByte();
            if (!res.SkipDate)
            {
                res.m_year = stream.ReadInt16();
                res.m_month = stream.ReadByte();
                res.m_day = stream.ReadByte();
            }
            return res;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            var dtfi = DateTimeFormatInfo.GetInstance(provider);
            return DateTimeExFormat.FormatCustomized(AsDateTime, format, dtfi);
        }

        public string ToStringNormalized()
        {
            return ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
        }

        public override string ToString()
        {
            return ToStringNormalized();
        }

        public static DateEx ParseNormalized(string value)
        {
            return DateTimeEx.Parse(value, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo).DatePart;
        }

    }

    [Flags]
    public enum TimeExFlags : byte
    {
        SkipTime = 2,
        SkipOffset = 4,
        SkipNanosecond = 8,
    }
    public struct TimeEx
    {
        int m_nanosecond;

        TimeExFlags m_flags;
        byte m_second;
        byte m_hour;
        byte m_minute;

        short m_offset;

        public int Second
        {
            get { return m_second; }
            set { m_second = (byte)value; }
        }
        public int Minute
        {
            get { return m_minute; }
            set { m_minute = (byte)value; }
        }
        public int Hour
        {
            get { return m_hour; }
            set { m_hour = (byte)value; }
        }
        public int Nanosecond
        {
            get { return m_nanosecond; }
            set { m_nanosecond = value; }
        }
        public int _Millisecond
        {
            get { return m_nanosecond / 1000000; }
            set { m_nanosecond = value * 1000000; }
        }
        public bool SkipTime
        {
            get { return (m_flags & TimeExFlags.SkipTime) != 0; }
            set { if (value) m_flags |= TimeExFlags.SkipTime; else m_flags &= ~TimeExFlags.SkipTime; }
        }
        public bool SkipNanoSecond
        {
            get { return (m_flags & TimeExFlags.SkipNanosecond) != 0; }
            set { if (value) m_flags |= TimeExFlags.SkipNanosecond; else m_flags &= ~TimeExFlags.SkipNanosecond; }
        }
        public bool SkipOffset
        {
            get { return (m_flags & TimeExFlags.SkipOffset) != 0; }
            set { if (value) m_flags |= TimeExFlags.SkipOffset; else m_flags &= ~TimeExFlags.SkipOffset; }
        }
        public bool IsNull
        {
            get { return SkipTime && SkipOffset && SkipNanoSecond; }
        }
        public void SetNull()
        {
            SkipTime = true; SkipOffset = true; SkipNanoSecond = true;
        }
        public int Offset
        {
            get { return m_offset; }
            set { m_offset = (short)value; }
        }
        public DateTimeEx AsDateTime
        {
            get
            {
                DateTimeEx res = new DateTimeEx();
                res.TimePart = this;
                return res;
            }
            set
            {
                this = value.TimePart;
            }
        }

        public void WriteTo(BinaryWriter stream)
        {
            stream.Write((byte)m_flags);
            if (!SkipTime)
            {
                stream.Write(m_hour);
                stream.Write(m_minute);
                stream.Write(m_second);
            }
            if (!SkipNanoSecond)
            {
                stream.Write(m_nanosecond);
            }
            if (!SkipOffset)
            {
                stream.Write(m_offset);
            }
        }

        public static TimeEx FromStream(BinaryReader stream)
        {
            TimeEx res = new TimeEx();
            res.m_flags = (TimeExFlags)stream.ReadByte();
            if (!res.SkipTime)
            {
                res.m_hour = stream.ReadByte();
                res.m_minute = stream.ReadByte();
                res.m_second = stream.ReadByte();
            }
            if (!res.SkipNanoSecond)
            {
                res.m_nanosecond = stream.ReadInt32();
            }
            if (!res.SkipOffset)
            {
                res.m_offset = stream.ReadInt16();
            }
            return res;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            var dtfi = DateTimeFormatInfo.GetInstance(provider);
            return DateTimeExFormat.FormatCustomized(AsDateTime, format, dtfi);
        }

        public override string ToString()
        {
            return ToStringNormalized();
        }

        public string ToStringNormalized()
        {
            if (Nanosecond > 0)
            {
                return ToString("HH:mm:ss.fffffff", DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                return ToString("HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            }
        }

        public static TimeEx ParseNormalized(string value)
        {
            return DateTimeEx.Parse(value, "HH:mm:ss.fffffff", DateTimeFormatInfo.InvariantInfo).TimePart;
        }
    }


    [Flags]
    public enum DateTimeExFlags : byte
    {
        SkipDate = 1,
        SkipTime = 2,
        SkipOffset = 4,
        SkipNanoSecond = 8,
    }
    public struct DateTimeEx
    {
        int m_nanosecond;

        short m_year;
        byte m_second;
        DateTimeExFlags m_flags;

        byte m_month;
        byte m_day;
        byte m_hour;
        byte m_minute;

        short m_offset;

        public DateTimeEx(int year, int month, int day, int hour, int minute, int second)
        {
            m_year = (short)year;
            m_month = (byte)month;
            m_day = (byte)day;
            m_hour = (byte)hour;
            m_minute = (byte)minute;
            m_second = (byte)second;

            m_nanosecond = 0;
            m_flags = 0;
            m_offset = 0;
        }

        public int Second
        {
            get { return m_second; }
            set { m_second = (byte)value; }
        }
        public int Minute
        {
            get { return m_minute; }
            set { m_minute = (byte)value; }
        }
        public int Hour
        {
            get { return m_hour; }
            set { m_hour = (byte)value; }
        }
        public int Day
        {
            get { return m_day; }
            set { m_day = (byte)value; }
        }
        public int Month
        {
            get { return m_month; }
            set { m_month = (byte)value; }
        }
        public int Year
        {
            get { return m_year; }
            set { m_year = (short)value; }
        }
        public int Nanosecond
        {
            get { return m_nanosecond; }
            set { m_nanosecond = value; }
        }
        public int _Millisecond
        {
            get { return m_nanosecond / 1000000; }
            set { m_nanosecond = value * 1000000; }
        }
        public bool SkipDate
        {
            get { return (m_flags & DateTimeExFlags.SkipDate) != 0; }
            set { if (value) m_flags |= DateTimeExFlags.SkipDate; else m_flags &= ~DateTimeExFlags.SkipDate; }
        }
        public bool SkipTime
        {
            get { return (m_flags & DateTimeExFlags.SkipTime) != 0; }
            set { if (value) m_flags |= DateTimeExFlags.SkipTime; else m_flags &= ~DateTimeExFlags.SkipTime; }
        }
        public bool SkipNanoSecond
        {
            get { return (m_flags & DateTimeExFlags.SkipNanoSecond) != 0; }
            set { if (value) m_flags |= DateTimeExFlags.SkipNanoSecond; else m_flags &= ~DateTimeExFlags.SkipNanoSecond; }
        }
        public bool SkipOffset
        {
            get { return (m_flags & DateTimeExFlags.SkipOffset) != 0; }
            set { if (value) m_flags |= DateTimeExFlags.SkipOffset; else m_flags &= ~DateTimeExFlags.SkipOffset; }
        }
        public bool IsNull
        {
            get { return SkipDate && SkipTime && SkipOffset && SkipNanoSecond; }
        }
        public void SetNull()
        {
            SkipDate = true; SkipTime = true; SkipOffset = true; SkipNanoSecond = true;
        }
        public int Offset
        {
            get { return m_offset; }
            set { m_offset = (short)value; }
        }

        public void WriteTo(BinaryWriter stream)
        {
            stream.Write((byte)m_flags);
            if (!SkipDate)
            {
                stream.Write(m_year);
                stream.Write(m_month);
                stream.Write(m_day);
            }
            if (!SkipTime)
            {
                stream.Write(m_hour);
                stream.Write(m_minute);
                stream.Write(m_second);
            }
            if (!SkipNanoSecond)
            {
                stream.Write(m_nanosecond);
            }
            if (!SkipOffset)
            {
                stream.Write(m_offset);
            }
        }

        public static DateTimeEx FromStream(BinaryReader stream)
        {
            DateTimeEx res = new DateTimeEx();
            res.m_flags = (DateTimeExFlags)stream.ReadByte();
            if (!res.SkipDate)
            {
                res.m_year = stream.ReadInt16();
                res.m_month = stream.ReadByte();
                res.m_day = stream.ReadByte();
            }
            if (!res.SkipTime)
            {
                res.m_hour = stream.ReadByte();
                res.m_minute = stream.ReadByte();
                res.m_second = stream.ReadByte();
            }
            if (!res.SkipNanoSecond)
            {
                res.m_nanosecond = stream.ReadInt32();
            }
            if (!res.SkipOffset)
            {
                res.m_offset = stream.ReadInt16();
            }
            return res;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            var dtfi = DateTimeFormatInfo.GetInstance(provider);
            return DateTimeExFormat.FormatCustomized(this, format, dtfi);
        }

        public static DateTimeEx Parse(string value, string format, IFormatProvider provider)
        {
            return DateTimeExParse.ParseCustomized(value, format, DateTimeFormatInfo.GetInstance(provider));
        }

        public DateEx DatePart
        {
            get
            {
                return new DateEx
                {
                    Day = Day,
                    Month = Month,
                    SkipDate = SkipDate,
                    Year = Year
                };
            }
            set
            {
                Day = value.Day;
                Month = value.Month;
                SkipDate = value.SkipDate;
                Year = value.Year;
            }
        }
        public TimeEx TimePart
        {
            get
            {
                return new TimeEx
                {
                    Hour = Hour,
                    Minute = Minute,
                    Nanosecond = Nanosecond,
                    Offset = Offset,
                    Second = Second,
                    SkipNanoSecond = SkipNanoSecond,
                    SkipOffset = SkipOffset,
                    SkipTime = SkipTime
                };
            }
            set
            {
                Hour = value.Hour;
                Minute = value.Minute;
                Nanosecond = value.Nanosecond;
                Offset = value.Offset;
                Second = value.Second;
                SkipNanoSecond = value.SkipNanoSecond;
                SkipOffset = value.SkipOffset;
                SkipTime = value.SkipTime;
            }
        }

        public DateTime AsDateTime
        {
            get
            {
                var res = new DateTime(Year, Month, Day, Hour, Minute, Second, _Millisecond);
                return res;
            }
            set
            {
                Year = value.Year;
                Month = value.Month;
                Day = value.Day;
                Hour = value.Hour;
                Minute = value.Minute;
                Second = value.Second;
                _Millisecond = value.Millisecond;
                m_flags = 0;
            }
        }

        public static DateTimeEx MinDateTimeValue = DateTimeEx.FromDateTime(DateTime.MinValue);
        public static DateTimeEx MaxDateTimeValue = DateTimeEx.FromDateTime(DateTime.MaxValue);

        public bool IsValidDateTime
        {
            get { return this >= MinDateTimeValue && this <= MaxDateTimeValue; }
        }

        public static DateTimeEx FromDateTime(DateTime value)
        {
            DateTimeEx res = new DateTimeEx();
            res.AsDateTime = value;
            string s = res.ToStringNormalized();
            return res;
        }

        public string ToStringNormalized()
        {
            if (Nanosecond != 0)
            {
                return ToString("yyyy-MM-ddTHH:mm:ss.fffffff", DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                return ToString("yyyy-MM-ddTHH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            }
        }

        public static DateTimeEx ParseNormalized(string value)
        {
            return Parse(value, "yyyy-MM-ddTHH:mm:ss.fffffff", DateTimeFormatInfo.InvariantInfo);
        }

        public override string ToString()
        {
            return ToStringNormalized();
        }

        public static bool operator <=(DateTimeEx a, DateTimeEx b)
        {
            if (a.m_year > b.m_year) return false;
            if (a.m_year < b.m_year) return true;

            if (a.m_month > b.m_month) return false;
            if (a.m_month < b.m_month) return true;

            if (a.m_day > b.m_day) return false;
            if (a.m_day < b.m_day) return true;

            if (a.m_hour > b.m_hour) return false;
            if (a.m_hour < b.m_hour) return true;

            if (a.m_minute > b.m_minute) return false;
            if (a.m_minute < b.m_minute) return true;

            if (a.m_second > b.m_second) return false;
            if (a.m_second < b.m_second) return true;

            if (a.m_nanosecond > b.m_nanosecond) return false;
            if (a.m_nanosecond < b.m_nanosecond) return true;

            return true; // equal
        }
        public static bool operator >=(DateTimeEx a, DateTimeEx b)
        {
            return b <= a;
        }

        public void MakeRestriction(DateTimeEx minval, DateTimeEx maxval)
        {
            if (this <= minval) this = minval;
            if (this >= maxval) this = maxval;
        }

        public void MakeValidDate()
        {
            if (m_month == 0) m_month = 1;
            if (m_day == 0) m_day = 1;
        }
    }
}
