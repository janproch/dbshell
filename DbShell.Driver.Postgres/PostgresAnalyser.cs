using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Postgres
{
    public class PostgresAnalyser : SimpleDatabaseAnalyserBase
    {
        protected override void DoGetModifications()
        {
            DoGetModificationsCore(CreateQuery("table_modifications.psql", DatabaseObjectType.Table), "Hash", "Name", "Schema");
        }

        protected override string ToColumnCase(string columnName) => columnName.ToLower();

        protected override void DoRunAnalysis()
        {
            FillByNameDictionaries();

            if (FilterOptions.AnyTables && IsTablesPhase)
            {
                DoLoadTableList(CreateQuery("table_modifications.psql", DatabaseObjectType.Table), "Hash", "Name", "Schema");
                DoLoadColumnsFromInformationSchema(CreateQuery("columns.psql", DatabaseObjectType.Table));
                DoLoadPrimaryKeysFromInformationSchema(CreateQuery("primary_keys.psql", DatabaseObjectType.Table));
                DoLoadForeignKeysFromInformationSchema(CreateQuery("foreign_keys.psql", DatabaseObjectType.Table));
            }
        }

        private string CreateQuery(string resFileName, DatabaseObjectType objectType)
        {
            string res = PostgresDatabaseFactory.LoadEmbeddedResource(resFileName);
            if (res.Contains("=[OBJECT_ID_CONDITION]")) res = res.Replace(" =[OBJECT_ID_CONDITION]", CreateFilterExpression(objectType, false));
            return res;
        }

        protected override DbTypeBase AnalyseType(ColumnInfo col, int len, int prec, int scale)
        {
            return AnalyseType(col.DataType, len, prec, scale, col.DefaultValue);
        }

        private static string GetDataTypeNameWithoutParams(string dt)
        {
            int index = dt.IndexOf('(');
            if (index >= 0) return dt.Substring(0, index);
            return dt;
        }

        private DbTypeBase AnalyseType(string dt, int len, int prec, int scale, string coldef)
        {
            if (dt.StartsWith("_"))
            {
                var res = AnalyseType(dt.Substring(1), len, prec, scale, coldef);
                return new DbTypeArray
                {
                    ElementType = res,
                };
            }
            switch (GetDataTypeNameWithoutParams(dt))
            {
                case "bigint":
                case "int8":
                    //if (coldef != null && coldef.StartsWith("nextval(")) return new PostgreSqlTypeBigSerial();
                    return new DbTypeInt { Bytes = 8 };
                case "bigserial":
                case "serial8":
                    return new DbTypeInt { Bytes = 8 };
                case "bit":
                    return new DbTypeString
                    {
                        Length = len,
                        IsBit = true,
                        IsVarLength = false,
                    };

                    //{
                    //    PostgreSqlTypeBit res = new PostgreSqlTypeBit();
                    //    res.Length = len;
                    //    return res;
                    //}
                case "varbit":
                case "bit varying":
                    return new DbTypeString
                    {
                        Length = len,
                        IsBit = true,
                        IsVarLength = true,
                    };
                case "boolean":
                case "bool":
                    return new DbTypeLogical();
                //case "box":
                //    return new PostgreSqlTypeBox();
                //case "bytea":
                //    return new PostgreSqlTypeBytea();
                case "character varying":
                case "varchar":
                    return new DbTypeString
                    {
                        IsVarLength = true,
                        Length = len,
                    };
                case "character":
                case "char":
                    return new DbTypeString
                    {
                        IsVarLength = false,
                        Length = len,
                    };
                //case "cidr":
                //    return new PostgreSqlTypeCidr();
                //case "circle":
                //    return new PostgreSqlTypeCircle();
                case "date":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Date,
                    };
                case "double precision":
                case "float8":
                    return new DbTypeFloat { Bytes = 8 };
                //case "inet":
                //    return new PostgreSqlTypeInet();
                case "integer":
                case "int":
                case "int4":
                    return new DbTypeInt();
                    //if (coldef != null && coldef.StartsWith("nextval(")) return new PostgreSqlTypeSerial();
                    //return new PostgreSqlTypeInteger();
                //case "line":
                //    return new PostgreSqlTypeLine();
                //case "lseg":
                //    return new PostgreSqlTypeLineSeg();
                //case "macaddr":
                //    return new PostgreSqlTypeMacAddr();
                case "money":
                    return new DbTypeFloat
                    {
                        IsMoney = true,
                    };
                case "numeric":
                case "decimal":
                    return new DbTypeNumeric
                    {
                        Precision = prec,
                        Scale = scale,
                    };
                //case "path":
                //    return new PostgreSqlTypePath();
                //case "point":
                //    return new PostgreSqlTypePoint();
                //case "polygon":
                //    return new PostgreSqlTypePolygon();
                case "real":
                case "float4":
                    return new DbTypeFloat
                    {
                        Bytes = 4
                    };
                case "smallint":
                case "int2":
                    return new DbTypeInt
                    {
                        Bytes = 2
                    };
                case "serial":
                case "serial4":
                    return new DbTypeInt
                    {
                        Bytes = 4
                    };
                case "text":
                    return new DbTypeText();
                case "time":
                case "time without time zone":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Time,
                    };
                case "timetz":
                case "time with time zone":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Time,
                        HasTimeZone = true,
                    };
                case "timestamp":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Datetime,
                    };
                case "timestamp without time zone":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Datetime,
                    };
                case "timestamp with time zone":
                case "timestamptz":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Datetime,
                        HasTimeZone = true,
                    };
                //case "bpchar":
                //    {
                //        PostgreSqlTypeBpChar res = new PostgreSqlTypeBpChar();
                //        res.Length = len;
                //        return res;
                //    }
                //case "oid":
                //    return new PostgreSqlTypeOid();
                //case "box2d":
                //    return new PostGISTypeBox2D();
                //case "box3d":
                //    return new PostGISTypeBox3D();
                //case "box3d_extent":
                //    return new PostGISTypeBox3D_Extent();
                //case "geometry":
                //    return new PostGISTypeGeometry();
                //case "geometry_dump":
                //    return new PostGISTypeGeometry_Dump();
                //case "geography":
                //    return new PostGISTypeGeography();
            }
            return new DbTypeGeneric { Sql = dt };
            //throw new Exception(String.Format("Unknown Postgre SQL type:{0}", dt));
        }

    }
}
