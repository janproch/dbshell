using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    public class ObjectOperationCaps
    {
        public bool Create = false;
        public bool Drop = false;
        public bool Rename = false;
        public bool ChangeSchema = false;
        public bool Change = false;

        public bool AllFlags
        {
            get { return false; }
            set
            {
                Create = value;
                Drop = value;
                Rename = value;
                ChangeSchema = value;
                Change = value;
            }
        }
    }

    /// <summary>
    /// behaviour of dependend operations
    /// of flag X_Y is true, changing of X requires recreate of all dependend Y
    /// </summary>
    public class AlterDependencyCaps
    {
        public bool ChangeColumn_Reference;
        public bool ChangeColumn_Constraint;
        public bool ChangeColumn_Index;

        public bool AllFlags
        {
            set
            {
                ChangeColumn_Constraint = value;
                ChangeColumn_Index = value;
                ChangeColumn_Reference = value;
            }
        }
    }

    public class AlterProcessorCaps
    {
        public bool RenameTable;
        public bool RecreateTable;
        public bool ChangeTableSchema;
        //public bool AlterTable; // if false, only recreating of table is possible
        public bool CreateTable;
        public bool DropTable;

        public bool AddConstraint;
        public bool DropConstraint;
        public bool RenameConstraint;
        public bool ChangeConstraint;

        public bool AddIndex;
        public bool DropIndex;
        public bool RenameIndex;
        public bool ChangeIndex;

        public bool AddColumn;
        public bool DropColumn;
        public bool ChangeColumn;
        public bool PermuteColumns;

        public bool ChangeColumnType;
        public bool RenameColumn;
        public bool ChangeColumnDefaultValue;
        public bool ChangeAutoIncrement;
        public bool ChangeComputedColumnExpression;

        public bool CreateSchema;
        public bool DropSchema;
        public bool RenameSchema;

        public bool CreateDomain;
        public bool ChangeDomain;
        public bool RenameDomain;
        public bool DropDomain;

        public bool ForceAbsorbPrimaryKey;

        //public bool FullFeatured; // has only InMemory table structure

        public AlterDependencyCaps DepCaps = new AlterDependencyCaps();

        //public ObjectOperationCaps SpecificCaps = new ObjectOperationCaps();
        //public Dictionary<string, ObjectOperationCaps> SpecificOverride = new Dictionary<string, ObjectOperationCaps>();

        //public ObjectOperationCaps this[string dbtype]
        //{
        //    get { return SpecificOverride.Get(dbtype, SpecificCaps); }
        //}

        public bool AlterTable
        {
            get
            {
                return AddColumn && AddConstraint && DropColumn && DropConstraint;
            }
        }

        public bool AllFlags
        {
            set
            {
                AddColumn = value;
                DropColumn = value;
                ChangeColumn = value;
                PermuteColumns = value;
                RenameTable = value;
                AddConstraint = value;
                DropConstraint = value;
                RenameConstraint = value;
                ChangeConstraint = value;
                AddIndex = value;
                DropIndex = value;
                RenameIndex = value;
                ChangeIndex = value;
                RecreateTable = value;
                ChangeColumnDefaultValue = value;
                ChangeAutoIncrement = value;
                ChangeComputedColumnExpression = value;
                ChangeColumnType = value;
                RenameColumn = value;
                ChangeTableSchema = value;
                //AlterTable = value;
                CreateSchema = value;
                DropSchema = value;
                RenameSchema = value;
                CreateTable = value;
                DropTable = value;
                CreateDomain = value;
                ChangeDomain = value;
                RenameDomain = value;
                DropDomain = value;
                ForceAbsorbPrimaryKey = value;
                //SpecificCaps.AllFlags = value;
                DepCaps.AllFlags = value;
            }
        }

        public ObjectOperationCaps GetSpecificObjectCaps(DatabaseObjectType objectType)
        {
            return new ObjectOperationCaps {AllFlags = true};
        }
    }

    public class SqlDumperCaps : AlterProcessorCaps
    {
        public bool CreateDatabase = false;
        public bool DropDatabase = false;
        public bool RenameDatabase = false;

        public new bool AllFlags
        {
            set
            {
                base.AllFlags = value;
                //SpecificCaps.AllFlags = value;
            }
        }
    }

    public class SqlDialectCaps
    {
        public SqlDialectCaps(bool initValue) { AllFlags = initValue; }
        public SqlDialectCaps() { }

        public bool MultiCommand;
        public bool NestedTransactions;

        public bool MultipleSchema;
        public bool MultipleDatabase;
        public bool Domains;

        // constraint support
        public bool ForeignKeys;
        public bool PrimaryKeys;
        public bool Uniques;
        public bool Indexes;
        public bool Checks;

        public bool AlterTable;
        // if true, must be used eg. ALTER TABLE xx DROP FOREIGN KEY FK_...
        // if false, generic version is used: ALTER TABLE xx DROP CONSTRAINT FK_...
        public bool ExplicitDropConstraint;

        // if true, primary key has not name (like MySQL)
        public bool AnonymousPrimaryKey;
        // if true, references are only parsed, not checked
        public bool UncheckedReferences;

        public bool UseDatabaseAsSchema;

        // multiple active result sets - if there can be more DataReaders simultanously
        public bool MARS;

        // supports selecting range from select
        public bool RangeSelect;
        // supports limiting select rows
        public bool LimitSelect;

        // supports array types
        public bool Arrays;

        public bool OptimizedComplexConditions;

        // supports auto-increment columns
        public bool AutoIncrement;

        public bool SupportBackup;

        public bool AllFlags
        {
            set
            {
                MultiCommand = value;
                NestedTransactions = value;
                MultipleSchema = value;
                ForeignKeys = value;
                PrimaryKeys = value;
                Uniques = value;
                Indexes = value;
                Checks = value;
                AlterTable = value;
                ExplicitDropConstraint = value;
                AnonymousPrimaryKey = value;
                Domains = value;
                UncheckedReferences = value;
                MARS = value;
                RangeSelect = value;
                LimitSelect = value;
                Arrays = value;
                OptimizedComplexConditions = value;
                MultipleDatabase = value;
                SupportBackup = value;
                AutoIncrement = value;
            }
        }
    }
}
