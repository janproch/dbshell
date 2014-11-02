﻿using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfExpression : DmlfBase
    {
        public static DmlfExpression Load(XmlElement xml)
        {
            string type = xml.GetAttribute("type");
            switch (type)
            {
                case "col":
                    return new DmlfColumnRefExpression(xml);
                case "ident":
                    return new DmlfSqlIdentifierExpression(xml);
                case "placeholder":
                    return new DmlfPlaceholderExpression(xml);
                case "val":
                    return new DmlfSqlValueExpression(xml);
                case "str":
                    return new DmlfStringExpression(xml);
                case "lit":
                    return new DmlfLiteralExpression(xml);
                case "count":
                    return new DmlfCountExpression(xml);
                case "func":
                    return new DmlfFuncCallExpression(xml);
            }
            throw new InternalError("DBSH-00041 Unkown DMLF expression type:" + type);
        }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            xml.SetAttribute("type", GetTypeName());
        }

        public virtual object EvalExpression(IDmlfHandler handler)
        {
            throw new InternalError("DBSH-00000 Eval not implemented:" + GetType().FullName);
        }

        protected abstract string GetTypeName();
    }
}
