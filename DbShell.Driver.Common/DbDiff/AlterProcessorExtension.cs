using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DbDiff
{
    public static class AlterProcessorExtension
    {
        public static void DropObject(this IAlterProcessor proc, DatabaseObjectInfo obj)
        {
            var tbl = obj as TableInfo;
            if (tbl != null)
            {
                proc.DropTable(tbl, true);
                return;
            }
            var col = obj as ColumnInfo;
            if (col != null)
            {
                proc.DropColumn(col);
                return;
            }
            var cnt = obj as ConstraintInfo;
            if (cnt != null)
            {
                proc.DropConstraint(cnt);
                return;
            }
            var spe = obj as SpecificObjectInfo;
            if (spe != null)
            {
                proc.DropSpecificObject(spe);
                return;
            }
            //var sch = obj as ISchemaStructure;
            //if (sch != null)
            //{
            //    proc.DropSchema(sch);
            //    return;
            //}
            //var dom = obj as IDomainStructure;
            //if (dom != null)
            //{
            //    proc.DropDomain(dom);
            //    return;
            //}
        }

        public static void DropConstraint(this IAlterProcessor proc, ConstraintInfo cnt)
        {
            var pk = cnt as PrimaryKeyInfo;
            if (pk != null) proc.DropPrimaryKey(pk);
            var fk = cnt as ForeignKeyInfo;
            if (fk != null) proc.DropForeignKey(fk);
        }

        public static void DropSpecificObject(this IAlterProcessor proc, SpecificObjectInfo obj)
        {
            var view = obj as ViewInfo;
            if (view != null) proc.DropView(view, true);
            var sp = obj as StoredProcedureInfo;
            if (sp != null) proc.DropStoredProcedure(sp, true);
            var func = obj as FunctionInfo;
            if (func != null) proc.DropFunction(func, true);
        }

        public static void CreateConstraint(this IAlterProcessor proc, ConstraintInfo cnt)
        {
            var pk = cnt as PrimaryKeyInfo;
            if (pk != null) proc.CreatePrimaryKey(pk);
            var fk = cnt as ForeignKeyInfo;
            if (fk != null) proc.CreateForeignKey(fk);
        }

        public static void CreateSpecificObject(this IAlterProcessor proc, SpecificObjectInfo obj)
        {
            var view = obj as ViewInfo;
            if (view != null) proc.CreateView(view);
            var sp = obj as StoredProcedureInfo;
            if (sp != null) proc.CreateStoredProcedure(sp);
            var func = obj as FunctionInfo;
            if (func != null) proc.CreateFunction(func);
        }


        public static void CreateColumn(this IAlterProcessor proc, ColumnInfo col)
        {
            proc.CreateColumn(col, null);
        }

        public static void ChangeColumn(this IAlterProcessor proc, ColumnInfo oldcol, ColumnInfo newcol)
        {
            proc.ChangeColumn(oldcol, newcol, null);
        }

        public static void CreateObject(this IAlterProcessor proc, DatabaseObjectInfo obj)
        {
            var tbl = obj as TableInfo;
            if (tbl != null)
            {
                proc.CreateTable(tbl);
                return;
            }
            var col = obj as ColumnInfo;
            if (col != null)
            {
                proc.CreateColumn(col);
                return;
            }
            var cnt = obj as ConstraintInfo;
            if (cnt != null)
            {
                proc.CreateConstraint(cnt);
                return;
            }
            var spe = obj as SpecificObjectInfo;
            if (spe != null)
            {
                proc.CreateSpecificObject(spe);
                return;
            }
            //var sch = obj as ISchemaStructure;
            //if (sch != null)
            //{
            //    proc.CreateSchema(sch);
            //    return;
            //}
            //var dom = obj as IDomainStructure;
            //if (dom != null)
            //{
            //    proc.CreateDomain(dom);
            //    return;
            //}
        }

        public static void ChangeSpecificObjectSchema(this IAlterProcessor proc, SpecificObjectInfo obj, string newSchema)
        {
            var view = obj as ViewInfo;
            if (view != null) proc.ChangeViewSchema(view, newSchema);
            var sp = obj as StoredProcedureInfo;
            if (sp != null) proc.ChangeStoredProcedureSchema(sp, newSchema);
            var func = obj as FunctionInfo;
            if (func != null) proc.ChangeFunctionSchema(func, newSchema);
        }

        public static void RenameSpecificObject(this IAlterProcessor proc, SpecificObjectInfo obj, string newName)
        {
            var view = obj as ViewInfo;
            if (view != null) proc.RenameView(view, newName);
            var sp = obj as StoredProcedureInfo;
            if (sp != null) proc.RenameStoredProcedure(sp, newName);
            var func = obj as FunctionInfo;
            if (func != null) proc.RenameFunction(func, newName);
        }


        //RenameSpecificObject

        public static void RenameObject(this IAlterProcessor proc, DatabaseObjectInfo obj, DbDiffOptions opts, NameWithSchema newName)
        {
            bool renameOk = false;
            //var dom = obj as IDomainStructure;
            //if (dom != null)
            //{
            //    renameOk = DbDiffTool.GenerateRename(dom.FullName, newName,
            //        (old, sch) => proc.ChangeDomainSchema(old, sch),
            //        (old, nam) => proc.RenameDomain(old, nam),
            //        proc.AlterCaps.ChangeTableSchema, proc.AlterCaps.RenameDomain, opts);
            //}
            var tbl = obj as TableInfo;
            if (tbl != null)
            {
                renameOk = DbDiffTool.GenerateRename(tbl.FullName, newName,
                                                     (old, sch) => proc.ChangeTableSchema(new TableInfo(null) {FullName = old}, sch),
                                                     (old, nam) => proc.RenameTable(new TableInfo(null) {FullName = old}, nam),
                                                     proc.AlterCaps.ChangeTableSchema, proc.AlterCaps.RenameTable, opts);
            }
            var col = obj as ColumnInfo;
            if (col != null)
            {
                if (proc.AlterCaps.RenameColumn)
                {
                    proc.RenameColumn(col, newName.Name);
                    renameOk = true;
                }
            }
            var cnt = obj as ConstraintInfo;
            if (cnt != null)
            {
                if (proc.AlterCaps.RenameConstraint)
                {
                    proc.RenameConstraint(cnt, newName.Name);
                    renameOk = true;
                }
            }
            var spec = obj as SpecificObjectInfo;
            if (spec != null)
            {
                renameOk = DbDiffTool.GenerateRenameSpecificObject(spec, newName,
                                                                   (old, sch) => proc.ChangeSpecificObjectSchema(old, sch),
                                                                   (old, nam) => proc.RenameSpecificObject(old, nam),
                                                                   proc.AlterCaps.GetSpecificObjectCaps(spec.ObjectType).ChangeSchema, proc.AlterCaps.GetSpecificObjectCaps(spec.ObjectType).Rename, opts);

            }
            if (!renameOk) throw new AlterNotPossibleError();
        }

        public static void ChangeObject(this IAlterProcessor proc, DatabaseObjectInfo obj, DatabaseObjectInfo newObj)
        {
            var tbl = obj as TableInfo;
            if (tbl != null)
            {
                throw new AlterNotPossibleError();
            }
            var col = obj as ColumnInfo;
            if (col != null)
            {
                proc.ChangeColumn(col, (ColumnInfo) newObj);
                return;
            }
            //var cnt = obj as ConstraintInfo;
            //if (cnt != null)
            //{
            //    proc.ChangeConstraint(cnt, (IConstraint) newObj);
            //    return;
            //}
            //var spe = obj as ISpecificObjectStructure;
            //if (spe != null)
            //{
            //    proc.ChangeSpecificObject(spe, (ISpecificObjectStructure) newObj);
            //    return;
            //}
            //var sch = obj as ISchemaStructure;
            //if (sch != null)
            //{
            //    proc.ChangeSchema(sch, (ISchemaStructure) newObj);
            //    return;
            //}
            //var dom = obj as IDomainStructure;
            //if (dom != null)
            //{
            //    proc.ChangeDomain(dom, (IDomainStructure) newObj);
            //    return;
            //}
        }

        public static void AlterDatabase(this IAlterProcessor proc, DatabaseInfo src, DatabaseInfo dst, DbDiffOptions opts)
        {
            proc.AlterDatabase(src, dst, opts, null);
        }

        public static void AlterDatabase(this IAlterProcessor proc, DatabaseInfo src, DatabaseInfo dst, DbDiffOptions opts, Action<AlterPlan> extendPlan)
        {
            AlterPlan plan = new AlterPlan();
            DbDiffTool.AlterDatabase(plan, src, dst, opts);
            if (extendPlan != null) extendPlan(plan);
            plan.Transform(proc.AlterCaps, opts);
            var run = plan.CreateRunner();
            run.Run(proc, opts);
        }

        public static void CreateConstraints(this IAlterProcessor proc, IEnumerable constraints)
        {
            if (constraints == null) return;
            foreach (ConstraintInfo cnt in constraints)
            {
                proc.CreateConstraint(cnt);
            }
        }
    }
}
