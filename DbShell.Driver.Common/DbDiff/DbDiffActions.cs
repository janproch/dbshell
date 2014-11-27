using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    public enum DbDiffActionType
    {
        Add, Remove, Change, Equal
    }

    public class DbDiffAction
    {
        protected DatabaseDiff m_diff;
        //public DbDiffActionNode Node;
        public string GroupId;
        public AlterOperation Operation;
        public List<DbDiffAction> Elements = new List<DbDiffAction>();
        public TableInfo ParentTable;

        FullDatabaseRelatedName m_srcName, m_dstName;
        DatabaseObjectInfo m_srcObject, m_dstObject, m_anyObject;
        public object Tag;
        //DatabaseObjectInfo m_repr;

        public DbDiffAction(DatabaseDiff diff)
        {
            m_diff = diff;
        }


        public FullDatabaseRelatedName SourceName
        {
            get
            {
                WantInfo();
                return m_srcName;
            }
        }

        public FullDatabaseRelatedName TargetName
        {
            get
            {
                WantInfo();
                return m_dstName;
            }
        }

        //public string SourceName
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_srcName != null && m_srcName.ObjectName != null) return m_srcName.ObjectName.Name;
        //        return null;
        //    }
        //}
        //public string SourceSchema
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_srcName != null && m_srcName.ObjectName != null) return m_srcName.ObjectName.Schema;
        //        return null;
        //    }
        //}
        //public string TargetName
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_dstName != null && m_dstName.ObjectName != null) return m_dstName.ObjectName.Name;
        //        return null;
        //    }
        //}
        //public string TargetSchema
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_dstName != null && m_dstName.ObjectName != null) return m_dstName.ObjectName.Schema;
        //        return null;
        //    }
        //}
        //public string ObjectType
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_repr != null) return Texts.Get(m_repr.TitleSingular);
        //        return null;
        //    }
        //}
        public DbDiffActionType ActionType
        {
            get
            {
                WantInfo();
                if (Operation == null && Elements.Count == 0) return DbDiffActionType.Equal;
                if (m_srcObject != null && m_dstObject != null) return DbDiffActionType.Change;
                if (m_srcObject != null) return DbDiffActionType.Add;
                return DbDiffActionType.Remove;
            }
        }
        //public Bitmap RelationImage
        //{
        //    get
        //    {
        //        switch (ActionType)
        //        {
        //            case DbDiffActionType.Equal: return CoreIcons.equals;
        //            case DbDiffActionType.Add: return CoreIcons.add;
        //            case DbDiffActionType.Change: return CoreIcons.pen;
        //            case DbDiffActionType.Remove: return CoreIcons.remove;
        //        }
        //        return null;
        //    }
        //}
        public DatabaseObjectInfo AnyObject
        {
            get
            {
                WantInfo();
                return m_anyObject;
            }
        }
        public DatabaseObjectInfo SourceObject
        {
            get
            {
                WantInfo();
                return m_srcObject;
            }
        }
        public DatabaseObjectInfo TargetObject
        {
            get
            {
                WantInfo();
                return m_dstObject;
            }
        }
        //public string SourceSubName
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_srcName != null) return m_srcName.SubName;
        //        return null;
        //    }
        //}
        //public string TargetSubName
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_dstName != null) return m_dstName.SubName;
        //        return null;
        //    }
        //}
        public DatabaseObjectType ObjectType
        {
            get
            {
                WantInfo();
                return m_anyObject.ObjectType;
            }
        }

        //public bool SourceColumnNullable
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_srcObject != null) return ((IColumnStructure)m_srcObject).IsNullable;
        //        return false;
        //    }
        //}
        //public bool TargetColumnNullable
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_dstObject != null) return ((IColumnStructure)m_dstObject).IsNullable;
        //        return false;
        //    }
        //}
        //public string SourceColumnType
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_srcObject != null) return m_diff.Source.Dialect.GenericTypeToSpecific(((IColumnStructure)m_srcObject).DataType).ToString();
        //        return "";
        //    }
        //}
        //public string TargetColumnType
        //{
        //    get
        //    {
        //        WantInfo();
        //        if (m_dstObject != null) return m_diff.Target.Dialect.GenericTypeToSpecific(((IColumnStructure)m_dstObject).DataType).ToString();
        //        return "";
        //    }
        //}
        //public string ConstraintType
        //{
        //    get
        //    {
        //        WantInfo();
        //        return m_anyObject.GetName().ObjectType.ToString();
        //    }
        //}
        //public string SourceConstraintColumns
        //{
        //    get
        //    {
        //        var cnt = m_srcObject as ColumnsConstraintInfo;
        //        if (cnt != null) return cnt.Columns.GetNames().CreateDelimitedText(",");
        //        return null;
        //    }
        //}
        //public string TargetConstraintColumns
        //{
        //    get
        //    {
        //        var cnt = m_dstObject as ColumnsConstraintInfo;
        //        if (cnt != null) return cnt.Columns.GetNames().CreateDelimitedText(",");
        //        return null;
        //    }
        //}
        //public string ActionSqlTitle
        //{
        //    get
        //    {
        //        if (Operation != null) return Operation.ToString();
        //        return null;
        //    }
        //}

        private void WantInfo()
        {
            if (m_anyObject != null) return;
            if (GroupId == null) return;
            m_srcObject = m_diff.FindSource(GroupId);
            m_dstObject = m_diff.FindTarget(GroupId);
            m_anyObject = m_srcObject ?? m_dstObject;
            //Errors.CheckNotNull("DAE-00364", m_anyObject);
            m_srcName = m_srcObject != null ? m_srcObject.GetName() : null;
            m_dstName = m_dstObject != null ? m_dstObject.GetName() : null;
            var name = m_anyObject.GetName();
        }

        //private bool m_isChecked;

        //public bool IsChecked
        //{
        //    get { return m_isChecked; }
        //    set
        //    {
        //        if (Operation == null && Elements.Count == 0) return;
        //        m_isChecked = value;
        //        m_diff.CallChangedAction(this);
        //    }
        //}

        public void GetOperations(AlterPlan plan, Func<DbDiffAction, bool> useActionFunc)
        {
            if (!useActionFunc(this)) return;
            if (Operation != null) plan.Operations.Add(Operation);
            foreach (var elem in Elements) elem.GetOperations(plan, useActionFunc);
        }

        public AlterPlan GetPlanForThis(DatabaseInfo targetDb, Func<DbDiffAction, bool> useActionFunc)
        {
            var plan = new AlterPlan(m_diff.Target);
            GetOperations(plan, useActionFunc);
            plan.Transform(m_diff._factory.DumperCaps, m_diff._options);
            return plan;
        }

        public string GenerateSql(DatabaseInfo targetDb, Func<DbDiffAction, bool> useActionFunc)
        {
            var plan = GetPlanForThis(targetDb, useActionFunc);
            return m_diff._factory.GenerateScript(dmp => plan.CreateRunner().Run(dmp, m_diff._options));
        }

        //public DbSourceTarget GetAlter()
        //{
        //    var db = new DatabaseStructure(m_diff.Target);
        //    AlterStructure(db);
        //    return new DbSourceTarget(m_diff.Target, db);
        //}

        //public void GenerateScript(IAlterProcessor proc)
        //{
        //    var d = GetAlter();
        //    //DbDiffTool.AlterDatabase(proc, d.Source, d.Target, m_diff.m_options);
        //}

        ////protected abstract void DoAlterStructure(DatabaseStructure db);
        //public void AlterStructure(DatabaseStructure db)
        //{
        //    if (IsChecked) DoAlterStructure(db);
        //}

        protected void SetMappings(params DatabaseObjectInfo[] objs)
        {
            foreach (var obj in objs)
            {
                if (obj != null)
                {
                    m_diff.IdToAction[obj.GroupId] = this;
                    GroupId = obj.GroupId;
                }
            }
        }

        public void AfterCreate()
        {
            if (ParentTable != null)
            {
                SetMappings(ParentTable);
                m_diff.AddAlteredObject(ParentTable);
            }
            else
            {
                foreach (var item in Operation.EnumObjects())
                {
                    SetMappings(item.Object);
                    if (item.ActionType == AlterObjectActionType.Change || item.ActionType == AlterObjectActionType.Rename)
                    {
                        m_diff.AddAlteredObject(item.Object);
                    }
                }
            }
        }

        public override string ToString()
        {
            if (ParentTable != null) return "ALTER TABLE " + ParentTable.FullName.ToString();
            if (Operation == null) return base.ToString();
            return Operation.ToString();
        }

        //public int GetObjectTypeImage(ImageCache imgCache)
        //{
        //    return imgCache.GetImageIndex(ObjectTypeImage);
        //}

        //public int GetRelationImage(ImageCache imgCache)
        //{
        //    return imgCache.GetImageIndex(RelationImage);
        //}

        public void CountActions(ref int added, ref int removed, ref int changed, ref int equal)
        {
            foreach (var elem in Elements)
            {
                switch (elem.ActionType)
                {
                    case DbDiffActionType.Add: added++; break;
                    case DbDiffActionType.Change: changed++; break;
                    case DbDiffActionType.Remove: removed++; break;
                    case DbDiffActionType.Equal: equal++; break;
                }
            }
        }
    }

    //public abstract class DbDiffAlterAction : DbDiffAction
    //{
    //    protected readonly IAbstractObjectStructure m_src;
    //    protected readonly IAbstractObjectStructure m_dst;

    //    public IAbstractObjectStructure Source { get { return m_src; } }
    //    public IAbstractObjectStructure Target { get { return m_dst; } }

    //    protected DbDiffAlterAction(DatabaseDiff diff, IAbstractObjectStructure src, IAbstractObjectStructure dst)
    //        : base(diff)
    //    {
    //        m_src = src;
    //        m_dst = dst;
    //        SetMappings(src, dst);
    //    }
    //}

    //public abstract class DbDiffContainerAction : DbDiffAction
    //{

    //    protected DbDiffContainerAction(DatabaseDiff diff)
    //        : base(diff)
    //    {
    //    }

    //    public override void FillTreeNodes(TreeNodeCollection nodes)
    //    {
    //        foreach (var elem in Elements)
    //        {
    //            nodes.Add(elem.CreateNode());
    //        }
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        foreach (var elem in Elements) elem.AlterStructure(db);
    //    }
    //}

    //public class DbDiffActionNode : TreeNode
    //{
    //    DbDiffAction m_action;
    //    public DbDiffActionNode(DbDiffAction action)
    //    {
    //        m_action = action;
    //        m_action.Node = this;
    //        Text = action.ToString();
    //    }

    //    public DbDiffAction Action { get { return m_action; } }
    //}

    //public abstract class DiffActionTable : DbDiffAction
    //{
    //    protected ITableStructure m_table;
    //    public DiffActionTable(DatabaseDiff diff, ITableStructure table)
    //        : base(diff)
    //    {
    //        m_table = table;
    //        SetMappings(table);
    //    }
    //}

    //public class DiffActionDropTable : DiffActionTable
    //{
    //    public DiffActionDropTable(DatabaseDiff diff, ITableStructure obj)
    //        : base(diff, obj)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return "DROP TABLE " + m_table.FullName.ToString();
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.DropTable(m_table);
    //    }
    //}

    //public class DiffActionCreateTable : DiffActionTable
    //{
    //    public DiffActionCreateTable(DatabaseDiff diff, ITableStructure obj)
    //        : base(diff, obj)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return "CREATE TABLE " + m_table.FullName.ToString();
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.CreateTable(m_table);
    //    }
    //}

    //public class DiffActionRecreateTable : DbDiffAlterAction
    //{
    //    public DiffActionRecreateTable(DatabaseDiff diff, ITableStructure src, ITableStructure dst)
    //        : base(diff, src, dst)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return "RECREATE TABLE " + ((ITableStructure)Source).FullName.ToString();
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.RecreateTable((ITableStructure)Source, (ITableStructure)Target);
    //    }
    //}

    //public class DiffActionAlterTable : DbDiffContainerAction
    //{
    //    internal ITableStructure m_src;
    //    internal ITableStructure m_dst;

    //    public DiffActionAlterTable(DatabaseDiff diff, ITableStructure src, ITableStructure dst)
    //        : base(diff)
    //    {
    //        m_src = src;
    //        m_dst = dst;
    //        SetMappings(src, dst);
    //    }

    //    public override string ToString()
    //    {
    //        return "ALTER TABLE " + m_src.FullName.ToString();
    //    }
    //}

    //public class DiffActionDatabase : DbDiffContainerAction
    //{
    //    DatabaseStructure m_src;
    //    DatabaseStructure m_dst;

    //    public DiffActionDatabase(DatabaseDiff diff, DatabaseStructure src, DatabaseStructure dst)
    //        : base(diff)
    //    {
    //        m_src = src;
    //        m_dst = dst;
    //    }
    //}

    //public abstract class DiffActionColumn : DbDiffAction
    //{
    //    protected IColumnStructure m_column;
    //    public DiffActionColumn(DatabaseDiff diff, IColumnStructure column)
    //        : base(diff)
    //    {
    //        m_column = column;
    //        SetMappings(column);
    //    }
    //}

    //public class DiffActionAddColumn : DiffActionColumn
    //{
    //    public DiffActionAddColumn(DatabaseDiff diff, IColumnStructure col)
    //        : base(diff, col)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("ADD COLUMN {0} : {1}", m_column.ColumnName, m_column.DataType);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.AddObject(m_column);
    //    }
    //}

    //public class DiffActionDropColumn : DiffActionColumn
    //{
    //    public DiffActionDropColumn(DatabaseDiff diff, IColumnStructure col)
    //        : base(diff, col)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("DROP COLUMN {0}", m_column.ColumnName);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.DropColumn(m_column);
    //    }
    //}

    //public class DiffActionRenameColumn : DiffActionColumn
    //{
    //    string m_newname;

    //    public DiffActionRenameColumn(DatabaseDiff diff, IColumnStructure col, string newname)
    //        : base(diff, col)
    //    {
    //        m_newname = newname;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("RENAME COLUMN {0} TO {1}", m_column.ColumnName, m_newname);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.RenameColumn(m_column, m_newname);
    //    }
    //}

    //public class DiffActionChangeColumn : DbDiffAlterAction
    //{
    //    public DiffActionChangeColumn(DatabaseDiff diff, IColumnStructure src, IColumnStructure dst)
    //        : base(diff, src,dst)
    //    {
    //    }

    //    public new IColumnStructure Source { get { return (IColumnStructure)m_src; } }
    //    public new IColumnStructure Target { get { return (IColumnStructure)m_dst; } }

    //    public override string ToString()
    //    {
    //        return String.Format("CHANGE COLUMN {0} : {1}", Source.ColumnName, Source.DataType);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.ChangeColumn(Source, Target);
    //    }
    //}

    //public abstract class DiffActionConstraint : DbDiffAction
    //{
    //    protected IConstraint m_constraint;
    //    public DiffActionConstraint(DatabaseDiff diff, IConstraint cnt)
    //        : base(diff)
    //    {
    //        SetMappings(cnt);
    //        m_constraint = cnt;
    //    }
    //}

    //public class DiffActionCreateConstraint : DiffActionConstraint
    //{
    //    public DiffActionCreateConstraint(DatabaseDiff diff, IConstraint cnt)
    //        : base(diff, cnt)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("ADD CONSTRAINT {0} : {1}", m_constraint.Name, m_constraint.Type.GetSqlName());
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.CreateConstraint(m_constraint);
    //    }
    //}

    //public class DiffActionDropConstraint : DiffActionConstraint
    //{
    //    public DiffActionDropConstraint(DatabaseDiff diff, IConstraint cnt)
    //        : base(diff, cnt)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("DROP CONSTRAINT {0} : {1}", m_constraint.Name, m_constraint.Type.GetSqlName());
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.DropConstraint(m_constraint);
    //    }
    //}

    //public abstract class DiffActionSpecificObject : DbDiffAction
    //{
    //    protected ISpecificObjectStructure m_obj;
    //    public DiffActionSpecificObject(DatabaseDiff diff, ISpecificObjectStructure obj)
    //        : base(diff)
    //    {
    //        SetMappings(obj);
    //        m_obj = obj;
    //    }
    //}

    //public class DiffActionCreateSpecificObject : DiffActionSpecificObject
    //{
    //    public DiffActionCreateSpecificObject(DatabaseDiff diff, ISpecificObjectStructure obj)
    //        : base(diff, obj)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("CREATE {0} {1}", m_obj.ObjectType.ToUpper(), m_obj.ObjectName);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.CreateSpecificObject(m_obj);
    //    }
    //}

    //public class DiffActionDropSpecificObject : DiffActionSpecificObject
    //{
    //    public DiffActionDropSpecificObject(DatabaseDiff diff, ISpecificObjectStructure obj)
    //        : base(diff, obj)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("DROP {0} {1}", m_obj.ObjectType.ToUpper(), m_obj.ObjectName);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.DropSpecificObject(m_obj);
    //    }
    //}

    //public class DiffActionReorderColumns : DbDiffAction
    //{
    //    NameWithSchema m_table;
    //    List<string> m_newColumnOrder;

    //    public DiffActionReorderColumns(DatabaseDiff diff, NameWithSchema table, List<string> newColumnOrder)
    //        : base(diff)
    //    {
    //        m_table = table;
    //        m_newColumnOrder = newColumnOrder;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("REORDER COLUMNS {0}", m_newColumnOrder.CreateDelimitedText(","));
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.ReorderColumns(m_table,m_newColumnOrder);
    //    }
    //}

    //public class DiffActionRenameConstraint : DiffActionConstraint
    //{
    //    string m_newname;

    //    public DiffActionRenameConstraint(DatabaseDiff diff, IConstraint cnt, string newname)
    //        :base(diff, cnt)
    //    {
    //        m_newname = newname;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("RENAME {0} {1} TO {2}", m_constraint.Type.GetSqlName(), m_constraint.Name, m_newname);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.RenameConstraint(m_constraint, m_newname);
    //    }
    //}

    //public class DiffActionRenameTable : DbDiffAction
    //{
    //    NameWithSchema m_table;
    //    string m_newname;

    //    public DiffActionRenameTable(DatabaseDiff diff, NameWithSchema table, string newname)
    //        : base(diff)
    //    {
    //        m_newname = newname;
    //        m_table = table;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("RENAME TABLE {0} TO {1}", m_table, m_newname);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.RenameTable(m_table, m_newname);
    //    }
    //}

    //public class DiffActionChangeTableSchema : DbDiffAction
    //{
    //    NameWithSchema m_table;
    //    string m_newschema;

    //    public DiffActionChangeTableSchema(DatabaseDiff diff, NameWithSchema table, string newname)
    //        : base(diff)
    //    {
    //        m_newschema = newname;
    //        m_table = table;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("CHANGE TABLE SCHEMA {0} TO {1}", m_table, m_newschema);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.ChangeTableSchema(m_table, m_newschema);
    //    }
    //}

    //public class DiffActionRenameSpecificObject : DbDiffAction
    //{
    //    ISpecificObjectStructure m_obj;
    //    string m_newname;

    //    public DiffActionRenameSpecificObject(DatabaseDiff diff, ISpecificObjectStructure obj, string newname)
    //        : base(diff)
    //    {
    //        m_newname = newname;
    //        m_obj = obj;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("RENAME {0} {1} TO {2}", m_obj.ObjectType.ToUpper(), m_obj, m_newname);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.RenameSpecificObject(m_obj, m_newname);
    //    }
    //}

    //public class DiffActionChangeSpecificObjectSchema : DbDiffAction
    //{
    //    ISpecificObjectStructure m_obj;
    //    string m_newschema;

    //    public DiffActionChangeSpecificObjectSchema(DatabaseDiff diff, ISpecificObjectStructure obj, string newname)
    //        : base(diff)
    //    {
    //        m_newschema = newname;
    //        m_obj = obj;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("CHANGE {0} SCHEMA {1} TO {2}", m_obj.ObjectType.ToUpper(), m_obj, m_newschema);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.ChangeSpecificObjectSchema(m_obj, m_newschema);
    //    }
    //}

    //public abstract class DiffActionSchema : DbDiffAction
    //{
    //    protected ISchemaStructure m_schema;
    //    public DiffActionSchema(DatabaseDiff diff, ISchemaStructure schema)
    //        : base(diff)
    //    {
    //        m_schema = schema;
    //        SetMappings(schema);
    //    }
    //}

    //public class DiffActionCreateSchema : DiffActionSchema
    //{
    //    public DiffActionCreateSchema(DatabaseDiff diff, ISchemaStructure schema)
    //        : base(diff, schema)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("CREATE SCHEMA {0}", m_schema.SchemaName);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.CreateSchema(m_schema);
    //    }
    //}

    //public class DiffActionDropSchema : DiffActionSchema
    //{
    //    public DiffActionDropSchema(DatabaseDiff diff, ISchemaStructure schema)
    //        : base(diff, schema)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("DROP SCHEMA {0}", m_schema.SchemaName);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.DropSchema(m_schema);
    //    }
    //}

    //public class DiffActionRenameSchema : DiffActionSchema
    //{
    //    string m_newname;
    //    public DiffActionRenameSchema(DatabaseDiff diff, ISchemaStructure schema, string newname)
    //        : base(diff, schema)
    //    {
    //        m_newname = newname;
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("RENAME SCHEMA {0} TO {1}", m_schema.SchemaName, m_newname);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.RenameSchema(m_schema, m_newname);
    //    }
    //}

    //public class DiffActionAlterTableOptions : DiffActionTable
    //{
    //    Dictionary<string, string> m_changedOptions;
    //    public DiffActionAlterTableOptions(DatabaseDiff diff, ITableStructure obj, Dictionary<string,string> changedOptions)
    //        : base(diff, obj)
    //    {
    //        m_changedOptions = changedOptions;
    //    }

    //    public override string ToString()
    //    {
    //        return "ALTER OPTIONS " + m_changedOptions.MapEach(p => p.Key + "=" + p.Value).CreateDelimitedText(",");
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.AlterTableOptions(m_table, m_changedOptions);
    //    }
    //}

    //public abstract class DiffActionDomain : DbDiffAction
    //{
    //    protected IDomainStructure m_domain;
    //    public DiffActionDomain(DatabaseDiff diff, IDomainStructure domain)
    //        : base(diff)
    //    {
    //        m_domain = domain;
    //        SetMappings(domain);
    //    }
    //}

    //public class DiffActionCreateDomain : DiffActionDomain
    //{
    //    public DiffActionCreateDomain(DatabaseDiff diff, IDomainStructure domain)
    //        : base(diff, domain)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("CREATE DOMAIN {0}", m_domain.FullName);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.CreateDomain(m_domain);
    //    }
    //}

    //public class DiffActionDropDomain : DiffActionDomain
    //{
    //    public DiffActionDropDomain(DatabaseDiff diff, IDomainStructure domain)
    //        : base(diff, domain)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("DROP DOMAIN {0}", m_domain.FullName);
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        db.DropDomain(m_domain);
    //    }
    //}

    //public class DiffActionUpdateData : DbDiffContainerAction
    //{
    //    NameWithSchema m_table;
    //    DataScript m_script;

    //    public DiffActionUpdateData(DatabaseDiff diff, NameWithSchema table, DataScript script)
    //        : base(diff)
    //    {
    //        SetMappings(diff.Source.Tables[table]);
    //        m_table = table;
    //        m_script = script;
    //        foreach (var action in m_script.EnumAllActions())
    //        {
    //            Elements.Add(new DiffActionUpdateDataItem(m_diff, m_table, action));
    //        }
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        DataScript script = new DataScript();
    //        foreach (DiffActionUpdateDataItem child in Elements)
    //        {
    //            if (child.IsChecked) script.AddAction(child.m_action);
    //        }
    //        db.UpdateData(m_table, script);
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("UPDATE TABLE {0}", m_table);
    //    }
    //}

    //public class DiffActionUpdateDataItem : DbDiffAction
    //{
    //    internal DataScript.ActionBase m_action;
    //    NameWithSchema m_table;

    //    public DiffActionUpdateDataItem(DatabaseDiff diff, NameWithSchema table, DataScript.ActionBase action)
    //        : base(diff)
    //    {
    //        m_action = action;
    //        m_table = table;
    //    }

    //    public override string ToString()
    //    {
    //        return m_action.ToString();
    //    }

    //    protected override void DoAlterStructure(DatabaseStructure db)
    //    {
    //        DataScript script = new DataScript();
    //        script.AddAction(m_action);
    //        db.UpdateData(m_table, script);
    //    }
    //}
}
