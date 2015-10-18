using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Common;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.DmlFramework;
using DbShell.RelatedDataSync.SqlModel;

namespace DbShell.RelatedDataSync
{
    public class TableLogHandler : LogHandlerBase
    {
        [XamlProperty]
        public string TableSchema { get; set; }

        [XamlProperty]
        public string TableName { get; set; }

        [XamlProperty]
        public string MessageColumn { get; set; }

        [XamlProperty]
        public string ImportDateColumn { get; set; }

        [XamlProperty]
        public string MessageDateColumn { get; set; }

        [XamlProperty]
        public string OperationColumn { get; set; }

        [XamlProperty]
        public string ProcedureColumn { get; set; }

        [XamlProperty]
        public string DurationColumn { get; set; }

        [XamlProperty]
        public string TargetEntityColumn { get; set; }

        [XamlProperty]
        public string RowsColumn { get; set; }

        public override void PutLogMessage(
            ISqlDumper dmp, 
            string operationExpr, 
            string targetEntityExpr, 
            string messageExpr, 
            string durationExpr, 
            string procedureExpr, 
            string rowsExpr,
            IShellContext context)
        {
            if (String.IsNullOrEmpty(TableName)) return;
            var fullName = new NameWithSchema(context.Replace(TableSchema), context.Replace(TableName));

            var insert = new DmlfInsert();
            insert.InsertTarget = fullName;

            if (!String.IsNullOrEmpty(OperationColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = OperationColumn,
                    Expr = new DmlfSqlValueExpression { Value = operationExpr },
                });
            }
            if (!String.IsNullOrEmpty(MessageColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = MessageColumn,
                    Expr = new DmlfSqlValueExpression { Value = messageExpr },
                });
            }
            if (!String.IsNullOrEmpty(DurationColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = DurationColumn,
                    Expr = new DmlfSqlValueExpression { Value = durationExpr },
                });
            }
            if (!String.IsNullOrEmpty(TargetEntityColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = TargetEntityColumn,
                    Expr = new DmlfSqlValueExpression { Value = targetEntityExpr },
                });
            }
            if (!String.IsNullOrEmpty(MessageDateColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = MessageDateColumn,
                    Expr = new DmlfSqlValueExpression { Value = "GETDATE()" },
                });
            }
            if (!String.IsNullOrEmpty(ImportDateColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = ImportDateColumn,
                    Expr = SqlScriptCompiler.ImportDateTimeExpression,
                });
            }
            if (!String.IsNullOrEmpty(ProcedureColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = ProcedureColumn,
                    Expr = new DmlfSqlValueExpression { Value = procedureExpr },
                });
            }
            if (!String.IsNullOrEmpty(RowsColumn))
            {
                insert.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = RowsColumn,
                    Expr = new DmlfSqlValueExpression { Value = rowsExpr },
                });
            }

            if (insert.Columns.Any())
            {
                insert.GenSql(dmp);
                dmp.Put("&n");
            }
        }
    }
}
