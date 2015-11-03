using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;
using DbShell.RelatedDataSync.SqlModel;

namespace DbShell.RelatedDataSync
{
    public class KeepHistoryLifetimeHandler : LifetimeHandlerBase
    {
        [XamlProperty]
        public string ValidFromColumn { get; set; }

        [XamlProperty]
        public string ValidToColumn { get; set; }

        [XamlProperty]
        /// list of columns, which can be modified in current record
        /// modification of this columns doesn't require to create new row
        public List<ColumnName> ModifyColumns { get; set; } = new List<ColumnName>();

        public override bool CreateMarkDeleted => true;
        public override bool CreateMarkUpdated => true;
        public override bool CreateUpdate => ModifyColumns.Any();

        internal override void CreateSetDeletedUpdateFields(DmlfUpdate cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
            cmd.Columns.Add(new DmlfUpdateField
            {
                TargetColumn = ValidToColumn,
                Expr = SqlScriptCompiler.ImportDateTimeExpression
            });
        }

        internal override void CreateSetUpdatedUpdateFields(DmlfUpdate cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
            cmd.Columns.Add(new DmlfUpdateField
            {
                TargetColumn = ValidToColumn,
                Expr = SqlScriptCompiler.ImportDateTimeExpression
            });
        }

        internal override void CreateLifetimeConditions(DmlfCommandBase cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
            cmd.AddAndCondition(new DmlfIsNullCondition
            {
                Expr = DmlfColumnRefExpression.Create(targetEntityAlias, ValidToColumn),
            });
        }

        public override bool? CompareColumn(string name, CompareColumnContext ctx)
        {
            if (ctx == CompareColumnContext.MarkUpdated && ModifyColumns.Any(x => x.Name == name)) return false;
            return base.CompareColumn(name, ctx);
        }

        public override bool? UpdateColumn(string name, UpdateColumnContext ctx)
        {
            if (ctx == UpdateColumnContext.Update) return ModifyColumns.Any(x => x.Name == name);
            return false;
        }

        internal override void AddTargetColumns(TargetEntitySqlModel targetEntityModel)
        {
            targetEntityModel.TargetColumns.Add(new TargetValidFromColumnSqlModel(ValidFromColumn, targetEntityModel.FindColumnInfo(ValidFromColumn)));
        }
    }
}
