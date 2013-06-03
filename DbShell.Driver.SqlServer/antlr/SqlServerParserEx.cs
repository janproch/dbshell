using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

partial class SqlServerParser
{
    private string m_errors = null;

    public override void EmitErrorMessage(string msg)
    {
        base.EmitErrorMessage(msg);
        if (m_errors != null)
        {
            m_errors += "; " + msg;
        }
        else
        {
            m_errors = msg;
        }
    }

    public string Errors
    {
        get { return m_errors; }
    }

    private string UnquoteName(string name)
    {
        if (name == null) return null;
        if (name.StartsWith("[")) return name.Substring(1, name.Length - 2);
        return name;
    }

    private string StringValue(string value)
    {
        StringBuilder sb = new StringBuilder(value.Length - 2);
        char ch = value[0];
        for (int i = 1; i < value.Length - 1; i++)
        {
            if (ch == '\\')
            {
                i++;
                switch (value[i])
                {
                    case 'n':
                        sb.Append('\n');
                        break;
                    case 'r':
                        sb.Append('\r');
                        break;
                    case 't':
                        sb.Append('\t');
                        break;
                    case '0':
                        sb.Append('\0');
                        break;
                    default:
                        sb.Append(value[i]);
                        break;
                }
            }
            else
            {
                sb.Append(value[i]);
            }
        }
        return sb.ToString();
    }
}
    