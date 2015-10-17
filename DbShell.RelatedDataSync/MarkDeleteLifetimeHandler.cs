using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;
using DbShell.RelatedDataSync.SqlModel;

namespace DbShell.RelatedDataSync
{
    public enum ReliveModeEnum
    {
        None,
        ClearDeleteFlag,
        CreateNewRow,
    }

    public class MarkDeleteLifetimeHandler : LifetimeHandlerBase
    {
        [XamlProperty]
        public bool Update { get; set; } = true;

        [XamlProperty]
        public bool Insert { get; set; } = true;

        [XamlProperty]
        public bool MarkDelete { get; set; } = false;

        [XamlProperty]
        public ReliveModeEnum ReliveMode { get; set; } = ReliveModeEnum.ClearDeleteFlag;

        public override bool CreateMarkRelived => ReliveMode == ReliveModeEnum.ClearDeleteFlag;
        public override bool CreateMarkDeleted => true;

        [XamlProperty]
        public string DeletedDateColumn { get; set; }

        [XamlProperty]
        public string IsDeletedColumn { get; set; }

        internal override void CreateLifetimeConditions(DmlfCommandBase cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
            if (!String.IsNullOrEmpty(DeletedDateColumn))
            {
                cmd.AddAndCondition(new DmlfIsNullCondition
                {
                    Expr = DmlfColumnRefExpression.Create(targetEntityAlias, DeletedDateColumn),
                });
            }
            if (!String.IsNullOrEmpty(IsDeletedColumn))
            {
                cmd.AddAndCondition(new DmlfEqualCondition
                {
                    LeftExpr = DmlfColumnRefExpression.Create(targetEntityAlias, DeletedDateColumn),
                    RightExpr = new DmlfLiteralExpression { Value = 0 },
                });
            }
        }

        internal override void CreateReliveConditions(DmlfCommandBase cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
            if (!String.IsNullOrEmpty(DeletedDateColumn))
            {
                cmd.AddAndCondition(new DmlfIsNotNullCondition
                {
                    Expr = DmlfColumnRefExpression.Create(targetEntityAlias, DeletedDateColumn),
                });
            }
            if (!String.IsNullOrEmpty(IsDeletedColumn))
            {
                cmd.AddAndCondition(new DmlfEqualCondition
                {
                    LeftExpr = DmlfColumnRefExpression.Create(targetEntityAlias, DeletedDateColumn),
                    RightExpr = new DmlfLiteralExpression { Value = 1 },
                });
            }
        }

        internal override void CreateReliveUpdateFields(DmlfUpdate cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
            if (!String.IsNullOrEmpty(DeletedDateColumn))
            {
                cmd.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = DeletedDateColumn,
                    Expr = new DmlfLiteralExpression { Value = null }
                });
            }
            if (!String.IsNullOrEmpty(IsDeletedColumn))
            {
                cmd.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = IsDeletedColumn,
                    Expr = new DmlfLiteralExpression { Value = 0 }
                });
            }
        }

        internal override void CreateSetDeletedUpdateFields(DmlfUpdate cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
            if (!String.IsNullOrEmpty(DeletedDateColumn))
            {
                cmd.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = DeletedDateColumn,
                    Expr = SqlScriptCompiler.ImportDateTimeExpression
                });
            }
            if (!String.IsNullOrEmpty(IsDeletedColumn))
            {
                cmd.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = IsDeletedColumn,
                    Expr = new DmlfLiteralExpression { Value = 1 }
                });
            }
        }
    }
}
