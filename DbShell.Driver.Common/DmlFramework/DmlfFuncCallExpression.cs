using System.Collections.Generic;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfFuncCallExpression : DmlfExpression
    {
        public List<DmlfExpression> Arguments = new List<DmlfExpression>();
        public string FuncName;

        public DmlfFuncCallExpression(string name, params DmlfExpression[] args)
        {
            FuncName = name;
            Arguments.AddRange(args);
        }

        public DmlfFuncCallExpression() { }
        public DmlfFuncCallExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int res = 0;
                foreach(var arg in Arguments)
                {
                    res += arg.GetHashCode();
                }
                return res;
            }
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfFuncCallExpression) obj;
            if (o.Arguments.Count != Arguments.Count) return false;
            for (int i = 0; i < Arguments.Count; i++) if (!Arguments[i].DmlfEquals(o.Arguments[i])) return false;
            if (FuncName != o.FuncName) return false;
            return true;
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("%k(", FuncName);
            bool was = false;
            foreach (var arg in Arguments)
            {
                if (was) dmp.Put(",");
                was = true;
                arg.GenSql(dmp, handler);
            }
            dmp.Put(")");
        }

        protected override string GetTypeName()
        {
            return "func";
        }

    }
}