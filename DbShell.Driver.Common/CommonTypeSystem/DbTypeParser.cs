using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public class DbTypeParser
    {
        string[] _tokens = new string[0];

        public ColumnInfo Result = new ColumnInfo(null);
        public DbTypeBase CommonType
        {
            get { return Result.CommonType; }
            private set { Result.CommonType = value; }
        }

        private List<string> _parsedValues = new List<string>();

        public DbTypeParser(string dataType)
        {
            if (dataType != null)
            {
                _tokens = dataType.Replace(",", " , ").Replace("(", " ( ").Replace(")", " ) ").Split(' ')
                    .Select(x => x.Trim().ToLower()).ToArray();
            }

            if (StartsWith("varchar", "(", null, ")")) CommonType = new DbTypeString { IsUnicode = false, Length = IntValue(0, -1) };
            if (StartsWith("nvarchar", "(", null, ")")) CommonType = new DbTypeString { IsUnicode = true, Length = IntValue(0, -1) };
            if (StartsWith("char", "(", null, ")")) CommonType = new DbTypeString { IsVarLength=false, IsUnicode = false, Length = IntValue(0, -1) };
            if (StartsWith("nchar", "(", null, ")")) CommonType = new DbTypeString { IsVarLength=false, IsUnicode = false, Length = IntValue(0, -1) };
            if (StartsWith("varbinary", "(", null, ")")) CommonType = new DbTypeString { IsBinary = true, Length = IntValue(0, -1) };
            if (StartsWith("binary", "(", null, ")")) CommonType = new DbTypeString { IsVarLength = false, IsBinary = true, Length = IntValue(0, -1) };

            if (StartsWith("float")) CommonType = new DbTypeFloat();
            if (StartsWith("real")) CommonType = new DbTypeFloat();
            if (StartsWith("money")) CommonType = new DbTypeFloat { IsMoney = true };
            if (StartsWith("smallmoney")) CommonType = new DbTypeFloat { IsMoney = true };
            if (StartsWith("bit")) CommonType = new DbTypeLogical();
            if (StartsWith("image")) CommonType = new DbTypeBlob();

            if (StartsWith("tinyint")) CommonType = new DbTypeInt { Bytes = 1 };
            if (StartsWith("smallint")) CommonType = new DbTypeInt { Bytes = 2 };
            if (StartsWith("int")) CommonType = new DbTypeInt { Bytes = 4 };
            if (StartsWith("bigint")) CommonType = new DbTypeInt { Bytes = 8 };

            if (StartsWith("datetime")) CommonType = new DbTypeDatetime { SubType = DbDatetimeSubType.Datetime };
            if (StartsWith("datetime2")) CommonType = new DbTypeDatetime { SubType = DbDatetimeSubType.Datetime, ExtendedPrecision = true };
            if (StartsWith("datetimeoffset")) CommonType = new DbTypeDatetime { SubType = DbDatetimeSubType.Datetime, HasTimeZone = true };
            if (StartsWith("date")) CommonType = new DbTypeDatetime { SubType = DbDatetimeSubType.Date};
            if (StartsWith("time")) CommonType = new DbTypeDatetime { SubType = DbDatetimeSubType.Time};
            if (StartsWith("smalldatetime")) CommonType = new DbTypeDatetime { SubType = DbDatetimeSubType.Datetime };

            if (StartsWith("text")) CommonType = new DbTypeText();
            if (StartsWith("ntext")) CommonType = new DbTypeText { IsUnicode = true };
            if (StartsWith("xml")) CommonType = new DbTypeXml();
            if (StartsWith("sql_variant")) CommonType = new DbTypeText();

            if (StartsWith("decimal")) CommonType = new DbTypeNumeric();
            if (StartsWith("numeric")) CommonType = new DbTypeNumeric();
            if (StartsWith("decimal", "(", null, ",", null, ")")) CommonType = new DbTypeNumeric { Precision = IntValue(0, 10), Scale = IntValue(1, 0) };
            if (StartsWith("numeric", "(", null, ",", null, ")")) CommonType = new DbTypeNumeric { Precision = IntValue(0, 10), Scale = IntValue(1, 0) };
        }

        private int IntValue(int index, int defValue)
        {
            int result;
            if (_parsedValues[index] == "max") return -1;
            if (Int32.TryParse(_parsedValues[index], out result)) return result;
            return defValue;
        }

        private bool StartsWith(params string[] args)
        {
            _parsedValues.Clear();
            for (int i = 0; i < args.Length; i++)
            {
                if (i >= _tokens.Length) return false;
                if (args[i] == null)
                {
                    _parsedValues.Add(_tokens[i]);
                }
                else
                {
                    if (_tokens[i] != args[i]) return false;
                }
            }
            return true;
        }
    }
}
