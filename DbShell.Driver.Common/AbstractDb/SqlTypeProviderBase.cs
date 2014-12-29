using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public class SqlTypeProviderBase : ISqlTypeProvider
    {
        public virtual void GetNativeDataType(DbTypeBase commonType, ColumnInfo columnInfo)
        {
            switch (commonType.Code)
            {
                case DbTypeCode.Blob:
                    columnInfo.DataType = "blob";
                    return;
                case DbTypeCode.Datetime:
                    columnInfo.DataType = "datetime";
                    return;
                case DbTypeCode.String:
                    var str = (DbTypeString) commonType;
                    columnInfo.DataType = str.GetStandardSqlName();
                    columnInfo.Length = str.Length;
                    return;
                case DbTypeCode.Guid:
                    columnInfo.DataType = "varchar";
                    columnInfo.Length = 50;
                    return;
                case DbTypeCode.Float:
                    columnInfo.DataType = "float";
                    return;
                case DbTypeCode.Numeric:
                    columnInfo.DataType = "numeric";
                    columnInfo.Precision = commonType.GetLength();
                    columnInfo.Scale = commonType.GetScale();
                    return;
                case DbTypeCode.Text:
                case DbTypeCode.Xml:
                    columnInfo.DataType = "nvarchar";
                    columnInfo.Length = -1;
                    return;
                case DbTypeCode.Logical:
                    columnInfo.DataType = "int";
                    return;
            }

            columnInfo.DataType = "varchar";
            columnInfo.Length = 50;
        }
    }
}