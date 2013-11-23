using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DbDiff
{
    public static partial class DbDiffTool
    {
        public static void AlterDatabase(AlterPlan plan, DbObjectPairing pairing, DbDiffOptions opts)
        {
            var src = pairing.Source;
            var dst = pairing.Target;
            //var caps = proc.AlterCaps;

            //// domains
            //foreach (IDomainStructure dsrc in src.Domains)
            //{
            //    IDomainStructure ddst = pairing.FindPair(dsrc);
            //    if (ddst == null)
            //    {
            //        plan.DropDomain(dsrc);
            //    }
            //    else if (!DbDiffTool.EqualDomains(dsrc, ddst, opts, true))
            //    {
            //        if (DbDiffTool.EqualDomains(dsrc, ddst, opts, false))
            //        {
            //            plan.RenameDomain(dsrc, ddst.FullName);
            //        }
            //        else
            //        {
            //            plan.ChangeDomain(dsrc, ddst);
            //        }
            //    }
            //}

            //foreach (IDomainStructure ddst in dst.Domains)
            //{
            //    if (!pairing.IsPaired(ddst)) plan.CreateDomain(ddst);
            //}

            // drop tables
            foreach (TableInfo tsrc in new List<TableInfo>(src.Tables))
            {
                TableInfo tdst = pairing.FindPair(tsrc);
                if (tdst == null)
                {
                    plan.DropTable(tsrc);
                }
            }
            // change tables
            foreach (TableInfo tsrc in new List<TableInfo>(src.Tables))
            {
                TableInfo tdst = pairing.FindPair(tsrc);
                if (tdst == null) continue;
                if (!DbDiffTool.EqualTables(tsrc, tdst, opts, pairing))
                {
                    DbDiffTool.AlterTable(plan, tsrc, tdst, opts, pairing);
                }
                //else
                //{
                //    DbDiffTool.AlterFixedData(plan, tsrc, tdst, opts);
                //}
            }
            // create tables
            foreach (TableInfo tdst in dst.Tables)
            {
                if (!pairing.IsPaired(tdst))
                {
                    //var script = DbDiffTool.AlterFixedData(null, tdst.FixedData, null, opts);
                    plan.CreateTable(tdst);
                    //if (script != null) plan.UpdateData(tdst.FullName, script);
                }
            }

            // specific objects
            foreach (var osrc in src.GetAllSpecificObjects())
            {
                //var repr = SpecificRepresentationAddonType.Instance.FindRepresentation(osrc.ObjectType);
                //if (!repr.UseInSynchronization) continue;

                var odst = pairing.FindPair(osrc);
                if (odst == null)
                {
                    plan.DropSpecificObject(osrc);
                    //proc.DropSpecificObject(osrc);
                }
                else if (!DbDiffTool.EqualsSpecificObjects(osrc, odst, opts))
                {
                    DbDiffTool.AlterSpecificObject(osrc, odst, plan, opts, pairing);
                }
            }
            foreach (var odst in dst.GetAllSpecificObjects())
            {
                //var repr = SpecificRepresentationAddonType.Instance.FindRepresentation(odst.ObjectType);
                //if (!repr.UseInSynchronization) continue;

                if (!pairing.IsPaired(odst))
                {
                    plan.CreateSpecificObject(odst);
                    //proc.CreateSpecificObject(odst);
                }
            }

            //foreach (ISchemaStructure ssrc in src.Schemata)
            //{
            //    ISchemaStructure sdst = pairing.FindPair(ssrc);
            //    if (sdst == null)
            //    {
            //        plan.DropSchema(ssrc);
            //    }
            //    else if (ssrc.SchemaName != sdst.SchemaName)
            //    {
            //        plan.RenameSchema(ssrc, sdst.SchemaName);
            //        //if (caps.RenameSchema) proc.RenameSchema(ssrc, sdst.SchemaName);
            //        //else
            //        //{
            //        //    proc.DropSchema(ssrc);
            //        //    proc.CreateSchema(sdst);
            //        //}
            //    }
            //}

            //foreach (ISchemaStructure sdst in dst.Schemata)
            //{
            //    if (!pairing.IsPaired(sdst)) plan.CreateSchema(sdst);
            //}

            //var alteredOptions = GetDatabaseAlteredOptions(src, dst, opts);
            //if (alteredOptions.Count > 0) plan.ChangeDatabaseOptions(null, alteredOptions);

            //if (opts.SchemaMode == DbDiffSchemaMode.Ignore)
            //{
            //    plan.RunNameTransformation(new SetSchemaNameTransformation(null));
            //}
        }

        public static Dictionary<string, string> GetDatabaseAlteredOptions(DatabaseInfo oldDb, DatabaseInfo newDb, DbDiffOptions opts)
        {
            Dictionary<string, string> alteredOptions = new Dictionary<string, string>();
            if (opts.IgnoreAllDatabaseProperties) return alteredOptions;
            //foreach (string key in newDb.SpecificData.Keys)
            //{
            //    if (opts.IgnoreDatabaseProperties.Contains(key)) continue;
            //    if (oldDb.SpecificData.Get(key) != newDb.SpecificData[key])
            //        alteredOptions[key] = newDb.SpecificData[key];
            //}
            return alteredOptions;
        }

        public static NameWithSchema GenerateNewName(NameWithSchema oldName, NameWithSchema newName, DbDiffOptions opts)
        {
            //if (oldName == null)
            //{
            //    if (opts.SchemaMode != DbDiffSchemaMode.Strict) return new NameWithSchema(null, newName.Name);
            //    return newName;
            //}
            NameWithSchema res = oldName;
            if (!EqualSchemas(oldName.Schema, newName.Schema, opts)) res = new NameWithSchema(newName.Schema, res.Name);
            if (oldName.Name != newName.Name) res = new NameWithSchema(res.Schema, newName.Name);
            return res;
        }

        public static bool GenerateRename(NameWithSchema oldName, NameWithSchema newName, Action<NameWithSchema, string> changeSchema, Action<NameWithSchema, string> rename, bool allowChangeSchema, bool allowRename, DbDiffOptions opts)
        {
            newName = GenerateNewName(oldName, newName, opts);
            if (DbDiffTool.EqualFullNames(oldName, newName, opts)) return true;
            if (!EqualSchemas(oldName.Schema, newName.Schema, opts) && !allowChangeSchema) return false;
            if (oldName.Name != newName.Name && !allowRename) return false;
            if (!EqualSchemas(oldName.Schema, newName.Schema, opts)) changeSchema(oldName, newName.Schema);
            if (oldName.Name != newName.Name) rename(new NameWithSchema(newName.Schema, oldName.Name), newName.Name);
            return true;
        }

        public static bool GenerateRenameSpecificObject(SpecificObjectInfo oldObj, NameWithSchema newName, Action<SpecificObjectInfo, string> changeSchema, Action<SpecificObjectInfo, string> rename, bool allowChangeSchema, bool allowRename, DbDiffOptions opts)
        {
            newName = GenerateNewName(oldObj.FullName, newName, opts);
            if (DbDiffTool.EqualFullNames(oldObj.FullName, newName, opts)) return true;
            if (!EqualSchemas(oldObj.FullName.Schema, newName.Schema, opts) && !allowChangeSchema) return false;
            if (oldObj.FullName.Name != newName.Name && !allowRename) return false;
            if (!EqualSchemas(oldObj.FullName.Schema, newName.Schema, opts)) changeSchema(oldObj, newName.Schema);
            if (oldObj.FullName.Name != newName.Name)
            {
                var tmpo = oldObj.CloneSpecificObject();
                tmpo.FullName = new NameWithSchema(newName.Schema, oldObj.FullName.Name);
                rename(tmpo, newName.Name);
            }
            return true;
        }

        public static void AlterSpecificObject(SpecificObjectInfo osrc, SpecificObjectInfo odst, AlterPlan plan, DbDiffOptions opts, DbObjectPairing pairing)
        {
            //bool altered = false;
            if (osrc.CreateSql == odst.CreateSql)
            {
                plan.RenameSpecificObject(osrc, odst.FullName);
                //altered = GenerateRename(osrc.ObjectName, odst.ObjectName,
                //    (old, sch) =>
                //    {
                //        var o2 = new SpecificObjectStructure(osrc);
                //        o2.ObjectName = old;
                //        proc.ChangeSpecificObjectSchema(o2, sch);
                //    },
                //    (old, nam) =>
                //    {
                //        var o2 = new SpecificObjectStructure(osrc);
                //        o2.ObjectName = old;
                //        proc.RenameSpecificObject(o2, nam);
                //    }, caps[osrc.ObjectType].ChangeSchema, caps[osrc.ObjectType].Rename, opts);
            }
            else
            {
                plan.ChangeSpecificObject(osrc, odst);
            }
            //if (!altered)
            //{
            //    proc.DropSpecificObject(osrc);
            //    SpecificObjectStructure odst2 = new SpecificObjectStructure(odst);
            //    odst2.ObjectName = GenerateNewName(osrc.ObjectName, odst.ObjectName, opts);
            //    proc.CreateSpecificObject(odst);
            //}
        }

        public static void AlterDatabase(AlterPlan plan, DatabaseInfo src, DatabaseInfo dst, DbDiffOptions opts)
        {
            AlterDatabase(plan, new DbObjectPairing(src, dst), opts);
        }

        public static DbObjectPairing CreateTablePairing(TableInfo oldTable, TableInfo newTable)
        {
            var src = new DatabaseInfo();
            var dst = src.CloneDatabase();
            src.AddObject(oldTable, true);
            dst.AddObject(newTable, true);
            DbObjectPairing pairing = new DbObjectPairing(src, dst);
            return pairing;
        }

        ///// alters table, decomposes to alter actions; doesn't transform alter plan
        ///// proc must be able to run all logical operations
        //public static void DecomposeAlterTable(this IAlterProcessor proc, TableInfo oldTable, TableInfo newTable, DbDiffOptions options)
        //{
        //    DbObjectPairing pairing = CreateTablePairing(oldTable, newTable);
        //    // decompose to alter actions
        //    AlterPlan plan = new AlterPlan(oldTable);
        //    AlterTable(plan, oldTable, newTable, options, pairing);
        //    var run = plan.CreateRunner();
        //    run.Run(proc, options);
        //}

        //public static AlterPlan PlanAlterTable(TableInfo oldTable, TableInfo newTable, DbDiffOptions opts)
        //{
        //    AlterPlan plan = new AlterPlan(oldTable.OwnerDatabase);
        //    if (oldTable == null)
        //    {
        //        plan.CreateTable(newTable);
        //    }
        //    else
        //    {
        //        DbObjectPairing pairing = CreateTablePairing(oldTable, newTable);
        //        AlterTable(plan, oldTable, newTable, opts, pairing);
        //    }
        //    return plan;
        //}
    }
}
