using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DbShell.Driver.MySql
{
    public class MySqlDatabaseAnalyser : SimpleDatabaseAnalyserBase
    {
        protected override void DoGetModifications()
        {
            DoGetModificationsCore(CreateQuery("table_modifications.sql", DatabaseObjectType.Table), "ALTER_TIME", "TABLE_NAME");
        }

        private string CreateQuery(string resFileName, DatabaseObjectType objectType)
        {
            string res = MySqlDatabaseFactory.LoadEmbeddedResource(resFileName);
            if (res.Contains("=[OBJECT_NAME_CONDITION]")) res = res.Replace(" =[OBJECT_NAME_CONDITION]", CreateFilterExpression(objectType));
            res = res.Replace("#DATABASE#", DatabaseName);
            return res;
        }

        protected override string ToColumnCase(string columnName) => columnName.ToUpper();

        protected override void DoRunAnalysis()
        {
            FillByNameDictionaries();

            if (FilterOptions.AnyTables && IsTablesPhase)
            {
                DoLoadTableList(CreateQuery("tables.sql", DatabaseObjectType.Table), "ALTER_TIME", "TABLE_NAME");
                DoLoadColumnsFromInformationSchema(CreateQuery("columns.sql", DatabaseObjectType.Table), (record, col) =>
                {
                    if (record.SafeString("EXTRA")?.ToLower()?.Contains("auto_increment") == true)
                        col.AutoIncrement = true;
                });
                DoLoadPrimaryKeysFromInformationSchema(CreateQuery("primary_keys.sql", DatabaseObjectType.Table));
                DoLoadForeignKeysFromInformationSchema(CreateQuery("foreign_keys.sql", DatabaseObjectType.Table));
            }
        }

        protected override DbTypeBase AnalyseType(ColumnInfo col, int len, int prec, int scale)
        {
            return AnalyseType(col.DataType, len, prec, scale);
        }

        private static string GetDataTypeNameWithoutParams(string dt)
        {
            int index = dt.IndexOf('(');
            if (index >= 0) return dt.Substring(0, index);
            return dt;
        }

        public static DbTypeBase AnalyseType(string dt, int len, int prec, int scale)
        {
            switch (GetDataTypeNameWithoutParams(dt))
            {
                case "binary":
                    return new DbTypeString
                    {
                        Length = len,
                        IsBinary = true,
                    };
                case "image":
                    return new DbTypeBlob();
                case "timestamp":
                    return new DbTypeString();
                case "varbinary":
                    return new DbTypeString
                    {
                        Length = len,
                        IsBinary = true,
                        IsVarLength = true,
                    };
                case "bit":
                    return new DbTypeString
                    {
                        Length = len,
                        IsBit = true,
                    };
                case "tinyint":
                    return new DbTypeInt
                    {
                        Bytes = 1
                    };
                case "mediumint":
                    return new DbTypeInt
                    {
                        Bytes = 3
                    };
                case "datetime":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Datetime,
                    };
                case "time":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Time,
                    };
                case "year":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Year,
                    };
                case "date":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Date,
                    };
                case "decimal":
                case "numeric":
                    return new DbTypeNumeric
                    {
                        Precision = prec,
                        Scale = scale,
                    };
                case "float":
                    return new DbTypeFloat();
                case "uniqueidentifier":
                    return new DbTypeGuid();
                case "smallint":
                    return new DbTypeInt
                    {
                        Bytes = 2
                    };
                case "int":
                case "integer":
                    return new DbTypeInt
                    {
                        Bytes = 4
                    };
                case "bigint":
                    return new DbTypeInt
                    {
                        Bytes = 8
                    };
                case "real":
                    return new DbTypeFloat();
                case "char":
                    return new DbTypeString
                    {
                        Length = len,
                    };
                case "nchar":
                    return new DbTypeString
                    {
                        Length = len,
                        IsUnicode = true,
                    };
                case "varchar":
                    return new DbTypeString
                    {
                        Length = len,
                        IsVarLength = true,
                    };
                case "nvarchar":
                    return new DbTypeString
                    {
                        Length = len,
                        IsVarLength = true,
                        IsUnicode = true,
                    };
                case "text":
                    return new DbTypeText()
                    {
                        IsUnicode = false,
                    };
                case "ntext":
                    return new DbTypeText()
                    {
                        IsUnicode = true,
                    };
                case "xml":
                    return new DbTypeXml();
            }
            return new DbTypeGeneric { Sql = dt };
        }


    }
}
