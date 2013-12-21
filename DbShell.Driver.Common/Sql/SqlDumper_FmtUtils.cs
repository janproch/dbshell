using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Sql
{
    public class ValueTypeHolder
    {
        public readonly object Value;
        public readonly DbTypeBase DbType;

        public ValueTypeHolder(object value, DbTypeBase type)
        {
            Value = value;
            DbType = type;
        }
    }

    partial class SqlDumper
    {
        public void WriteRaw(string text) { m_stream.Write(text); }
        public void EndCommand() { m_stream.EndCommand(); }

        public void PutCmd(string format, params object[] args)
        {
            Put(format, args);
            EndCommand();
        }

        protected void WriteRawTest(string version, string text)
        {
            PutVersionTestBegin(version);
            WriteRaw(text);
            PutVersionTestEnd(version);
        }

        protected void PutCmdTest(string version, string format, params object[] args)
        {
            PutVersionTestBegin(version);
            Put(format, args);
            PutVersionTestEnd(version);
            EndCommand();
        }

        public virtual void PutVersionTestBegin(string version) { }
        public virtual void PutVersionTestEnd(string version) { }

        public void Put(string format, params object[] args)
        {
            WriteRaw(Format(Factory, FormatProperties, FormatterState, format, args));
        }

        public static string Format(IDatabaseFactory factory, string format, params object[] args)
        {
            return Format(factory, SqlFormatProperties.Default, null, format, args);
        }

        private static void DataDumped(SqlFormatterState state)
        {
            if (state != null) state.WasDataOnCurrentLine = true;
        }

        private static void DumpSeparatorIfNeeded(StringBuilder sb, SqlFormatProperties props, SqlFormatterState state)
        {
            if (state == null) return;
            if (state.LineFeedNeeded)
            {
                DumpEoln(sb, props, state);
                state.LineFeedNeeded = false;
                state.SeparatorNeeded = false;
                state.WasDataOnCurrentLine = false;
            }
            if (state.SeparatorNeeded && state.WasDataOnCurrentLine)
            {
                sb.Append(' ');
                state.SeparatorNeeded = false;
            }
        }

        private static void DumpEoln(StringBuilder sb, SqlFormatProperties props, SqlFormatterState state)
        {
            if (props.IndentationLevel != SqlIndentationLevel.SingleLine)
            {
                sb.Append("\n");
                if (state != null)
                {
                    for (int j = 0; j < state.IndentLevel * props.Indentation; j++) sb.Append(" ");
                }
            }
            else
            {
                sb.Append(" ");
            }
        }

        public static string GenerateSql(IDatabaseFactory factory, Action<ISqlDumper> func)
        {
            var sw = new StringWriter();
            var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());
            func(dmp);
            return sw.ToString();
        }

        public static string Format(IDatabaseFactory factory, SqlFormatProperties props, SqlFormatterState state, string format, params object[] args)
        {
            IDialectDataAdapter dda = null;
            if (state != null) dda = state.DDA;
            if (dda == null) dda = factory.CreateDataAdapter();
            var dialect = factory.CreateDialect();

            int argindex = 0;
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < format.Length)
            {
                char c = format[i];
                switch (c)
                {
                    case '^': // SQL keyword
                        {
                            i++;
                            DumpSeparatorIfNeeded(sb, props, state);
                            while (i < format.Length && (Char.IsLetter(format, i) || format[i] == '_'))
                            {
                                sb.Append(GetCasedChar(format[i], props.SqlCommandCase));
                                i++;
                            }
                            DataDumped(state);
                        }
                        break;
                    case '&': // indentation & spacing
                        {
                            i++;
                            c = format[i];
                            i++;
                            char level = '0';
                            if (c == '1' || c == '2' || c == '3' || c == '5')
                            {
                                level = c;
                                c = format[i];
                                i++;
                            }
                            if (level != '0')
                            {
                                // indentation levels
                                if (props.IndentationLevel == SqlIndentationLevel.Original || props.IndentationLevel == SqlIndentationLevel.SingleLine)
                                {
                                    if (c == 'n' || c == 's')
                                    {
                                        if (state != null)
                                        {
                                            state.SeparatorNeeded = true;
                                        }
                                        else
                                        {
                                            sb.Append(" ");
                                        }
                                    }
                                    // when original indentation is used, don't use our separators
                                    break;
                                }
                                bool valid = (props.IndentationLevel == SqlIndentationLevel.Compact && (level == '2' || level == '5'))
                                    || (props.IndentationLevel == SqlIndentationLevel.Large && (level == '3' || level == '5'));
                                if (!valid)
                                {
                                    break; // mark is not for this indentation level
                                }
                            }
                            switch (c)
                            {
                                case '&':
                                    sb.Append("&");
                                    break;
                                case 'n':
                                    if (state == null) DumpEoln(sb, props, state);
                                    else state.LineFeedNeeded = true;
                                    break;
                                case '>':
                                    if (state != null) state.IndentLevel++;
                                    break;
                                case '<':
                                    if (state != null) state.IndentLevel--;
                                    break;
                                case 's':
                                    if (state != null) state.SeparatorNeeded = true;
                                    else sb.Append(" ");
                                    break;
                                default:
                                    throw new InternalError("DBSH-00042 Unknown & formatting instruction:" + c);
                            }
                        }
                        break;
                    case '%': // format parameter
                        {
                            i++;
                            c = format[i];

                            if (c == '%')
                            {
                                sb.Append('%');
                                i++;
                            }
                            else if (c == ',' || c == ';') // comma separated list
                            {
                                i++;
                                bool lining = c == ';';
                                c = format[i];
                                bool ok = false;
                                if (args[argindex] is IEnumerable) ok = true;
                                if (args[argindex] is ICdlRecord && c == 'v') ok = true;
                                if (!ok) throw new InternalError("DBSH-00043 List must be of type Enumerable");

                                bool was = false;
                                if (args[argindex] is IEnumerable)
                                {
                                    if (lining)
                                    {
                                        state.IndentLevel++;
                                        DumpEoln(sb, props, state);
                                    }
                                    foreach (object item in (IEnumerable)args[argindex])
                                    {
                                        if (was)
                                        {
                                            if (lining)
                                            {
                                                DumpEoln(sb, props, state);
                                                sb.Append(",");
                                            }
                                            else
                                            {
                                                sb.Append(", ");
                                            }
                                        }
                                        WriteFormattedValue(dialect, props, sb, item, c, state, dda);
                                        was = true;
                                    }
                                    if (lining)
                                    {
                                        state.IndentLevel--;
                                    }
                                }
                                else
                                {
                                    var rec = (ICdlRecord)args[argindex];
                                    if (lining)
                                    {
                                        state.IndentLevel++;
                                        DumpEoln(sb, props, state);
                                    }
                                    for (int x = 0; x < rec.FieldCount; x++)
                                    {
                                        if (lining)
                                        {
                                            DumpEoln(sb, props, state);
                                            sb.Append(",");
                                        }
                                        else
                                        {
                                            sb.Append(", ");
                                        }
                                        rec.ReadValue(x);
                                        sb.Append(GetSqlLiteral(props, dda, state, rec));
                                        was = true;
                                    }
                                    if (lining)
                                    {
                                        state.IndentLevel--;
                                    }
                                }

                                argindex++;
                                i++;
                            }
                            else if (c == ':')
                            {
                                object orig = args[argindex];
                                argindex++;
                                i++;
                                c = format[i];
                                object arg = args[argindex];
                                argindex++;
                                i++;
                                WriteFormattedValue(dialect, props, sb, arg, c, state, dda);
                            }
                            else
                            {
                                WriteFormattedValue(dialect, props, sb, args[argindex], c, state, dda);
                                argindex++;
                                i++;
                            }
                        }
                        break;
                    default:
                        {
                            if (Char.IsWhiteSpace(c))
                            {
                                if (state != null) state.SeparatorNeeded = false;
                            }
                            else
                            {
                                DumpSeparatorIfNeeded(sb, props, state);
                            }
                            sb.Append(c);
                            i++;
                        }
                        break;
                }
            }
            return sb.ToString();
        }

        public string Format(string format, params object[] args)
        {
            return Format(Factory, FormatProperties, FormatterState, format, args);
        }

        private static void WriteFormattedValue(ISqlDialect dialect, SqlFormatProperties props, StringBuilder sb, object val, char fmt, SqlFormatterState state, IDialectDataAdapter dda)
        {
            switch (fmt)
            {
                case 'i': // quote identifier
                    DumpSeparatorIfNeeded(sb, props, state);
                    if (val is string)
                    {
                        sb.Append(QuoteIdentifier(dialect, props, (string)val));
                    }
                    else if (val is ColumnReference)
                    {
                        sb.Append(QuoteIdentifier(dialect, props, ((ColumnReference)val).RefColumn.Name));
                    }
                    else
                    {
                        throw new InternalError("DBSH-00044 Identifier must be of type string or IColumnReference");
                    }
                    DataDumped(state);
                    break;
                case 'f': // quote full name
                    DumpSeparatorIfNeeded(sb, props, state);
                    if (val is NameWithSchema) sb.Append(QuoteFullName(dialect, props, (NameWithSchema)val));
                    else if (val is IFullNamedObject) sb.Append(QuoteFullName(dialect, props, ((IFullNamedObject)val).FullName));
                    else throw new InternalError("DBSH-00045 Full name must be of type NameWithSchema or IFullNamedObject");
                    DataDumped(state);
                    break;
                case 's': // string - copy character data
                    if (val != null)
                    {
                        DumpSeparatorIfNeeded(sb, props, state);
                        sb.Append(val.ToString());
                        DataDumped(state);
                    }
                    break;
                case 'k': // keyword
                    DumpSeparatorIfNeeded(sb, props, state);
                    if (!(val is string)) throw new InternalError("DBSH-00046 Identifier must be of type string");
                    foreach (char c2 in (string)val) sb.Append(GetCasedChar(c2, props.SqlCommandCase));
                    DataDumped(state);
                    break;
                case 'K': // multi-word keyword
                    if (!(val is IEnumerable<string>)) throw new InternalError("DBSH-00047 Identifier must be of type string");
                    foreach (string s in ((IEnumerable<string>)val))
                    {
                        DumpSeparatorIfNeeded(sb, props, state);
                        sb.Append(GetCasedString(s, props.SqlCommandCase));
                        if (state != null) state.SeparatorNeeded = true;
                        else sb.Append(" ");
                        DataDumped(state);
                    }
                    break;
                case 'v': // value - copy character data
                    DumpSeparatorIfNeeded(sb, props, state);
                    var vth = val as ValueTypeHolder;
                    if (vth != null)
                    {
                        sb.Append(GetSqlLiteralAndRead(props, dda, state, vth.Value, vth.DbType));
                    }
                    else
                    {
                        sb.Append(GetSqlLiteralAndRead(props, dda, state, val));
                    }
                    DataDumped(state);
                    break;
                case 't': // version test
                    if (val != null && !props.OmitVersionTests) sb.Append(val.ToString());
                    break;
                default:
                    throw new InternalError("DBSH-00048 Unknown format character: " + fmt);
            }
        }

        public static string GetSqlLiteralAndRead(SqlFormatProperties props, IDialectDataAdapter dda, SqlFormatterState state, object val)
        {
            return GetSqlLiteralAndRead(props, dda, state, val, null);
        }

        public static string GetSqlLiteralAndRead(SqlFormatProperties props, IDialectDataAdapter dda, SqlFormatterState state, object val, DbTypeBase dsttype)
        {
            state._Holder.ReadFrom(val);
            return GetSqlLiteral(props, dda, state, state._Holder, dsttype);
        }

        public static string GetSqlLiteral(SqlFormatProperties props, IDialectDataAdapter dda, SqlFormatterState state, ICdlValueReader reader)
        {
            return GetSqlLiteral(props, dda, state, reader, null);
        }

        public static string GetSqlLiteral(SqlFormatProperties props, IDialectDataAdapter dda, SqlFormatterState state, ICdlValueReader reader, DbTypeBase dsttype)
        {
            if (props.BinaryStrings)
            {
                switch (reader.GetFieldType())
                {
                    case TypeStorage.String:
                        if (props.BinaryStrings)
                        {
                            return dda.GetSqlLiteral(props.RealBinaryEncoding.GetBytes(reader.GetString()), dsttype);
                        }
                        break;
                }
            }
            return dda.GetSqlLiteral(reader, dsttype);
        }

        public static bool MustBeQuoted(string s, ISqlDialect dialect)
        {
            foreach (char c in s)
            {
                bool ok = char.IsLetterOrDigit(c) || c == '_';
                if (!ok) return true;
            }
            if (dialect.Keywords.Contains(s.ToUpper())) return true;
            return false;
        }

        private static string QuoteIdentifier(ISqlDialect dialect, SqlFormatProperties props, string ident)
        {
            switch (props.IdentifierQuoteMode)
            {
                case SqlIdentifierQuoteMode.Plain:
                    if (MustBeQuoted(ident, dialect)) return dialect.QuoteIdentifier(GetCasedString(ident, props.IdentifierCase));
                    return GetCasedString(ident, props.IdentifierCase);

                //case SqlIdentifierQuoteMode.Quoted:
                default :
                    return dialect.QuoteIdentifier(GetCasedString(ident, props.IdentifierCase));
            }
            //throw new InternalError("DBSH-00049 Unexpected idquote mode");
        }

        protected string QuoteIdentifier(string ident)
        {
            return QuoteIdentifier(m_dialect, m_props, ident);
        }

        private static string QuoteFullName(ISqlDialect dialect, SqlFormatProperties props, NameWithSchema name)
        {
            if (!props.UseSchema || name.Schema == null)
            {
                return QuoteIdentifier(dialect, props, name.Name);
            }
            return QuoteIdentifier(dialect, props, name.Schema) + "." + QuoteIdentifier(dialect, props, name.Name);
        }

        protected string QuoteFullName(NameWithSchema name)
        {
            return QuoteFullName(m_dialect, m_props, name);
        }

        public static string GetCasedString(string s, CharacterCase cc)
        {
            if (s == null) return null;
            var sb = new StringBuilder();
            foreach (char c in s) sb.Append(GetCasedChar(c, cc));
            return sb.ToString();
        }
        public static string GetCasedString(string s, CharacterCase2 cc)
        {
            return GetCasedString(s, cc == CharacterCase2.Upper ? CharacterCase.Upper : CharacterCase.Lower);
        }
        public static char GetCasedChar(char c, CharacterCase2 cc)
        {
            return GetCasedChar(c, cc == CharacterCase2.Upper ? CharacterCase.Upper : CharacterCase.Lower);
        }
        public static char GetCasedChar(char c, CharacterCase cc)
        {
            switch (cc)
            {
                case CharacterCase.Lower: return Char.ToLower(c);
                case CharacterCase.Upper: return Char.ToUpper(c);
            }
            return c;
        }
    }
}
