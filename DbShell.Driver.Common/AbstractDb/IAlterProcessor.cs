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
        void DropView(ViewInfo obj, bool testIfExists);
        void AlterView(ViewInfo obj);
        void ChangeViewSchema(ViewInfo obj, string newschema);
        void RenameView(ViewInfo obj, string newname);

        // stored procedure operations
        void CreateStoredProcedure(StoredProcedureInfo obj);
        void DropStoredProcedure(StoredProcedureInfo obj, bool testIfExists);
        void AlterStoredProcedure(StoredProcedureInfo obj);
        void ChangeStoredProcedureSchema(StoredProcedureInfo obj, string newschema);
        void RenameStoredProcedure(StoredProcedureInfo obj, string newname);

        // stored function operations
        void CreateFunction(FunctionInfo obj);
        void DropFunction(FunctionInfo obj, bool testIfExists);
        void AlterFunction(FunctionInfo obj);
        void ChangeFunctionSchema(FunctionInfo obj, string newschema);
        void RenameFunction(FunctionInfo obj, string newname);

        // table operations
        void CreateTable(TableInfo obj);
        void DropTable(TableInfo obj, bool testIfExists);
        void ChangeTableSchema(TableInfo obj, string schema);
        void RenameTable(TableInfo obj, string newname);

        // key operations
        void DropForeignKey(ForeignKeyInfo fk);
        void CreateForeignKey(ForeignKeyInfo fk);
        void DropPrimaryKey(PrimaryKeyInfo fk);
        void CreatePrimaryKey(PrimaryKeyInfo fk);

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
