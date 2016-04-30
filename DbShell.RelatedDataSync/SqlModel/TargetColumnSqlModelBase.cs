using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public abstract class TargetColumnSqlModelBase
    {
        public abstract DmlfExpression CreateSourceExpression(SourceJoinSqlModel sourceJoinModel, bool aggregate);
        public abstract string Name { get; }
        public abstract bool IsKey { get; }
        public virtual bool IsRestriction => false;
        public virtual bool Update => true;
        public virtual bool Insert => true;
        public virtual bool Compare => true;
        public virtual bool IsReference => false;
        public virtual TargetReference UnderlyingReference => null;
        public virtual string RefColumnName => null;

        public readonly ColumnInfo Info;

        public TargetColumnSqlModelBase(ColumnInfo colinfo)
        {
            Info = colinfo;
        }

        public DmlfExpression CreateTargetExpression(DmlfSource targetSource)
        {
            return new DmlfColumnRefExpression
            {
                Column = new DmlfColumnRef
                {
                    Source = targetSource,
                    ColumnName = Name,
                }
            };
        }

        public bool CannotBeCompared
        {
            get
            {
                return Info?.CommonType is DbTypeBlob;
            }
        }

        private DmlfExpression CreateConvertExpression(string type, DmlfExpression expr)
        {
            var res = new DmlfFuncCallExpression
            {
                FuncName = "CONVERT"
            };
            res.Arguments.Add(new DmlfSqlValueExpression { Value = type });
            res.Arguments.Add(expr);
            return res;

        }

        public DmlfExpression CreateCompareExpression(DmlfExpression expr)
        {
            if (Info?.DataType?.ToLower()?.Contains("geo") ?? false)
            {
                return CreateConvertExpression("varchar(max)", expr);
            }
            if (Info?.DataType?.ToLower()?.Contains("xml") ?? false)
            {
                return CreateConvertExpression("nvarchar(max)", expr);
            }
            return expr;
        }

        public DmlfExpression CreateTargetExpression(string targetEntityAlias)
        {
            return CreateTargetExpression(new DmlfSource { Alias = targetEntityAlias });
        }

        protected DmlfExpression CreateAggregate(DmlfExpression expr)
        {
            if (Info?.DataType?.ToLower()?.Contains("bit") ?? false)
            {
                expr = CreateConvertExpression("int", expr);
            }

            var res = new DmlfFuncCallExpression
            {
                FuncName = "MAX",
            };
            res.Arguments.Add(expr);
            return res;
        }

        protected DmlfExpression GetExprOrAggregate(DmlfExpression expr, bool aggregate)
        {
            if (aggregate) return CreateAggregate(expr);
            return expr;
        }

        protected virtual string GetSourceDataType(SourceJoinSqlModel sourceJoinModel) => null;

        public bool UseCollate(SourceJoinSqlModel sourceJoinModel)
        {
            if (Info == null) return false;
            string srcType = GetSourceDataType(sourceJoinModel);
            if (srcType == null) return false;
            if (srcType.ToLower().Contains("char") && (Info.DataType?.ToLower()?.Contains("char") ?? false)) return true;
            return false;
        }
    }
}
