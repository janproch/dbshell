using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbShell.Core.DataSetModels
{
    public class SqlJoin
    {
        public string TargetTable;
        public string TableAlias;
        public string OnCondition;
        public DataSetReference Reference;
    }

    public class SqlRewriter
    {
        static Regex _exprRegex = new Regex(@"({[^}]+}\.)+\[[^\]]+\]");
        string _table;
        DataSetModel _model;

        public List<SqlJoin> Joins = new List<SqlJoin>();

        public SqlRewriter(string table, DataSetModel model)
        {
            _table = table;
            _model = model;
        }

        public string Rewrite(string expr)
        {
            return _exprRegex.Replace(expr, ProcessExprElem);
        }
        string ProcessExprElem(Match m)
        {
            var curtable = _model.GetClass(_table);
            string curalias = "tmain";
            string[] items = m.Value.Split('.');
            for (int i = 0; i < items.Length - 1; i++)
            {
                string col = items[i].Substring(1, items[i].Length - 2);
                bool found = false;
                foreach (var r in curtable.References)
                {
                    if (r.BindingColumn == col)
                    {
                        string alias = "j" + Joins.Count.ToString();
                        string oncond = String.Format("[{0}].[{1}]=[{2}].[{3}]",
                            curalias, col, alias, r.ReferencedClass.IdentityColumn);

                        Joins.Add(new SqlJoin
                        {
                            TableAlias = alias,
                            TargetTable = r.ReferencedClass.TableName,
                            Reference = r,
                            OnCondition = oncond,

                        });

                        curtable = r.ReferencedClass;
                        curalias = alias;

                        found = true;
                        break;
                    }
                }
                if (!found) throw new Exception(String.Format("Table {0} has not reference column {1}", curtable, col));
            }
            return curalias + "." + items[items.Length - 1];
        }

        public void WriteJoins(StringBuilder sb)
        {
            foreach (var join in Joins)
            {
                sb.AppendFormat(" inner join [{0}] {1} on {2} ", join.TargetTable, join.TableAlias, join.OnCondition);
            }
        }
    }
}
