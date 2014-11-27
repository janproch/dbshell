using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.DbDiff
{
    partial class DatabaseDiff //: IAlterProcessor
    {
        private void CreateActions()
        {
            _plan = new AlterPlan(_dst);
            DbDiffTool.AlterDatabase(Plan, new DbObjectPairing(_dst, _src), _options);
            DbDiffAction lastAlterTable = null;

            foreach (var op in _plan.Operations)
            {
                DbDiffAction act;
                if (op.ParentTable != null)
                {
                    // this operation should be added to ALTER TABLE operation
                    if (lastAlterTable == null || lastAlterTable.ParentTable != op.ParentTable)
                    {
                        lastAlterTable = new DbDiffAction(this);
                        lastAlterTable.ParentTable = op.ParentTable;
                        lastAlterTable.AfterCreate();
                        _actions.Elements.Add(lastAlterTable);
                    }
                    act = new DbDiffAction(this);
                    act.Operation = op;
                    //act.IsChecked = true;
                    act.AfterCreate();
                    lastAlterTable.Elements.Add(act);
                }
                else
                {
                    act = new DbDiffAction(this);
                    act.Operation = op;
                    lastAlterTable = null;
                    act.AfterCreate();
                    _actions.Elements.Add(act);
                }
            }
            //this.AlterDatabase(m_dst, m_src, m_options);
        }

        //DiffActionAlterTable FindAlterTable(NameWithSchema table)
        //{
        //    foreach (var act in Actions.Elements)
        //    {
        //        var at = act as DiffActionAlterTable;
        //        if (at != null && (at.m_src.FullName == table || at.m_dst.FullName == table)) return at;
        //    }
        //    throw new InternalError("DAE-00065 Missing alter table");
        //}

        //#region IAlterProcessor Members

        //void IAlterProcessor.CreateColumn(IColumnStructure column)
        //{
        //    FindAlterTable(column.Table.FullName).Elements.Add(new DiffActionAddColumn(this, column));            
        //}

        //void IAlterProcessor.DropColumn(IColumnStructure column)
        //{
        //    FindAlterTable(column.Table.FullName).Elements.Add(new DiffActionDropColumn(this, column));            
        //}

        //void IAlterProcessor.RenameColumn(IColumnStructure column, string newcol)
        //{
        //    AddAlteredObject(column);
        //    FindAlterTable(column.Table.FullName).Elements.Add(new DiffActionRenameColumn(this, column, newcol));            
        //}

        //void IAlterProcessor.ChangeColumn(IColumnStructure oldcol, IColumnStructure newcol)
        //{
        //    AddAlteredObject(oldcol);
        //    FindAlterTable(oldcol.Table.FullName).Elements.Add(new DiffActionChangeColumn(this, oldcol, newcol));
        //}

        //void IAlterProcessor.ReorderColumns(NameWithSchema table, List<string> newColumnOrder)
        //{
        //    FindAlterTable(table).Elements.Add(new DiffActionReorderColumns(this, table, newColumnOrder));            
        //}

        //void IAlterProcessor.CreateConstraint(IConstraint constraint)
        //{
        //    FindAlterTable(constraint.Table.FullName).Elements.Add(new DiffActionCreateConstraint(this, constraint));            
        //}

        //void IAlterProcessor.DropConstraint(IConstraint constraint)
        //{
        //    FindAlterTable(constraint.Table.FullName).Elements.Add(new DiffActionDropConstraint(this, constraint));
        //}

        //void IAlterProcessor.RenameConstraint(IConstraint constraint, string newname)
        //{
        //    FindAlterTable(constraint.Table.FullName).Elements.Add(new DiffActionRenameConstraint(this, constraint, newname));            
        //}

        //void IAlterProcessor.RecreateTable(ITableStructure src, ITableStructure dst)
        //{
        //    Actions.Elements.Add(new DiffActionRecreateTable(this, src, dst));
        //}

        //void IAlterProcessor.CreateTable(ITableStructure tsrc)
        //{
        //    Actions.Elements.Add(new DiffActionCreateTable(this, tsrc));
        //}

        //void IAlterProcessor.DropTable(ITableStructure tdst)
        //{
        //    Actions.Elements.Add(new DiffActionDropTable(this, tdst));
        //}

        //void IAlterProcessor.ChangeTableSchema(NameWithSchema obj, string schema)
        //{
        //    Actions.Elements.Add(new DiffActionChangeTableSchema(this, obj,schema));
        //}

        //void IAlterProcessor.RenameTable(NameWithSchema obj, string newname)
        //{
        //    Actions.Elements.Add(new DiffActionRenameTable(this, obj, newname));
        //}

        //void IAlterProcessor.AlterTableOptions(ITableStructure table, Dictionary<string, string> options)
        //{
        //    FindAlterTable(table.FullName).Elements.Add(new DiffActionAlterTableOptions(this, table, options));            
        //}

        //void IAlterProcessor.CreateSpecificObject(ISpecificObjectStructure osrc)
        //{
        //    Actions.Elements.Add(new DiffActionCreateSpecificObject(this, osrc));
        //}

        //void IAlterProcessor.DropSpecificObject(ISpecificObjectStructure odst)
        //{
        //    Actions.Elements.Add(new DiffActionDropSpecificObject(this, odst));
        //}

        //void IAlterProcessor.ChangeSpecificObjectSchema(ISpecificObjectStructure obj, string newschema)
        //{
        //    Actions.Elements.Add(new DiffActionChangeSpecificObjectSchema(this, obj, newschema));
        //}

        //void IAlterProcessor.RenameSpecificObject(ISpecificObjectStructure obj, string newname)
        //{
        //    Actions.Elements.Add(new DiffActionRenameSpecificObject(this, obj, newname));
        //}

        //void IAlterProcessor.DropSchema(ISchemaStructure schema)
        //{
        //    Actions.Elements.Add(new DiffActionDropSchema(this, schema));
        //}

        //void IAlterProcessor.CreateSchema(ISchemaStructure schema)
        //{
        //    Actions.Elements.Add(new DiffActionCreateSchema(this, schema));
        //}

        //void IAlterProcessor.RenameSchema(ISchemaStructure schema, string newname)
        //{
        //    Actions.Elements.Add(new DiffActionRenameSchema(this, schema, newname));
        //}

        //AlterProcessorCaps IAlterProcessor.AlterCaps
        //{
        //    get
        //    {
        //        return new AlterProcessorCaps
        //        {
        //            AllFlags = true,
        //            RecreateTable = false
        //        };
        //    }
        //}

        //void IAlterProcessor.AlterTable(ITableStructure src, ITableStructure dst, out bool processed)
        //{
        //    Actions.Elements.Add(new DiffActionAlterTable(this, src, dst));
        //    processed = false;
        //    AddAlteredObject(src);
        //}

        //void IAlterProcessor.ChangeSpecificObject(ISpecificObjectStructure osrc, ISpecificObjectStructure odst, out bool processed)
        //{
        //    processed = false;
        //    AddAlteredObject(osrc);
        //}

        //void IAlterProcessor.DropDomain(IDomainStructure domain)
        //{
        //    Actions.Elements.Add(new DiffActionDropDomain(this, domain));
        //}

        //void IAlterProcessor.CreateDomain(IDomainStructure domain)
        //{
        //    Actions.Elements.Add(new DiffActionCreateDomain(this, domain));
        //}

        //void IAlterProcessor.ChangeDomain(IDomainStructure dsrc, IDomainStructure ddst)
        //{
        //    ((IAlterProcessor)this).DropDomain(dsrc);
        //    ((IAlterProcessor)this).CreateDomain(ddst);
        //}

        //void IAlterProcessor.RenameDomain(NameWithSchema domain, string newname)
        //{
        //}
        //void IAlterProcessor.ChangeDomainSchema(NameWithSchema domain, string newschema)
        //{
        //}

        //void IAlterProcessor.UpdateData(NameWithSchema table, DataScript script)
        //{
        //    if (script == null) return;
        //    Actions.Elements.Add(new DiffActionUpdateData(this, table, script));
        //}

        //IDatabaseSource IAlterProcessor.TargetDb
        //{
        //    get { return null; }
        //}

        //#endregion
    }
}
