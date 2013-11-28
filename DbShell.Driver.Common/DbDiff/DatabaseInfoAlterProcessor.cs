using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DbDiff
{
    public class DatabaseInfoAlterProcessor : IAlterProcessor
    {
        private DatabaseInfo _database;
        public DatabaseInfoAlterProcessor (DatabaseInfo database)
        {
            _database = database;
        }

        public void CreateView(ViewInfo obj)
        {
            _database.Views.Add(obj.CloneView());
        }

        public void DropView(ViewInfo obj, bool testIfExists)
        {
            _database.Views.RemoveAll(v => v.FullName == obj.FullName);
        }

        public void AlterView(ViewInfo obj)
        {
            var oldObj = _database.FindView(obj);
            if (oldObj != null)
            {
                string gid = oldObj.GroupId;
                oldObj.Assign(obj);
                oldObj.GroupId = gid;
            }
        }

        public void ChangeViewSchema(ViewInfo obj, string newschema)
        {
            var oldObj = _database.FindView(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(newschema, oldObj.FullName.Name);
            }
        }

        public void RenameView(ViewInfo obj, string newname)
        {
            var oldObj = _database.FindView(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(oldObj.FullName.Schema, newname);
            }
        }


        public void CreateStoredProcedure(StoredProcedureInfo obj)
        {
            _database.StoredProcedures.Add(obj.CloneStoredProcedure());
        }

        public void DropStoredProcedure(StoredProcedureInfo obj, bool testIfExists)
        {
            _database.StoredProcedures.RemoveAll(v => v.FullName == obj.FullName);
        }

        public void AlterStoredProcedure(StoredProcedureInfo obj)
        {
            var oldObj = _database.FindStoredProcedure(obj);
            if (oldObj != null)
            {
                string gid = oldObj.GroupId;
                oldObj.Assign(obj);
                oldObj.GroupId = gid;
            }
        }

        public void ChangeStoredProcedureSchema(StoredProcedureInfo obj, string newschema)
        {
            var oldObj = _database.FindStoredProcedure(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(newschema, oldObj.FullName.Name);
            }
        }

        public void RenameStoredProcedure(StoredProcedureInfo obj, string newname)
        {
            var oldObj = _database.FindStoredProcedure(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(oldObj.FullName.Schema, newname);
            }
        }




        public void CreateFunction(FunctionInfo obj)
        {
            _database.Functions.Add(obj.CloneFunction());
        }

        public void DropFunction(FunctionInfo obj, bool testIfExists)
        {
            _database.Functions.RemoveAll(v => v.FullName == obj.FullName);
        }

        public void AlterFunction(FunctionInfo obj)
        {
            var oldObj = _database.FindFunction(obj);
            if (oldObj != null)
            {
                string gid = oldObj.GroupId;
                oldObj.Assign(obj);
                oldObj.GroupId = gid;
            }
        }

        public void ChangeFunctionSchema(FunctionInfo obj, string newschema)
        {
            var oldObj = _database.FindFunction(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(newschema, oldObj.FullName.Name);
            }
        }

        public void RenameFunction(FunctionInfo obj, string newname)
        {
            var oldObj = _database.FindFunction(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(oldObj.FullName.Schema, newname);
            }
        }

        public void CreateTable(TableInfo obj)
        {
            var tnew = obj.CloneTable(_database);
            _database.Tables.Add(tnew);
            tnew.AfterLoadLink();
        }

        public void DropTable(TableInfo obj, bool testIfExists)
        {
            _database.Tables.RemoveAll(v => v.FullName == obj.FullName);
            foreach (var t in _database.Tables)
            {
                t.DropReferencesTo(obj.FullName);
            }
        }

        public void ChangeTableSchema(TableInfo obj, string newschema)
        {
            var oldObj = _database.FindTable(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(newschema, oldObj.FullName.Name);
            }
        }

        public void RenameTable(TableInfo obj, string newname)
        {
            var oldObj = _database.FindTable(obj);
            if (oldObj != null)
            {
                oldObj.FullName = new NameWithSchema(oldObj.FullName.Schema, newname);
            }
        }

        public void DropForeignKey(ForeignKeyInfo fk)
        {
            _database.FindTable(fk.OwnerTable).DropConstraint(fk);
        }

        public void CreateForeignKey(ForeignKeyInfo fk)
        {
            _database.FindTable(fk.OwnerTable).AddConstraint(fk);
        }

        public void DropPrimaryKey(PrimaryKeyInfo pk)
        {
            _database.FindTable(pk.OwnerTable).DropConstraint(pk);
        }

        public void CreatePrimaryKey(PrimaryKeyInfo pk)
        {
            _database.FindTable(pk.OwnerTable).AddConstraint(pk);
        }

        public void DropIndex(IndexInfo ix)
        {
            _database.FindTable(ix.OwnerTable).DropConstraint(ix);
        }

        public void CreateIndex(IndexInfo ix)
        {
            _database.FindTable(ix.OwnerTable).AddConstraint(ix);
        }

        public void RenameConstraint(ConstraintInfo constraint, string newname)
        {
            _database.FindConstraint(constraint).ConstraintName = newname;
        }

        public void CreateColumn(ColumnInfo column, IEnumerable<ConstraintInfo> constraints)
        {
            _database.AddObject(column, false);
        }

        public void DropColumn(ColumnInfo column)
        {
            _database.FindTable(column.OwnerTable).DropColumn(column);
        }

        public void RenameColumn(ColumnInfo column, string newcol)
        {
            _database.FindColumn(column).Name = newcol;
        }

        public void ChangeColumn(ColumnInfo oldcol, ColumnInfo newcol, IEnumerable<ConstraintInfo> constraints)
        {
            var col = _database.FindColumn(oldcol);
            col.Assign(newcol);
            this.CreateConstraints(constraints);
        }

        public void RecreateTable(TableInfo src, TableInfo dst)
        {
            DbDiffTool.DecomposeAlterTable(this, src, dst, new DbDiffOptions());
        }

        //public void ChangeColumn(ColumnInfo oldcol, ColumnInfo newcol)
        //{
        //    throw new NotImplementedException();
        //}

        public AlterProcessorCaps AlterCaps
        {
            get
            {
                return new AlterProcessorCaps
                    {
                        AllFlags = true,
                    };
            }
        }
    }
}
