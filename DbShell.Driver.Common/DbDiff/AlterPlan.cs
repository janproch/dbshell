using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    public enum RecreateItemClass { Unknown, SpecificObject, Reference, Constraint, Column }
    public enum PlanPosition { Begin, End }

    public class RecreatedItem
    {
        public DatabaseObjectInfo RecreatedObject;
        // if object is changed because of recreation; of notchanged, it should be null
        public DatabaseObjectInfo NewVersion;

        public RecreatedItem CloneForStructure(DatabaseInfo s)
        {
            var res = new RecreatedItem();
            res.RecreatedObject = s.FindByGroupId(RecreatedObject.GroupId);
            if (NewVersion != null) res.NewVersion = NewVersion.CloneObject(null);
            return res;
        }

        public static RecreateItemClass[] DropClassOrder
        {
            get
            {
                return new RecreateItemClass[] {
                    RecreateItemClass.Constraint,
                    RecreateItemClass.SpecificObject,
                    RecreateItemClass.Reference,
                    RecreateItemClass.Column,
                };
            }
        }

        public RecreateItemClass ItemClass
        {
            get
            {
                if (RecreatedObject is SpecificObjectInfo) return RecreateItemClass.SpecificObject;
                if (RecreatedObject is ForeignKeyInfo) return RecreateItemClass.Reference;
                if (RecreatedObject is ConstraintInfo) return RecreateItemClass.Constraint;
                if (RecreatedObject is ColumnInfo) return RecreateItemClass.Column;
                return RecreateItemClass.Unknown;
            }
        }

        //public void RunDrop(IAlterProcessor proc, DbDiffOptions opts)
        //{
        //    proc.DropObject(RecreatedObject);
        //}
        //public void RunCreate(IAlterProcessor proc, DbDiffOptions opts)
        //{
        //    if (NewVersion != null && NewVersion is TableObjectStructure)
        //    {
        //        TableObjectStructure obj2 = NewVersion.CloneObject() as TableObjectStructure;
        //        obj2.SetDummyTable(((ITableObjectStructure)RecreatedObject).Table.FullName);
        //        proc.CreateObject(obj2);
        //    }
        //    else
        //    {
        //        proc.CreateObject(RecreatedObject);
        //    }
        //}

        public void PlanDrop(AlterPlan plan, DbDiffOptions opts)
        {
            plan.RecreateObject_Drop(RecreatedObject);
        }
        public void PlanCreate(AlterPlan plan, DbDiffOptions opts)
        {
            plan.RecreateObject_Create(RecreatedObject, NewVersion ?? RecreatedObject);
        }

        public override string ToString()
        {
            return RecreatedObject.ToString();
        }
    }

    public class AlterPlanBase
    {
        public readonly DatabaseInfo Structure;
        public List<AlterOperation> Operations = new List<AlterOperation>();
        public List<RecreatedItem> RecreatedItems = new List<RecreatedItem>();

        public AlterPlanBase(DatabaseInfo db)
        {
            Structure = db.CloneDatabase();
        }
    }

    public class AlterPlan : AlterPlanBase
    {

        public static int BEFORE_ORDERGROUP = -10;
        public static int AFTER_ORDERGROUP = 10;

        public AlterPlan(DatabaseInfo db)
            : base(db)
        {
        }

        public bool DenyTransaction { get; private set; }

        // this structure is incrementally loaded, when needed
        //int m_fixedOrderCounter = 0;

        public void RecreateObject(DatabaseObjectInfo recreatedObject, DatabaseObjectInfo newVersion)
        {
            foreach (var it in RecreatedItems)
            {
                if (it.RecreatedObject == recreatedObject)
                {
                    if (it.NewVersion != null && newVersion != null) throw new InternalError("DBSH-00140 Two new versions of object " + recreatedObject.ToString());
                    it.NewVersion = newVersion ?? it.NewVersion;
                    return;
                }
            }
            RecreatedItems.Add(new RecreatedItem { RecreatedObject = recreatedObject, NewVersion = newVersion });
        }

        private void AddOperation(AlterOperation op, PlanPosition position = PlanPosition.End)
        {
            switch (position)
            {
                case PlanPosition.Begin:
                    Operations.Insert(0, op);
                    break;
                case PlanPosition.End:
                    Operations.Add(op);
                    break;
            }
        }

        //public void DropDomain(IDomainStructure domain)
        //{
        //    DomainStructure dom = Structure.FindOrCreateDomain(domain);
        //    AddOperation(new AlterOperation_DropDomain { OldObject = dom });
        //}
        //public void CreateDomain(IDomainStructure domain)
        //{
        //    DomainStructure dom = new DomainStructure(domain);
        //    AddOperation(new AlterOperation_CreateDomain { NewObject = dom });
        //}
        //public void RenameDomain(IDomainStructure domain, NameWithSchema newname)
        //{
        //    DomainStructure dom = Structure.FindOrCreateDomain(domain);
        //    AddOperation(new AlterOperation_RenameDomain { OldObject = dom, NewName = newname });
        //}
        //public void ChangeDomain(IDomainStructure domain, IDomainStructure newdomain)
        //{
        //    DomainStructure dom = Structure.FindOrCreateDomain(domain);
        //    DomainStructure newdom = new DomainStructure(newdomain);
        //    AddOperation(new AlterOperation_ChangeDomain { OldObject = dom, NewObject = newdom });
        //}
        public void DropTable(TableInfo table)
        {
            TableInfo tbl = Structure.FindOrCreateTable(table.FullName);
            AddOperation(new AlterOperation_DropTable { OldObject = tbl });
        }
        public void DropConstraint(ConstraintInfo constraint, PlanPosition pos = PlanPosition.End)
        {
            ConstraintInfo cnt = Structure.FindOrCreateConstraint(constraint);
            AddOperation(new AlterOperation_DropConstraint { ParentTable = cnt.OwnerTable, OldObject = cnt }, pos);
        }
        public void DropColumn(ColumnInfo column, PlanPosition pos = PlanPosition.End)
        {
            var col = Structure.FindOrCreateColumn(column);
            AddOperation(new AlterOperation_DropColumn { ParentTable = col.OwnerTable, OldObject = col }, pos);
        }
        public void RenameTable(TableInfo table, NameWithSchema name)
        {
            var tbl = Structure.FindOrCreateTable(table.FullName);
            AddOperation(new AlterOperation_RenameTable { OldObject = tbl, NewName = name });
        }
        public void RenameColumn(ColumnInfo column, string name)
        {
            var col = Structure.FindOrCreateColumn(column);
            AddOperation(new AlterOperation_RenameColumn { OldObject = col, ParentTable = col.OwnerTable, NewName = new NameWithSchema(name) });
        }
        public void ChangeColumn(ColumnInfo column, ColumnInfo newcolumn)
        {
            ColumnInfo col = Structure.FindOrCreateColumn(column);
            AddOperation(new AlterOperation_ChangeColumn { OldObject = col, ParentTable = col.OwnerTable, NewObject = newcolumn.CloneColumn()});
        }
        public void UpdateData(NameWithSchema table, DataScript script)
        {
            TableInfo tbl = Structure.FindOrCreateTable(table);
            AddOperation(new AlterOperation_UpdateData { ParentTable = tbl, Script = script });
        }
        public void RenameConstraint(ConstraintInfo constraint, string newname)
        {
            ConstraintInfo cnt = Structure.FindOrCreateConstraint(constraint);
            AddOperation(new AlterOperation_RenameConstraint { OldObject = cnt, ParentTable = cnt.OwnerTable, NewName = new NameWithSchema(newname) });
        }
        public void ChangeConstraint(ConstraintInfo constraint, ConstraintInfo newconstraint)
        {
            ConstraintInfo cnt = Structure.FindOrCreateConstraint(constraint);
            AddOperation(new AlterOperation_ChangeConstraint { OldObject = cnt, ParentTable = cnt.OwnerTable, NewObject = newconstraint.CloneConstraint() });
        }
        public void ReorderColumns(TableInfo table, List<string> list)
        {
            TableInfo tbl = Structure.FindOrCreateTable(table.FullName);
            AddOperation(new AlterOperation_PermuteColumns { ParentTable = tbl, NewColumnOrder = list });
        }
        public void ChangeTableOptions(TableInfo table, Dictionary<string, string> alteredOptions)
        {
            TableInfo tbl = Structure.FindOrCreateTable(table.FullName);
            AddOperation(new AlterOperation_ChangeTableOptions { ParentTable = tbl, Options = alteredOptions });
        }
        public void ChangeDatabaseOptions(string dbname, Dictionary<string, string> options)
        {
            AddOperation(new AlterOperation_ChangeDatabaseOptions { DbName = dbname, Options = options });
        }
        public void CreateColumn(TableInfo table, ColumnInfo newcol, PlanPosition pos = PlanPosition.End)
        {
            TableInfo tbl = Structure.FindOrCreateTable(table.FullName);
            AddOperation(new AlterOperation_CreateColumn { ParentTable = tbl, NewObject = newcol.CloneColumn() }, pos);
        }
        public void CreateConstraint(TableInfo table, ConstraintInfo newcnt, PlanPosition pos = PlanPosition.End)
        {
            TableInfo tbl = Structure.FindOrCreateTable(table.FullName);
            AddOperation(new AlterOperation_CreateConstraint { ParentTable = tbl, NewObject = newcnt.CloneConstraint() }, pos);
        }
        public void CreateTable(TableInfo table)
        {
            CreateTable(table, null);
        }
        public void CreateTable(TableInfo table, DataScript data)
        {
            TableInfo tbl = table.CloneTable();
            AddOperation(new AlterOperation_CreateTable { NewObject = tbl, Data = data });
        }

        public void CreateSpecificObject(SpecificObjectInfo obj, PlanPosition pos = PlanPosition.End)
        {
            var o = obj.CloneSpecificObject();
            AddOperation(new AlterOperation_CreateSpecificObject { NewObject = o }, pos);
        }

        public void DropSpecificObject(SpecificObjectInfo obj, PlanPosition pos = PlanPosition.End)
        {
            var o = Structure.FindOrCreateSpecificObject(obj);
            AddOperation(new AlterOperation_DropSpecificObject { OldObject = o }, pos);
        }

        public void RenameSpecificObject(SpecificObjectInfo obj, NameWithSchema name)
        {
            var o = Structure.FindOrCreateSpecificObject(obj);
            AddOperation(new AlterOperation_RenameSpecificObject { OldObject = o, NewName = name });
        }

        public void ChangeSpecificObject(SpecificObjectInfo obj, SpecificObjectInfo newobj)
        {
            var o = Structure.FindOrCreateSpecificObject(obj);
            AddOperation(new AlterOperation_ChangeSpecificObject {OldObject = o, NewObject = newobj.CloneSpecificObject()});
        }

        //public void CreateSchema(ISchemaStructure schema)
        //{
        //    SchemaStructure s = new SchemaStructure(schema);
        //    AddOperation(new AlterOperation_CreateSchema { NewObject = s });
        //}

        //public void RenameSchema(ISchemaStructure schema, string name)
        //{
        //    SchemaStructure s = Structure.FindOrCreateSchema(schema);
        //    AddOperation(new AlterOperation_RenameSchema { OldObject = s, NewName = new NameWithSchema(name) });
        //}

        //public void DropSchema(ISchemaStructure schema)
        //{
        //    SchemaStructure s = Structure.FindOrCreateSchema(schema);
        //    AddOperation(new AlterOperation_DropSchema { OldObject = s });
        //}

        public void CustomAction(string sql, int orderGroup)
        {
            AddOperation(new AlterOperation_CustomAction { Query = sql, Order = orderGroup });
        }

        public AlterPlanRunner CreateRunner()
        {
            var res = new AlterPlanRunner(Structure);
            foreach (var op in Operations)
            {
                res.Operations.Add(op.CloneForStructure(res.Structure));
            }
            foreach (var it in RecreatedItems)
            {
                res.RecreatedItems.Add(it.CloneForStructure(res.Structure));
            }
            return res;
        }

        //public void EndFixedOrder()
        //{
        //    m_fixedOrderCounter++;
        //}

        //public void BeginFixedOrder()
        //{
        //    m_fixedOrderCounter--;
        //}

        public void AddLogicalDependencies(AlterProcessorCaps caps, DbDiffOptions opts)
        {
            for (int index = 0; index < Operations.Count; index++)
            {
                var before = new List<AlterOperation>();
                var after = new List<AlterOperation>();
                Operations[index].AddLogicalDependencies(caps, opts, before, after, this);
                Operations.InsertRange(index, before);
                index += before.Count;
                Operations.InsertRange(index + 1, after);
                index += after.Count;
            }
        }

        public void Transform(AlterProcessorCaps caps, DbDiffOptions opts)
        {
            // transform operations
            for (int index = 0; index < Operations.Count; )
            {
                var list = new List<AlterOperation>();
                list.Add(Operations[index]);
                Operations[index].TransformToImplementedOps(caps, opts, list, this);
                if (list.Count == 1)
                {
                    Operations[index] = list[0];
                    index++;
                }
                else
                {
                    Operations.RemoveAt(index);
                    Operations.InsertRange(index, list);
                    index += list.Count;
                }
            }

            // add physical dependencies
            for (int index = 0; index < Operations.Count; index++)
            {
                var before = new List<AlterOperation>();
                var after = new List<AlterOperation>();
                Operations[index].AddPhysicalDependencies(caps, opts, before, after, this);
                Operations.InsertRange(index, before);
                index += before.Count;
                Operations.InsertRange(index + 1, after);
                index += after.Count;
            }

            // join recreate table operations
            for (int index = 0; index < Operations.Count; index++)
            {
                var rop = Operations[index] as AlterOperation_RecreateTable;
                if (rop != null)
                {
                    for (int i = index - 1; i >= 0; i--)
                    {
                        if (Operations[i].ParentTable == rop.ParentTable)
                        {
                            rop.InsertOp(Operations[i]);
                            Operations.RemoveAt(i);
                            index--;
                        }
                    }
                    for (int i = index + 1; i < Operations.Count; )
                    {
                        if (Operations[i].ParentTable == rop.ParentTable)
                        {
                            rop.AppendOp(Operations[i]);
                            Operations.RemoveAt(i);
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }

            // absorb operatios
            for (int index = 0; index < Operations.Count; index++)
            {
                if (Operations[index].MustRunAbsorbTest(caps))
                {
                    for (int i = 0; i < Operations.Count; i++)
                    {
                        if (i == index) continue;
                        if (Operations[index].AbsorbOperation(caps, Operations[i]))
                        {
                            Operations.RemoveAt(i);
                            if (i < index) index--;
                        }
                    }
                }
            }

            // remove recreates which are dropped
            for (int index = 0; index < RecreatedItems.Count; )
            {
                bool remove = false;
                foreach (var op in Operations)
                {
                    if (op.GetDropObject() == RecreatedItems[index].RecreatedObject)
                    {
                        remove = true;
                    }
                }
                if (remove)
                {
                    RecreatedItems.RemoveAt(index);
                }
                else
                {
                    index++;
                }
            }

            // transform recreations into regular operations so that they can be sorted
            foreach (var dep in RecreatedItems)
            {
                opts.AlterLogger.Info(String.Format("Recreated object {0}", dep.RecreatedObject));
            }
            foreach (var cls in RecreatedItem.DropClassOrder)
            {
                foreach (var dep in RecreatedItems)
                {
                    if (dep.ItemClass != cls) continue;
                    dep.PlanDrop(this, opts);
                }
            }
            foreach (var cls in RecreatedItem.DropClassOrder)
            {
                foreach (var dep in RecreatedItems)
                {
                    if (dep.ItemClass != cls) continue;
                    dep.PlanCreate(this, opts);
                }
            }


            // reorder operations
            // foreign key creation should be at last
            // simulate stable order (List.Sort is not stable!!)
            for (int i = 0; i < Operations.Count; i++) Operations[i].m_tmpOrder = i;
            Operations.Sort(OrderGroupCompare);

            foreach (var op in Operations)
            {
                if (op.DenyTransaction()) DenyTransaction = true;
            }
        }

        public static int OrderGroupCompare(AlterOperation a, AlterOperation b)
        {
            int res = a.OrderGroup - b.OrderGroup;
            if (res != 0) return res;
            return a.m_tmpOrder - b.m_tmpOrder;
        }

        public void RecreateObject_Drop(DatabaseObjectInfo obj)
        {
            var cnt = obj as ConstraintInfo;
            if (cnt != null) DropConstraint(cnt, PlanPosition.Begin);
            var spec = obj as SpecificObjectInfo;
            if (spec != null) DropSpecificObject(spec, PlanPosition.Begin);
            var col = obj as ColumnInfo;
            if (col != null) DropColumn(col, PlanPosition.Begin);
        }

        public void RecreateObject_Create(DatabaseObjectInfo recreated, DatabaseObjectInfo newobj)
        {
            var cnt = newobj as ConstraintInfo;
            if (cnt != null) CreateConstraint(((ConstraintInfo)recreated).OwnerTable, cnt, PlanPosition.End);
            var spec = newobj as SpecificObjectInfo;
            if (spec != null) CreateSpecificObject(spec, PlanPosition.End);
            var col = newobj as ColumnInfo;
            if (col != null) CreateColumn(((ColumnInfo)recreated).OwnerTable, col, PlanPosition.End);
        }

        public void RunNameTransformation(INameTransformation transform)
        {
            foreach (var op in Operations)
            {
                op.RunNameTransformation(transform);
            }
        }
    }

    public class AlterPlanRunner : AlterPlanBase
    {
        public AlterPlanRunner(DatabaseInfo db)
            : base(db)
        {
        }

        public void Run(IAlterProcessor proc, DbDiffOptions opts)
        {
            //foreach (var dep in RecreatedItems)
            //{
            //    opts.AlterLogger.Info(Texts.Get("s_recreated_object$object", "object", dep.RecreatedObject));
            //}

            //foreach (var cls in RecreatedItem.DropClassOrder)
            //{
            //    foreach (var dep in RecreatedItems)
            //    {
            //        if (dep.ItemClass != cls) continue;
            //        dep.RunDrop(proc, opts);
            //    }
            //}
            foreach (var op in Operations)
            {
                op.Run(proc, opts);
                using (DbDiffChangeLoggerContext ctx = new DbDiffChangeLoggerContext(opts, NopMessageLogger.Instance, DbDiffOptsLogger.AlterLogger))
                {
                    if (op.MustRunOnParalelStructure())
                    {
                        // run operation paralel on Structure, so that we have actual object names
                        op.Run(new DatabaseInfoAlterProcessor(Structure), opts);
                    }
                }
            }
        }
    }
}
