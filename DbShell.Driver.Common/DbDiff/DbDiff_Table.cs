using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    public static partial class DbDiffTool
    {
        public static void AlterTable(AlterPlan plan, TableInfo oldTable, TableInfo newTable, DbDiffOptions opts, DbObjectPairing pairing)
        {
            //plan.BeginFixedOrder();
            if (oldTable == null) throw new ArgumentNullException("oldTable", "DAE-00240 oldTable is null");
            if (newTable == null) throw new ArgumentNullException("newTable", "DAE-00241 newTable is null");

            //bool processed;
            //proc.AlterTable(oldTable, newTable, out processed);
            //if (processed) return;

            //InMemoryTableOperation dataOps = null;
            //if (oldTable.FixedData != null) dataOps = new InMemoryTableOperation(oldTable.FixedData.Structure);

            NameWithSchema newTableName = GenerateNewName(oldTable.FullName, newTable.FullName, opts);

            bool permuteColumns = false;
            bool insertColumns = false;
            //bool renameColumns = false;

            List<int> columnMap = new List<int>();
            List<int> constraintMap = new List<int>();

            foreach (var col in newTable.Columns)
            {
                columnMap.Add(oldTable.Columns.IndexOfIf(c => c.GroupId == col.GroupId));
            }
            foreach (var cnt in newTable.Constraints)
            {
                int cindex = oldTable.Constraints.IndexOfIf(c => c.GroupId == cnt.GroupId);
                if (cindex < 0 && cnt is PrimaryKeyInfo)
                {
                    // primary keys for one table are equal
                    cindex = oldTable.Constraints.IndexOfIf(c => c is PrimaryKeyInfo);
                }
                constraintMap.Add(cindex);
            }

            if (!opts.IgnoreColumnOrder)
            {
                // count alter requests
                int lastcol = -1;
                foreach (int col in columnMap)
                {
                    if (col < 0) continue;
                    if (col < lastcol) permuteColumns = true;
                    lastcol = col;
                }

                bool wasins = false;
                foreach (int col in columnMap)
                {
                    if (col < 0) wasins = true;
                    if (col >= 0 && wasins) insertColumns = true;
                }
            }

            int index;

            // drop constraints
            index = 0;

            foreach (var cnt in oldTable.Constraints)
            {
                if (constraintMap.IndexOf(index) < 0) plan.DropConstraint(cnt);
                index++;
            }

            // drop columns
            index = 0;
            foreach (var col in oldTable.Columns)
            {
                if (columnMap.IndexOf(index) < 0)
                {
                    plan.DropColumn(col);
                    //if (dataOps != null) dataOps.DropColumn(col.ColumnName);
                }
                index++;
            }

            if (!DbDiffTool.EqualFullNames(oldTable.FullName, newTable.FullName, opts))
            {
                plan.RenameTable(oldTable, newTable.FullName);
            }

            // create columns
            index = 0;
            foreach (var col in newTable.Columns)
            {
                if (columnMap[index] < 0)
                {
                    var newcol = col.CloneColumn();
                    plan.CreateColumn(oldTable, newcol);
                    //if (dataOps != null) dataOps.CreateColumn(newcol);
                }
                index++;
            }

            // change columns
            index = 0;
            foreach (var col in newTable.Columns)
            {
                if (columnMap[index] >= 0)
                {
                    var src = oldTable.Columns[columnMap[index]];
                    if (!DbDiffTool.EqualsColumns(src, col, true, true, opts, pairing))
                    {
                        using (var ctx = new DbDiffChangeLoggerContext(opts, NopMessageLogger.Instance, DbDiffOptsLogger.DiffLogger))
                        {
                            if (DbDiffTool.EqualsColumns(src, col, false, true, opts, pairing))
                            {
                                plan.RenameColumn(src, col.Name);
                            }
                            else
                            {
                                plan.ChangeColumn(src, col);
                            }
                            //if (dataOps != null && src.ColumnName != col.ColumnName) dataOps.RenameColumn(src.ColumnName, col.ColumnName);
                        }
                    }
                }
                index++;
            }

            //// create fixed data script
            //var script = AlterFixedData(oldTable.FixedData, newTable.FixedData, dataOps, opts);
            //if (script != null) plan.UpdateData(oldTable.FullName, script);

            // change constraints
            index = 0;
            foreach (var cnt in newTable.Constraints)
            {
                if (constraintMap[index] >= 0)
                {
                    var src = oldTable.Constraints[constraintMap[index]];
                    if (DbDiffTool.EqualsConstraints(src, cnt, opts, false, pairing) && src.ConstraintName != cnt.ConstraintName)
                    {
                        //if (cnt is IPrimaryKey && (pairing.Source.Dialect.DialectCaps.AnonymousPrimaryKey || pairing.Target.Dialect.DialectCaps.AnonymousPrimaryKey))
                        //{
                        //    // do nothing
                        //}
                        //else
                        //{
                            plan.RenameConstraint(src, cnt.ConstraintName);
                        //}
                    }
                    else
                    {
                        if (!DbDiffTool.EqualsConstraints(src, cnt, opts, true, pairing))
                        {
                            plan.ChangeConstraint(src, cnt);
                        }
                    }
                }
                index++;
            }

            // create constraints
            index = 0;
            foreach (var cnt in newTable.Constraints)
            {
                if (constraintMap[index] < 0)
                {
                    plan.CreateConstraint(oldTable, cnt);
                }
                index++; ;
            }

            if (permuteColumns || insertColumns)
            {
                plan.ReorderColumns(oldTable, new List<string>((from c in newTable.Columns select c.Name)));
            }

            var alteredOptions = GetTableAlteredOptions(oldTable, newTable, opts);
            if (alteredOptions.Count > 0) plan.ChangeTableOptions(oldTable, alteredOptions);
            //plan.EndFixedOrder();
        }

        public static Dictionary<string, string> GetTableAlteredOptions(TableInfo oldTable, TableInfo newTable, DbDiffOptions opts)
        {
            Dictionary<string, string> alteredOptions = new Dictionary<string, string>();
            if (opts.IgnoreAllTableProperties) return alteredOptions;
            //foreach (string key in newTable.SpecificData.Keys)
            //{
            //    if (opts.IgnoreTableProperties.Contains(key)) continue;
            //    if (oldTable.SpecificData.Get(key) != newTable.SpecificData[key])
            //        alteredOptions[key] = newTable.SpecificData[key];
            //}
            return alteredOptions;
        }
    }
}
