using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DbDiff;
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

        // function operations
        void CreateFunction(FunctionInfo obj);
        void DropFunction(FunctionInfo obj, bool testIfExists);
        void AlterFunction(FunctionInfo obj);
        void ChangeFunctionSchema(FunctionInfo obj, string newschema);
        void RenameFunction(FunctionInfo obj, string newname);

        // trigger operations
        void CreateTrigger(TriggerInfo obj);
        void DropTrigger(TriggerInfo obj, bool testIfExists);
        void AlterTrigger(TriggerInfo obj);
        void ChangeTriggerSchema(TriggerInfo obj, string newschema);
        void RenameTrigger(TriggerInfo obj, string newname);

        // table operations
        void CreateTable(TableInfo obj);
        void DropTable(TableInfo obj, bool testIfExists);
        void CreateTable(TableInfo obj, LinkedDatabaseInfo linkedInfo);
        void DropTable(TableInfo obj, bool testIfExists, LinkedDatabaseInfo linkedInfo);
        void ChangeTableSchema(TableInfo obj, string schema);
        void RenameTable(TableInfo obj, string newname);

        // key operations
        void DropForeignKey(ForeignKeyInfo fk);
        void CreateForeignKey(ForeignKeyInfo fk);

        void DropPrimaryKey(PrimaryKeyInfo pk);
        void CreatePrimaryKey(PrimaryKeyInfo pk);

        void DropIndex(IndexInfo ix);
        void CreateIndex(IndexInfo ix);

        void DropUnique(UniqueInfo uq);
        void CreateUnique(UniqueInfo uq);

        void DropCheck(CheckInfo ch);
        void CreateCheck(CheckInfo ch);

        void RenameConstraint(ConstraintInfo constraint, string newname);

        //// database operations
        //void AlterDatabaseOptions(string dbname, Dictionary<string, string> options);

        //// column operations
        void CreateColumn(ColumnInfo column, IEnumerable<ConstraintInfo> constraints);
        void DropColumn(ColumnInfo column);
        void RenameColumn(ColumnInfo column, string newcol);
        void ChangeColumn(ColumnInfo oldcol, ColumnInfo newcol, IEnumerable<ConstraintInfo> constraints);
        //void ReorderColumns(NameWithSchema table, List<string> newColumnOrder);

        // constraint operations
        //void CreateConstraint(IConstraint constraint);
        //void DropConstraint(IConstraint constraint);
        //void RenameConstraint(IConstraint constraint, string newname);
        //void ChangeConstraint(IConstraint csrc, IConstraint cdst);

        // generates physical recreate of table
        void RecreateTable(TableInfo src, TableInfo dst);

        //// table operations
        ////void AlterTable(TableInfo src, TableInfo dst, out bool processed);
        //void CreateTable(TableInfo tsrc);
        //void DropTable(TableInfo tdst);
        //void ChangeTableSchema(NameWithSchema obj, string schema);
        //void RenameTable(NameWithSchema obj, string newname);
        //void AlterTableOptions(TableInfo table, Dictionary<string, string> options);

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

        AlterProcessorCaps AlterCaps { get; }

        //// domain operations
        //void DropDomain(IDomainStructure domain);
        //void CreateDomain(IDomainStructure domain);
        //void ChangeDomain(IDomainStructure dsrc, IDomainStructure ddst);
        //void RenameDomain(NameWithSchema domain, string newname);
        //void ChangeDomainSchema(NameWithSchema domain, string newschema);

        //void UpdateData(TableInfo table, DataScript script, ISaveDataProgress progress);
        //void UpdateData(MultiTableUpdateScript script, ISaveDataProgress progress);

        ///// <summary>
        ///// targeting database, is used when dumper needs more information about altered
        ///// objects
        ///// </summary>
        ////IDatabaseSource TargetDb { get; }

        //void CustomAction(string query);
    }
}
