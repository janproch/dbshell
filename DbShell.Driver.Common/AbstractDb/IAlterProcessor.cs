using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface IAlterProcessor
    {
        // view operations
        void CreateView(ViewInfo obj);
        void DropView(ViewInfo obj);
        void AlterView(ViewInfo obj);
        void ChangeViewSchema(ViewInfo obj, string newschema);
        void RenameView(ViewInfo obj, string newname);
        //void ChangeSpecificObject(ISpecificObjectStructure osrc, ISpecificObjectStructure odst);

        //// database operations
        //void AlterDatabaseOptions(string dbname, Dictionary<string, string> options);

        //// column operations
        //void CreateColumn(IColumnStructure column, IEnumerable<IConstraint> constraints);
        //void DropColumn(IColumnStructure column);
        //void RenameColumn(IColumnStructure column, string newcol);
        //void ChangeColumn(IColumnStructure oldcol, IColumnStructure newcol, IEnumerable<IConstraint> constraints);
        //void ReorderColumns(NameWithSchema table, List<string> newColumnOrder);

        //// constraint operations
        //void CreateConstraint(IConstraint constraint);
        //void DropConstraint(IConstraint constraint);
        //void RenameConstraint(IConstraint constraint, string newname);
        //void ChangeConstraint(IConstraint csrc, IConstraint cdst);

        //// generates physical recreate of table
        //void RecreateTable(ITableStructure src, ITableStructure dst);

        //// table operations
        ////void AlterTable(ITableStructure src, ITableStructure dst, out bool processed);
        //void CreateTable(ITableStructure tsrc);
        //void DropTable(ITableStructure tdst);
        //void ChangeTableSchema(NameWithSchema obj, string schema);
        //void RenameTable(NameWithSchema obj, string newname);
        //void AlterTableOptions(ITableStructure table, Dictionary<string, string> options);

        //// specific object operations
        //void CreateSpecificObject(ISpecificObjectStructure osrc);
        //void DropSpecificObject(ISpecificObjectStructure odst);
        //void ChangeSpecificObjectSchema(ISpecificObjectStructure obj, string newschema);
        //void RenameSpecificObject(ISpecificObjectStructure obj, string newname);
        //void ChangeSpecificObject(ISpecificObjectStructure osrc, ISpecificObjectStructure odst);

        //// schema operations
        //void DropSchema(ISchemaStructure schema);
        //void CreateSchema(ISchemaStructure schema);
        //void RenameSchema(ISchemaStructure schema, string newname);
        //void ChangeSchema(ISchemaStructure ssrc, ISchemaStructure sdst);

        //AlterProcessorCaps AlterCaps { get; }

        //// domain operations
        //void DropDomain(IDomainStructure domain);
        //void CreateDomain(IDomainStructure domain);
        //void ChangeDomain(IDomainStructure dsrc, IDomainStructure ddst);
        //void RenameDomain(NameWithSchema domain, string newname);
        //void ChangeDomainSchema(NameWithSchema domain, string newschema);

        //void UpdateData(ITableStructure table, DataScript script, ISaveDataProgress progress);
        //void UpdateData(MultiTableUpdateScript script, ISaveDataProgress progress);

        ///// <summary>
        ///// targeting database, is used when dumper needs more information about altered
        ///// objects
        ///// </summary>
        ////IDatabaseSource TargetDb { get; }

        //void CustomAction(string query);
    }
}
