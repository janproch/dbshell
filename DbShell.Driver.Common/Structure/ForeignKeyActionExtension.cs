using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
    public static class ForeignKeyActionExtension
    {
        public static string SqlName(this ForeignKeyAction action)
        {
            switch (action)
            {
                case ForeignKeyAction.Cascade: return "CASCADE";
                case ForeignKeyAction.Restrict: return "RESTRICT";
                case ForeignKeyAction.SetNull: return "SET NULL";
                case ForeignKeyAction.NoAction: return "NO ACTION";
                default: return null;
            }
        }
        public static string Identifier(this ForeignKeyAction action)
        {
            string res = action.SqlName();
            if (res == null) return null;
            return res.ToLower().Trim().Replace(" ", "");
        }
        public static ForeignKeyAction FromSqlName(string name)
        {
            if (name == null) return ForeignKeyAction.Undefined;
            switch (name.ToLower().Trim().Replace(" ", ""))
            {
                case "cascade": return ForeignKeyAction.Cascade;
                case "restrict": return ForeignKeyAction.Restrict;
                case "setnull": return ForeignKeyAction.SetNull;
                case "noaction": return ForeignKeyAction.NoAction;
            }
            return ForeignKeyAction.Undefined;
        }
    }
}
