using System;
using System.Collections.Generic;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class DataScript
    {
        public readonly List<InsertAction> Inserts = new List<InsertAction>();
        public readonly List<UpdateAction> Updates = new List<UpdateAction>();
        public readonly List<DeleteAction> Deletes = new List<DeleteAction>();

        public void Insert(string[] columns, object[] values)
        {
            Inserts.Add(new InsertAction { Columns = columns, Values = values });
        }

        public void Update(string[] condcols, object[] condvalues, string[] columns, object[] values)
        {
            Updates.Add(new UpdateAction
            {
                CondCols = condcols,
                CondValues = condvalues,
                Columns = columns,
                Values = values
            });
        }

        public void Delete(string[] condcols, object[] condvalues)
        {
            Deletes.Add(new DeleteAction { CondCols = condcols, CondValues = condvalues });
        }

        public abstract class ActionBase
        {
            public static string FormatColSet(string[] cols, object[] values)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < cols.Length; i++)
                {
                    if (i > 0) sb.Append(", ");
                    sb.AppendFormat("{0}={1}", cols[i], GenericDialectDataAdapter.Instance.GetSqlLiteral(values[i], new DbTypeString()));
                }
                return sb.ToString();
            }
        }

        public class InsertAction : ActionBase
        {
            public string[] Columns;
            public object[] Values;

            public override string ToString()
            {
                return String.Format("INSERT {0}", FormatColSet(Columns, Values));
            }
        }
        public class UpdateAction : ActionBase
        {
            public string[] Columns;
            public object[] Values;
            public string[] CondCols;
            public object[] CondValues;

            public override string ToString()
            {
                return String.Format("UPDATE {0} WHERE {1}", FormatColSet(Columns, Values), FormatColSet(CondCols, CondValues));
            }
        }
        public class DeleteAction : ActionBase
        {
            public string[] CondCols;
            public object[] CondValues;

            public override string ToString()
            {
                return String.Format("DELETE WHERE {0}", FormatColSet(CondCols, CondValues));
            }
        }

        public IEnumerable<ActionBase> EnumAllActions()
        {
            foreach (var act in Deletes) yield return act;
            foreach (var act in Updates) yield return act;
            foreach (var act in Inserts) yield return act;
        }
        public void AddAction(ActionBase action)
        {
            if (action is InsertAction) Inserts.Add((InsertAction)action);
            if (action is DeleteAction) Deletes.Add((DeleteAction)action);
            if (action is UpdateAction) Updates.Add((UpdateAction)action);
        }

        public bool IsEmpty()
        {
            return Inserts.Count == 0 && Deletes.Count == 0 && Updates.Count == 0;
        }

        //public void ReportCounts(ISaveDataProgress progress)
        //{
        //    progress.IncrementCount(SaveProgressMeasure.DeletedRows, Deletes.Count);
        //    progress.IncrementCount(SaveProgressMeasure.InsertedRows, Inserts.Count);
        //    progress.IncrementCount(SaveProgressMeasure.UpdatedRows, Updates.Count);
        //    foreach (var upd in Updates) progress.IncrementCount(SaveProgressMeasure.UpdatedFields, upd.Values.Length);
        //}
    }

    public class MultiTableUpdateScript
    {
        public class UpdateAction
        {
            public NameWithSchema Table;
            public string[] Columns;
            public object[] Values;
            public string[] CondCols;
            public object[] CondValues;

            public override string ToString()
            {
                return String.Format("UPDATE {0} {1} WHERE {2}", 
                    Table,
                    DataScript.ActionBase.FormatColSet(Columns, Values),
                    DataScript.ActionBase.FormatColSet(CondCols, CondValues));
            }
        }

        public readonly List<UpdateAction> Updates = new List<UpdateAction>();

        public void Update(NameWithSchema table, string[] condcols, object[] condvalues, string[] columns, object[] values)
        {
            Updates.Add(new UpdateAction
            {
                Table = table,
                CondCols = condcols,
                CondValues = condvalues,
                Columns = columns,
                Values = values
            });
        }

        //public void ReportCounts(ISaveDataProgress progress)
        //{
        //    progress.IncrementCount(SaveProgressMeasure.UpdatedRows, Updates.Count);
        //    foreach (var upd in Updates) progress.IncrementCount(SaveProgressMeasure.UpdatedFields, upd.Values.Length);
        //}
    }
}
