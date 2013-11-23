using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DbDiff
{
    public enum AlterObjectMeaning { OldObject, NewObject }
    public enum AlterObjectActionType { Rename, Drop, Create, Change, Other }
    public struct AlterOperationEnumRecord
    {
        public DatabaseObjectInfo Object;
        public AlterObjectMeaning Meaning;
        public AlterObjectActionType ActionType;
    }

    public abstract class AlterOperation
    {
        public virtual int OrderGroup { get { return 0; } }
        internal int m_tmpOrder;
        //public List<AlterOperation> Dependencies = new List<AlterOperation>();
        public TableInfo ParentTable;
        public abstract void Run(IAlterProcessor proc, DbDiffOptions opts);

        public virtual bool MustRunOnParalelStructure() { return true; }
        public virtual bool DenyTransaction() { return false; }

        protected DatabaseObjectInfo GetPossibleTableObject(DatabaseObjectInfo newObject)
        {
            if (ParentTable != null)
            {
                DatabaseObjectInfo res = newObject.CloneObject(null);
                ((TableObjectInfo)res).SetDummyTable(ParentTable.FullName);
                return res;
            }
            else
            {
                return newObject;
            }
        }

        protected static ObjectOperationCaps GetConstraintCaps(AlterProcessorCaps caps, DatabaseObjectInfo obj)
        {
            if (obj is IndexInfo)
            {
                return new ObjectOperationCaps
                {
                    Create = caps.AddIndex,
                    Drop = caps.DropIndex,
                    Rename = caps.RenameIndex,
                    Change = caps.ChangeIndex,
                };
            }
            else
            {
                return new ObjectOperationCaps
                {
                    Create = caps.AddConstraint,
                    Drop = caps.DropConstraint,
                    Rename = caps.RenameConstraint,
                    Change = caps.ChangeConstraint,
                };
            }
        }

        public virtual void ChangeStructure(DatabaseInfo s)
        {
            if (ParentTable != null) ParentTable = s.FindByGroupId(ParentTable.GroupId) as TableInfo;
        }

        public AlterOperation CloneForStructure(DatabaseInfo s)
        {
            Type t = GetType();
            var res = t.GetConstructor(new Type[] { }).Invoke(new object[] { }) as AlterOperation;
            res.AssignFrom(this);
            if (s != null) res.ChangeStructure(s);
            return res;
        }

        public virtual void AddLogicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> before, List<AlterOperation> after, AlterPlan plan)
        {
        }
        public virtual void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
        }

        protected void TransformToRecreateTable(List<AlterOperation> replacement, AlterPlan plan)
        {
            replacement.Clear();
            var op = new AlterOperation_RecreateTable { ParentTable = ParentTable };
            //ParentTable.LoadStructure(TableStructureMembers.All, targetDb);
            foreach (var fk in ParentTable.GetReferences()) plan.RecreateObject(fk, null);
            op.AppendOp(this);
            replacement.Add(op);
        }

        public virtual void AssignFrom(AlterOperation src)
        {
            ParentTable = src.ParentTable;
        }

        public virtual void AddPhysicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> before, List<AlterOperation> after, AlterPlan alterPlan)
        {
        }

        public virtual IEnumerable<AlterOperationEnumRecord> EnumObjects()
        {
            yield break;
        }

        public virtual bool MustRunAbsorbTest(AlterProcessorCaps caps) { return false; }
        public virtual bool AbsorbOperation(AlterProcessorCaps caps, AlterOperation op) { return false; }

        public virtual DatabaseObjectInfo GetDropObject()
        {
            return null;
        }

        public virtual void RunNameTransformation(INameTransformation transform)
        {
        }
    }

    public class AlterOperation_Drop : AlterOperation
    {
        public DatabaseObjectInfo OldObject;

        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            proc.DropObject(OldObject);
        }

        public override void ChangeStructure(DatabaseInfo s)
        {
            base.ChangeStructure(s);
            OldObject = s.FindByGroupId(OldObject.GroupId) as DatabaseObjectInfo;
        }

        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            OldObject = ((AlterOperation_Drop)src).OldObject;
        }

        public override IEnumerable<AlterOperationEnumRecord> EnumObjects()
        {
            yield return new AlterOperationEnumRecord { Object = OldObject, Meaning = AlterObjectMeaning.OldObject, ActionType = AlterObjectActionType.Drop };
        }

        public override string ToString()
        {
            return "DROP " + OldObject.ToString();
        }

        public override DatabaseObjectInfo GetDropObject()
        {
            return OldObject;
        }
    }
    public class AlterOperation_Create : AlterOperation
    {
        public DatabaseObjectInfo NewObject;

        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            proc.CreateObject(GetPossibleTableObject(NewObject));
        }

        public override IEnumerable<AlterOperationEnumRecord> EnumObjects()
        {
            yield return new AlterOperationEnumRecord { Object = NewObject, Meaning = AlterObjectMeaning.NewObject, ActionType = AlterObjectActionType.Create };
        }

        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            NewObject = ((AlterOperation_Create)src).NewObject;
        }

        public override string ToString()
        {
            return "CREATE " + NewObject.ToString();
        }
    }
    public class AlterOperation_Rename : AlterOperation
    {
        public DatabaseObjectInfo OldObject;
        public NameWithSchema NewName;

        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            proc.RenameObject(OldObject, opts, NewName);
        }

        public override void ChangeStructure(DatabaseInfo s)
        {
            base.ChangeStructure(s);
            OldObject = s.FindByGroupId(OldObject.GroupId) as DatabaseObjectInfo;
        }

        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            OldObject = ((AlterOperation_Rename)src).OldObject;
            NewName = ((AlterOperation_Rename)src).NewName;
        }

        public override IEnumerable<AlterOperationEnumRecord> EnumObjects()
        {
            yield return new AlterOperationEnumRecord { Object = OldObject, Meaning = AlterObjectMeaning.OldObject, ActionType = AlterObjectActionType.Rename };
        }

        public override string ToString()
        {
            return "RENAME " + OldObject.ToString() + "->" + NewName.ToString();
        }
    }
    public class AlterOperation_Change : AlterOperation
    {
        public DatabaseObjectInfo OldObject;
        public DatabaseObjectInfo NewObject;

        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            proc.ChangeObject(OldObject, GetPossibleTableObject(NewObject));
        }

        public override void ChangeStructure(DatabaseInfo s)
        {
            base.ChangeStructure(s);
            OldObject = s.FindByGroupId(OldObject.GroupId) as DatabaseObjectInfo;
        }

        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            OldObject = ((AlterOperation_Change)src).OldObject;
            NewObject = ((AlterOperation_Change)src).NewObject;
        }

        public override IEnumerable<AlterOperationEnumRecord> EnumObjects()
        {
            yield return new AlterOperationEnumRecord { Object = OldObject, Meaning = AlterObjectMeaning.OldObject, ActionType = AlterObjectActionType.Change };
            yield return new AlterOperationEnumRecord { Object = NewObject, Meaning = AlterObjectMeaning.NewObject, ActionType = AlterObjectActionType.Change };
        }

        public override string ToString()
        {
            return "CHANGE " + OldObject.ToString();
        }
    }

    public class AlterOperation_CreateDomain : AlterOperation_Create { }
    public class AlterOperation_DropDomain : AlterOperation_Drop { }
    public class AlterOperation_ChangeDomain : AlterOperation_Change { }
    public class AlterOperation_RenameDomain : AlterOperation_Rename { }
    public class AlterOperation_CreateColumn : AlterOperation_Create
    {
        public List<ConstraintInfo> AdditionalConstraints = new List<ConstraintInfo>();
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            if (!caps.AddColumn) TransformToRecreateTable(replacement, plan);
        }
        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            proc.CreateColumn((ColumnInfo)GetPossibleTableObject(NewObject), AdditionalConstraints);
        }
        public override bool MustRunAbsorbTest(AlterProcessorCaps caps)
        {
            return caps.ForceAbsorbPrimaryKey;
        }
        public override bool AbsorbOperation(AlterProcessorCaps caps, AlterOperation op)
        {
            var cop = op as AlterOperation_Create;
            if (cop != null)
            {
                var pk = cop.NewObject as PrimaryKeyInfo;
                if (pk != null && pk.Columns.Count == 1 && pk.Columns[0].Name == ((ColumnInfo)NewObject).Name)
                {
                    pk = pk.ClonePrimaryKey();
                    pk.SetDummyTable(ParentTable.FullName);
                    AdditionalConstraints.Add(pk);
                    return true;
                }
            }
            return base.AbsorbOperation(caps, op);
        }
        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            AdditionalConstraints.AddRange(((AlterOperation_CreateColumn)src).AdditionalConstraints);
        }
    }
    public class AlterOperation_DropColumn : AlterOperation_Drop
    {
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            if (!caps.DropColumn) TransformToRecreateTable(replacement, plan);
        }

        public override void AddLogicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> before, List<AlterOperation> after, AlterPlan plan)
        {
            base.AddLogicalDependencies(caps, opts, before, after, plan);

            var col = (ColumnInfo)OldObject;

            foreach (var fk in ParentTable.GetReferences())
            {
                bool fkdeleted = false;
                for (int i = 0; i < fk.RefColumns.Count; i++)
                {
                    if (fk.RefColumns[i].Name == col.Name)
                    {
                        fkdeleted = true;
                        break;
                    }
                }
                if (fkdeleted)
                {
                    opts.AlterLogger.Warning(String.Format("Dropped reference {0} on table {1}", fk.OwnerTable.FullName, fk.ConstraintName));
                    before.Add(new AlterOperation_DropConstraint { ParentTable = ParentTable, OldObject = fk });
                }
            }

            foreach (var cnt in ParentTable.Constraints)
            {
                var cc = cnt as ColumnsConstraintInfo;
                if (cc == null) continue;
                if (cc.Columns.Any(c => c.Name == col.Name))
                {
                    before.Add(new AlterOperation_DropConstraint { ParentTable = ParentTable, OldObject = cc });
                }
            }
        }
    }

    public class AlterOperation_ChangeColumn : AlterOperation_Change
    {
        public List<ConstraintInfo> AdditionalConstraints = new List<ConstraintInfo>();
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            if (!caps.ChangeColumn)
            {
                TransformToRecreateTable(replacement, plan);
                return;
            }
            if (!caps.ChangeAutoIncrement && ((ColumnInfo)OldObject).AutoIncrement != ((ColumnInfo)NewObject).AutoIncrement)
            {
                TransformToRecreateTable(replacement, plan);
                return;
            }
        }
        public override void AddLogicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> before, List<AlterOperation> after, AlterPlan plan)
        {
            var oldcol = OldObject as ColumnInfo;
            var newcol = NewObject as ColumnInfo;

            var recreateFks = new List<ForeignKeyInfo>();
            var changeCols = new List<Tuple<ColumnInfo, ColumnInfo>>();

            foreach (var fk in ParentTable.GetReferences())
            {
                for (int i = 0; i < fk.RefColumns.Count; i++)
                {
                    if (fk.RefColumns[i].Name == oldcol.Name)
                    {
                        //plan.RecreateObject(fk, null);
                        var table = fk.OwnerTable;
                        var othercol = table.Columns[fk.Columns[i].Name];

                        // compare types with ignoring autoincrement flag
                        // HACK: ignore specific attributes
                        var opts2 = opts.Clone();
                        opts2.IgnoreSpecificData = true;

                        //TODO

                        //DbTypeBase dt1 = othercol.DataType.Clone(), dt2 = newcol.DataType.Clone();
                        //dt1.SetAutoincrement(false);
                        //dt2.SetAutoincrement(false);
                        //if (!DbDiffTool.EqualTypes(dt1, dt2, opts2))
                        //{
                        //    after.Add(new AlterOperation_ChangeColumn
                        //    {
                        //        ParentTable = table,
                        //        OldObject = othercol,
                        //        NewObject = new ColumnStructure(othercol) { DataType = dt2 }
                        //    });
                        //}
                        //opts.AlterLogger.Warning(Texts.Get("s_changed_referenced_column$table$column", "table", fk.Table.FullName, "column", othercol.ColumnName));
                    }
                }
            }
        }
        public override void AddPhysicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> before, List<AlterOperation> after, AlterPlan plan)
        {
            //var oldcol = OldObject as ColumnStructure;
            //if (caps.DepCaps.ChangeColumn_Constraint || caps.DepCaps.ChangeColumn_Index)
            //{
            //    ParentTable.LoadStructure(TableStructureMembers.Constraints, targetDb);
            //    foreach (var cnt in ParentTable.Constraints)
            //    {
            //        var cc = cnt as ColumnsConstraint;
            //        if (cc == null) continue;
            //        if (cc.Columns.Any(c => c.ColumnName == oldcol.ColumnName))
            //        {
            //            if (
            //                (cc is IIndex && caps.DepCaps.ChangeColumn_Index) ||
            //                (!(cc is IIndex) && caps.DepCaps.ChangeColumn_Constraint))
            //            {
            //                plan.RecreateObject(cc, null);
            //            }
            //        }
            //    }
            //}
            //if (caps.DepCaps.ChangeColumn_Reference)
            //{
            //    ParentTable.LoadStructure(TableStructureMembers.ReferencedFrom, targetDb);

            //    foreach (ForeignKey fk in ParentTable.GetReferencedFrom())
            //    {
            //        for (int i = 0; i < fk.PrimaryKeyColumns.Count; i++)
            //        {
            //            if (fk.PrimaryKeyColumns[i].ColumnName == oldcol.ColumnName)
            //            {
            //                plan.RecreateObject(fk, null);
            //            }
            //        }
            //    }
            //}
        }
        public override bool MustRunAbsorbTest(AlterProcessorCaps caps)
        {
            return caps.ForceAbsorbPrimaryKey;
        }
        public override bool AbsorbOperation(AlterProcessorCaps caps, AlterOperation op)
        {
            var cop = op as AlterOperation_Create;
            if (cop != null)
            {
                var pk = cop.NewObject as PrimaryKeyInfo;
                if (pk != null && pk.Columns.Count == 1 && pk.Columns[0].Name == ((ColumnInfo)NewObject).Name)
                {
                    pk = pk.ClonePrimaryKey();
                    pk.SetDummyTable(ParentTable.FullName);
                    AdditionalConstraints.Add(pk);
                    return true;
                }
            }
            return base.AbsorbOperation(caps, op);
        }
        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            proc.ChangeColumn((ColumnInfo)OldObject, (ColumnInfo)GetPossibleTableObject(NewObject), AdditionalConstraints);
        }
        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            AdditionalConstraints.AddRange(((AlterOperation_ChangeColumn)src).AdditionalConstraints);
        }
    }
    public class AlterOperation_RenameColumn : AlterOperation_Rename
    {
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            if (!caps.RenameColumn) TransformToRecreateTable(replacement, plan);
        }
    }
    public class AlterOperation_CreateConstraint : AlterOperation_Create
    {
        public override int OrderGroup
        {
            get
            {
                if (NewObject is ForeignKeyInfo) return AlterPlan.AFTER_ORDERGROUP + 1;
                return 0;
            }
        }
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            var c = GetConstraintCaps(caps, NewObject);
            if (!c.Create) TransformToRecreateTable(replacement, plan);
        }
        public override void RunNameTransformation(INameTransformation transform)
        {
            base.RunNameTransformation(transform);
            var fk = NewObject as ForeignKeyInfo;
            //if (fk != null) fk.RunNameTransformation(transform);
        }
    }
    public class AlterOperation_DropConstraint : AlterOperation_Drop
    {
        public override void AddLogicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> before, List<AlterOperation> after, AlterPlan plan)
        {
            base.AddLogicalDependencies(caps, opts, before, after, plan);

            var pk = OldObject as PrimaryKeyInfo;
            if (pk != null)
            {
                foreach (var col in pk.Columns)
                {
                    foreach (var fk in ParentTable.GetReferences())
                    {
                        bool fkdeleted = false;
                        for (int i = 0; i < fk.RefColumns.Count; i++)
                        {
                            if (fk.RefColumns[i].Name == col.Name)
                            {
                                fkdeleted = true;
                                break;
                            }
                        }
                        if (fkdeleted)
                        {
                            opts.AlterLogger.Warning(String.Format("Dropped reference {0} on table {1}", fk.ConstraintName, fk.OwnerTable.FullName));
                            before.Add(new AlterOperation_DropConstraint { ParentTable = ParentTable, OldObject = fk });
                        }
                    }
                }
            }
        }
        public override int OrderGroup
        {
            get
            {
                if (OldObject is ForeignKeyInfo) return AlterPlan.BEFORE_ORDERGROUP - 1;
                return 0;
            }
        }
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            var c = GetConstraintCaps(caps, OldObject);
            if (!c.Drop) TransformToRecreateTable(replacement, plan);
        }
    }
    public class AlterOperation_ChangeConstraint : AlterOperation_Change
    {
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            var c = GetConstraintCaps(caps, NewObject);
            if (!c.Change)
            {
                if (c.Create && c.Drop)
                {
                    plan.RecreateObject(OldObject, NewObject);
                    replacement.Clear();
                }
                else
                {
                    TransformToRecreateTable(replacement, plan);
                }
            }
        }
        public override void RunNameTransformation(INameTransformation transform)
        {
            base.RunNameTransformation(transform);
            var fk = NewObject as ForeignKeyInfo;
            //if (fk != null) fk.RunNameTransformation(transform);
        }
    }
    public class AlterOperation_RenameConstraint : AlterOperation_Rename
    {
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            var c = GetConstraintCaps(caps, OldObject);
            if (!c.Rename)
            {
                if (c.Create && c.Drop)
                {
                    var newobj = OldObject.CloneObject(null);
                    ((ConstraintInfo)newobj).ConstraintName = NewName.Name;
                    plan.RecreateObject(OldObject, newobj);
                    replacement.Clear();
                }
                else
                {
                    TransformToRecreateTable(replacement, plan);
                }
            }
        }
    }
    public class AlterOperation_CreateSpecificObject : AlterOperation_Create { }
    public class AlterOperation_DropSpecificObject : AlterOperation_Drop { }
    public class AlterOperation_ChangeSpecificObject : AlterOperation_Change
    {
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            //if (!caps[OldObject).ObjectType].Change)
            //{
                plan.RecreateObject(OldObject, NewObject);
                replacement.Clear();
            //}
        }
    }
    public class AlterOperation_RenameSpecificObject : AlterOperation_Rename { }
    public class AlterOperation_PermuteColumns : AlterOperation
    {
        public List<string> NewColumnOrder;
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            if (!caps.PermuteColumns)
            {
                TransformToRecreateTable(replacement, plan);
            }
        }
        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            //proc.ReorderColumns(ParentTable.FullName, NewColumnOrder);
        }

        public override bool MustRunOnParalelStructure()
        {
            return false;
        }

        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            NewColumnOrder = new List<string>(((AlterOperation_PermuteColumns)src).NewColumnOrder);
        }

        public override string ToString()
        {
            return "REORDER COLUMNS " + ParentTable.ToString();
        }
    }
    public class AlterOperation_UpdateData : AlterOperation
    {
        public DataScript Script;

        public override bool MustRunOnParalelStructure()
        {
            return false;
        }
        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            //proc.UpdateData(ParentTable, Script, null);
        }
        public override void AddPhysicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> before, List<AlterOperation> after, AlterPlan alterPlan)
        {
            base.AddPhysicalDependencies(caps, opts, before, after, alterPlan);
            //ParentTable.LoadStructure(TableStructureMembers.Columns | TableStructureMembers.PrimaryKey, targetDb);
        }
        public override string ToString()
        {
            return "UPDATE DATA " + ParentTable.ToString();
        }
        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            Script = ((AlterOperation_UpdateData)src).Script;
        }
    }
    public class AlterOperation_ChangeTableOptions : AlterOperation
    {
        public Dictionary<string, string> Options;

        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            //proc.AlterTableOptions(ParentTable, Options);
        }
        public override string ToString()
        {
            return "CHANGE OPTIONS " + ParentTable.ToString();
        }
        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            Options = ((AlterOperation_ChangeTableOptions)src).Options;
        }
    }
    public class AlterOperation_ChangeDatabaseOptions : AlterOperation
    {
        public Dictionary<string, string> Options;
        public string DbName;

        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            //proc.AlterDatabaseOptions(DbName, Options);
        }
        public override string ToString()
        {
            return "CHANGE DATABSE OPTIONS";
        }
        public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        {
            base.TransformToImplementedOps(caps, opts, replacement, plan);
            //if (DbName == null) DbName = targetDb.DatabaseName;
        }
        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            Options = ((AlterOperation_ChangeDatabaseOptions)src).Options;
            DbName = ((AlterOperation_ChangeDatabaseOptions)src).DbName;
        }
        public override bool DenyTransaction()
        {
            return true;
        }
    }
    public class AlterOperation_RecreateTable : AlterOperation
    {
        //public AlterPlan InnerPlan = new AlterPlan();
        public List<AlterOperation> AlterTableOps = new List<AlterOperation>();

        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            foreach (var op in ((AlterOperation_RecreateTable)src).AlterTableOps)
            {
                AlterTableOps.Add(op.CloneForStructure(null));
            }
        }

        public override void ChangeStructure(DatabaseInfo s)
        {
            base.ChangeStructure(s);
            foreach (var op in AlterTableOps) op.ChangeStructure(s);
        }

        public void AppendOp(AlterOperation op)
        {
            var rop = op as AlterOperation_RecreateTable;
            if (rop != null) AlterTableOps.AddRange(rop.AlterTableOps);
            else AlterTableOps.Add(op);
        }

        public void InsertOp(AlterOperation op)
        {
            var rop = op as AlterOperation_RecreateTable;
            if (rop != null) AlterTableOps.InsertRange(0, rop.AlterTableOps);
            else AlterTableOps.Insert(0, op);
        }

        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            var newtbl = ParentTable.CloneTable();
            var dbs = new DatabaseInfo();
            dbs.Tables.Add(newtbl);
            foreach (var op in AlterTableOps)
            {
                op.Run(new DatabaseInfoAlterProcessor(dbs), opts);
            }
            proc.RecreateTable(ParentTable, newtbl);
            opts.AlterLogger.Info(String.Format("Recreated table {0}", ParentTable.FullName));
        }
    }
    public class AlterOperation_CreateTable : AlterOperation_Create
    {
        public DataScript Data;

        //public override void TransformToImplementedOps(AlterProcessorCaps caps, DbDiffOptions opts, List<AlterOperation> replacement, AlterPlan plan)
        //{
        //    if (targetDb != null && !targetDb.Dialect.DialectCaps.UncheckedReferences)
        //    {
        //        replacement.Clear();
        //        replacement.Add(this);
        //        var table = (TableStructure)NewObject;
        //        foreach (var cnt in new List<ConstraintInfo>(table.Constraints))
        //        {
        //            var fk = cnt as ForeignKey;
        //            if (fk == null) continue;
        //            table._Constraints.Remove(cnt);
        //            fk.SetDummyTable(table.FullName);
        //            replacement.Add(new AlterOperation_CreateConstraint
        //            {
        //                NewObject = fk
        //            });
        //        }
        //        return;
        //    }
        //    base.TransformToImplementedOps(caps, opts, replacement, plan, targetDb);
        //}
        //public override void RunNameTransformation(INameTransformation transform)
        //{
        //    base.RunNameTransformation(transform);
        //    var table = (TableStructure)NewObject;
        //    table.RunNameTransformation(transform);
        //}
        //public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        //{
        //    base.Run(proc, opts);
        //    if (Data != null) proc.UpdateData((TableStructure)NewObject, Data, null);
        //}
        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            Data = ((AlterOperation_CreateTable)src).Data;
        }
    }
    public class AlterOperation_DropTable : AlterOperation_Drop { }
    public class AlterOperation_RenameTable : AlterOperation_Rename { }
    public class AlterOperation_CreateSchema : AlterOperation_Create { }
    public class AlterOperation_DropSchema : AlterOperation_Drop { }
    public class AlterOperation_ChangeSchema : AlterOperation_Change { }
    public class AlterOperation_RenameSchema : AlterOperation_Rename { }

    public class AlterOperation_CustomAction : AlterOperation
    {
        public string Query;
        public int Order;
        public override int OrderGroup
        {
            get { return Order; }
        }
        public override void AssignFrom(AlterOperation src)
        {
            base.AssignFrom(src);
            Query = ((AlterOperation_CustomAction)src).Query;
            Order = ((AlterOperation_CustomAction)src).Order;
        }
        public override string ToString()
        {
            return Query.Trim();
        }
        public override void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            //proc.CustomAction(Query);
        }
    }
}
