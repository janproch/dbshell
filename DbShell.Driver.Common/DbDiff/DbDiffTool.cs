using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    public static partial class DbDiffTool
    {
        public static bool EqualColumnNames(TableInfo a, TableInfo b)
        {
            return a.Columns.EqualSequence(b.Columns, (c1, c2) => c1.Name == c2.Name);
        }

        public static bool EqualsColumns(ColumnInfo a, ColumnInfo b, bool checkName)
        {
            return EqualsColumns(a, b, checkName, new DbDiffOptions(), null);
        }
        public static bool EqualDefaultValues(ColumnInfo a, ColumnInfo b)
        {
            if (a.DefaultValue == null)
            {
                if (a.DefaultValue != b.DefaultValue)
                {
                    return false;
                }
            }
            else
            {
                if (!a.DefaultValue.Equals(b.DefaultValue))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool EqualNames(string a, string b, DbDiffOptions opts)
        {
            return String.Compare(a, b, opts.IgnoreCase) == 0;
        }
        public static bool EqualsColumns(ColumnInfo a, ColumnInfo b, bool checkName, DbDiffOptions opts, DbObjectPairing pairing)
        {
            if (a.DefaultValue == null)
            {
                if (a.DefaultValue != b.DefaultValue)
                {
                    opts.DiffLogger.Trace("Column {0}, {1}: different default values: {2}; {3}", a, b, a.DefaultValue, b.DefaultValue);
                    return false;
                }
            }
            else
            {
                if (!a.DefaultValue.Equals(b.DefaultValue))
                {
                    opts.DiffLogger.Trace("Column {0}, {1}: different default values: {2}; {3}", a, b, a.DefaultValue, b.DefaultValue);
                    return false;
                }
            }
            if (checkName && !DbDiffTool.EqualNames(a.Name, b.Name, opts))
            {
                opts.DiffLogger.Trace("Column, different name: {0}; {1}", a, b);
                return false;
            }
            //if (!DbDiffTool.EqualFullNames(a.Domain, b.Domain, opts))
            //{
            //    opts.DiffLogger.Trace("Column {0}, {1}: different domain: {2}; {3}", a, b, a.Domain, b.Domain);
            //    return false;
            //}
            if (a.NotNull != b.NotNull)
            {
                opts.DiffLogger.Trace("Column {0}, {1}: different nullable: {2}; {3}", a, b, a.NotNull, b.NotNull);
                return false;
            }
            if (a.AutoIncrement != b.AutoIncrement)
            {
                opts.DiffLogger.Trace("Column {0}, {1}: different autoincrement: {2}; {3}", a, b, a.AutoIncrement, b.AutoIncrement);
                return false;
            }
            if (a.IsSparse != b.IsSparse)
            {
                opts.DiffLogger.Trace("Column {0}, {1}: different is_sparse: {2}; {3}", a, b, a.IsSparse, b.IsSparse);
                return false;
            }

            if (!EqualTypes(a, b, opts))
            {
                return false;
            }

            //var btype = b.DataType;
            //var atype = a.DataType;
            //if (pairing != null && pairing.Target != null && pairing.Source.Dialect != null)
            //{
            //    btype = pairing.Source.Dialect.MigrateDataType(b, btype, pairing.Source.Dialect.GetDefaultMigrationProfile(), null);
            //    btype = pairing.Source.Dialect.GenericTypeToSpecific(btype).ToGenericType();

            //    // normalize type
            //    atype = pairing.Source.Dialect.GenericTypeToSpecific(atype).ToGenericType();
            //}
            //if (!EqualTypes(atype, btype, opts))
            //{
            //    opts.DiffLogger.Trace("Column {0}, {1}: different types: {2}; {3}", a, b, a.DataType, b.DataType);
            //    return false;
            //}
            //if (!opts.IgnoreColumnCollation && a.Collation != b.Collation)
            //{
            //    opts.DiffLogger.Trace("Column {0}, {1}: different collations: {2}; {3}", a, b, a.Collation, b.Collation);
            //    return false;
            //}
            //if (!opts.IgnoreColumnCharacterSet && a.CharacterSet != b.CharacterSet)
            //{
            //    opts.DiffLogger.Trace("Column {0}, {1}: different character sets: {2}; {3}", a, b, a.CharacterSet, b.CharacterSet);
            //    return false;
            //}
            return true;
        }

        public static bool EqualTypes(ColumnInfo a, ColumnInfo b, DbDiffOptions opts)
        {
            if (a.DataType != b.DataType)
            {
                opts.DiffLogger.Trace("Column {0}, {1}: different types: {2}; {3}", a, b, a.DataType, b.DataType);
                return false;
            }

            if (a.Length != b.Length)
            {
                opts.DiffLogger.Trace("Column {0}, {1}: different lengths: {2}; {3}", a, b, a.Length, b.Length);
                return false;
            }

            if (a.Precision != b.Precision)
            {
                opts.DiffLogger.Trace("Column {0}, {1}: different lengths: {2}; {3}", a, b, a.Precision, b.Precision);
                return false;
            }

            if (a.Scale != b.Scale)
            {
                opts.DiffLogger.Trace("Column {0}, {1}: different scale: {2}; {3}", a, b, a.Scale, b.Scale);
                return false;
            }

            return true;
        }

        //public static bool EqualTypes(DbTypeBase t1, DbTypeBase t2, DbDiffOptions opts)
        //{
        //    if (!opts.IgnoreSpecificData && !t1.SpecificData.EqualsDictionary(t2.SpecificData, opts.IgnoreDataTypeProperties))
        //    {
        //        opts.DiffLogger.Trace("Types {0}, {1}: different specific data: {2}; {3}", t1, t2, t1.SpecificData.Format(), t2.SpecificData.Format());
        //        return false;
        //    }
        //    if (t1.Code != t2.Code)
        //    {
        //        opts.DiffLogger.Trace("Types {0}, {1}: different type code: {2}; {3}", t1, t2, t1.Code, t2.Code);
        //        return false;
        //    }
        //    if (!XmlTool.PropertiesEquals(t1, t2, opts.DiffLogger)) return false;
        //    return true;
        //}

        public static bool EqualTables(TableInfo tsrc, TableInfo tdst, DbDiffOptions options, DbObjectPairing pairing)
        {
            return EqualTables(tsrc, tdst, options, pairing, true);
        }

        public static bool EqualTables(TableInfo tsrc, TableInfo tdst, DbDiffOptions options, DbObjectPairing pairing, bool testNames)
        {
            if (options.IgnoreColumnOrder)
            {
                if (tsrc.Columns.Count != tdst.Columns.Count) return false;
                foreach (var scol in tsrc.Columns)
                {
                    var dcol = (from c in tdst.Columns where c.GroupId == scol.GroupId select c).FirstOrDefault();
                    if (dcol == null) return false;
                    using (var ctx = new DbDiffChangeLoggerContext(options, NopMessageLogger.Instance, DbDiffOptsLogger.DiffLogger))
                    {
                        if (!EqualsColumns(scol, dcol, true, options, pairing)) return false;
                    }
                }
            }
            else
            {
                using (var ctx = new DbDiffChangeLoggerContext(options, NopMessageLogger.Instance, DbDiffOptsLogger.DiffLogger))
                {
                    if (!tsrc.Columns.EqualSequence(tdst.Columns, (c1, c2) => EqualsColumns(c1, c2, true, options, pairing))) return false;
                }
            }

            var csrc = new List<ConstraintInfo>(tsrc.Constraints);
            var cdst = new List<ConstraintInfo>(tdst.Constraints);
            csrc.Sort(CompareConstraints);
            cdst.Sort(CompareConstraints);

            if (!csrc.EqualSequence(cdst, (c1, c2) => EqualsConstraints(c1, c2, options, true, pairing))) return false;

            if (testNames && !EqualFullNames(tsrc.FullName, tdst.FullName, options)) return false;
            if (GetTableAlteredOptions(tsrc, tdst, options).Count > 0) return false;
            return true;
        }

        private static int CompareConstraints(ConstraintInfo lft, ConstraintInfo rgt)
        {
            var nl = lft.ConstraintName;
            var nr = rgt.ConstraintName;
            if (lft.GetType() != rgt.GetType()) return String.Compare(lft.GetType().FullName, rgt.GetType().FullName);
            if (nl != null && nr != null) return String.Compare(nl, nr);
            return 0;
        }

        public static bool EqualSchemas(string lschema, string rschema, DbDiffOptions options)
        {
            if (options.SchemaMode == DbDiffSchemaMode.Ignore) lschema = null;
            if (options.SchemaMode == DbDiffSchemaMode.IngoreImplicit && lschema == options.LeftImplicitSchema) lschema = null;
            if (options.SchemaMode == DbDiffSchemaMode.Ignore) rschema = null;
            if (options.SchemaMode == DbDiffSchemaMode.IngoreImplicit && rschema == options.RightImplicitSchema) rschema = null;
            return EqualNames(lschema, rschema, options);
        }

        public static bool EqualFullNames(NameWithSchema lft, NameWithSchema rgt, DbDiffOptions options)
        {
            if (lft == null || rgt == null) return lft == rgt;
            return EqualSchemas(lft.Schema, rgt.Schema, options) && EqualNames(lft.Name, rgt.Name, options);
        }

        public static bool EqualsColumnRefs(TableInfo tsrc, TableInfo tdst, List<ColumnReference> srcRefs, List<ColumnReference> dstRefs)
        {
            if (srcRefs.Count != dstRefs.Count) return false;
            if (tsrc == null || tdst == null)
            {
                if (srcRefs.Count != dstRefs.Count) return false;
                for (int i = 0; i < srcRefs.Count; i++)
                {
                    if (srcRefs[i].RefColumnName != dstRefs[i].RefColumnName) return false;
                }
                return true;
            }
            for (int i = 0; i < srcRefs.Count; i++)
            {
                var scol = tsrc.Columns.FirstOrDefault(c => c.Name == srcRefs[i].RefColumnName);
                var dcol = tdst.Columns.FirstOrDefault(c => c.Name == dstRefs[i].RefColumnName);
                if (scol == null || dcol == null)
                {
                    if (srcRefs[i].RefColumnName != dstRefs[i].RefColumnName) return false;
                }
                else
                {
                    if (scol.GroupId != dcol.GroupId) return false;
                }
            }
            return true;
        }

        public static bool EqualsConstraints(ConstraintInfo csrc, ConstraintInfo cdst, DbDiffOptions options, bool checkNames, DbObjectPairing pairing)
        {
            if (checkNames && !options.IgnoreConstraintNames)
            {
                if (!EqualNames(csrc.ConstraintName, cdst.ConstraintName, options))
                {
                    return false;
                    //if (csrc is PrimaryKeyInfo && cdst is PrimaryKeyInfo) // && (pairing.Source.Dialect.DialectCaps.AnonymousPrimaryKey || pairing.Target.Dialect.DialectCaps.AnonymousPrimaryKey))
                    //{
                    //    // do nothing
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
            }
            if (csrc.GetType() != cdst.GetType()) return false;
            if (csrc is ColumnsConstraintInfo)
            {
                TableInfo tsrc = pairing.Source.FindTable(csrc.OwnerTable.FullName);
                TableInfo tdst = pairing.Target.FindTable(cdst.OwnerTable.FullName);
                if (!EqualsColumnRefs(tsrc, tdst, ((ColumnsConstraintInfo)csrc).Columns, ((ColumnsConstraintInfo)cdst).Columns)) return false;
                //if (!((ColumnsConstraint)csrc).Columns.EqualSequence(((ColumnsConstraint)cdst).Columns)) return false;
                if (csrc is ForeignKeyInfo)
                {
                    var fsrc = (ForeignKeyInfo)csrc;
                    var fdst = (ForeignKeyInfo)cdst;
                    if (!EqualFullNames(fsrc.RefTableFullName, fdst.RefTableFullName, options)) return false;
                    TableInfo psrc = pairing.Source.FindTable(fsrc.RefTableFullName);
                    TableInfo pdst = pairing.Target.FindTable(fdst.RefTableFullName);
                    if (!EqualsColumnRefs(psrc, pdst, fsrc.RefColumns, fdst.RefColumns)) return false;
                    if (fsrc.OnDeleteAction != fdst.OnDeleteAction) return false;
                    if (fsrc.OnUpdateAction != fdst.OnUpdateAction) return false;
                }
                //if (csrc is IIndex)
                //{
                //    var isrc = (IndexConstraint)csrc;
                //    var idst = (IndexConstraint)cdst;
                //    if (isrc.IsUnique != idst.IsUnique) return false;
                //}
            }
            //if (csrc is CheckConstraint)
            //{
            //    if (((CheckConstraint)csrc).Expression != ((CheckConstraint)cdst).Expression) return false;
            //}
            return true;
        }

        public static bool EqualsSpecificObjects(SpecificObjectInfo src, SpecificObjectInfo dst, DbDiffOptions options)
        {
            if (!EqualFullNames(src.FullName, dst.FullName, options)) return false;
            if (src.ObjectType != dst.ObjectType) return false;
            if (src.CreateSql == null || dst.CreateSql == null)
            {
                if (src.CreateSql != dst.CreateSql) return false;
            }
            else
            {
                //if (src.SpecificDialect == dst.SpecificDialect && src.SpecificDialect != null)
                //{
                //    var dialect = (ISqlDialect)DialectAddonType.Instance.FindHolder(src.SpecificDialect).CreateInstance();
                //    return dialect.EqualSpecificObjects(src.ObjectType, src.CreateSql, dst.CreateSql);
                //}
                //else
                //{
                //    if (src.CreateSql.Trim() != dst.CreateSql.Trim()) return false;
                //}
                if (src.CreateSql.Trim() != dst.CreateSql.Trim()) return false;
            }
            return true;
        }

        //public static bool EqualDomains(IDomainStructure src, IDomainStructure dst, DbDiffOptions opts, bool testName)
        //{
        //    if (testName && !DbDiffTool.EqualFullNames(src.FullName, dst.FullName, opts))
        //    {
        //        opts.DiffLogger.Trace("Domain: different names {0}; {1}", src.FullName, dst.FullName);
        //        return false;
        //    }
        //    if (!EqualTypes(src.DataType, dst.DataType, opts))
        //    {
        //        opts.DiffLogger.Trace("Domain {0}, {1}: different types {2}; {3}", src.FullName, dst.FullName, src.DataType, dst.DataType);
        //        return false;
        //    }
        //    if (src.IsNullable != dst.IsNullable)
        //    {
        //        opts.DiffLogger.Trace("Domain {0}, {1}: different nullable {2}; {3}", src.FullName, dst.FullName, src.IsNullable, dst.IsNullable);
        //        return false;
        //    }
        //    return true;
        //}
    }
}
