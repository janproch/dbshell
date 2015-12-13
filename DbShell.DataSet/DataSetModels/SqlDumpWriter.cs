using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DbShell.DataSet.DataSetModels
{
    public class SqlDumpWriter
    {
        TextWriter m_baseStream;
        VariableRegistry m_variableRegistry;
        StringWriter m_currentCommand = new StringWriter();
        int m_length;
        public int MaxLength = 10000;
        public StringBuilder m_blockProlog = new StringBuilder();

        public SqlDumpWriter(TextWriter baseStream)
        {
            m_baseStream = baseStream;
            m_variableRegistry = new VariableRegistry();
        }

        public StringBuilder CurrentCommandBuilder
        {
            get
            {
                return m_currentCommand.GetStringBuilder();
            }
        }

        public void Write(string text)
        {
            m_currentCommand.Write(text);
        }

        public void Write(string format, params object[] args)
        {
            m_currentCommand.Write(format, args);
        }

        public void EndCommand()
        {
            string text = m_currentCommand.ToString();
            m_baseStream.Write(text);
            m_length += text.Length;
            m_currentCommand = new StringWriter();

            if (m_length > MaxLength)
            {
                m_baseStream.Write("\nGO\n");
                m_length = 0;
                m_variableRegistry.Clear();
                m_baseStream.Write(m_blockProlog.ToString());
            }
            else
            {
                m_baseStream.Write(";\n");
                m_length += 2;
            }
        }

        public void WriteVar(int variable)
        {
            m_variableRegistry.WriteVar(m_baseStream, m_currentCommand, variable);
        }

        public string GetVarExpr(int variable)
        {
            var sw = new StringWriter();
            m_variableRegistry.WriteVar(m_baseStream, sw, variable);
            return sw.ToString();
        }

        public void WriteBlockProlog(string text)
        {
            m_blockProlog.Append(text);
            m_baseStream.Write(text);
        }

        public void SuspendVariables()
        {
            m_variableRegistry.SuspendVariables();
        }

        public void ResumeVariables()
        {
            m_variableRegistry.ResumeVariables();
        }

        public void NotifyChangedVariable(int content)
        {
            m_variableRegistry.NotifyChangedVariable(content);
        }
    }
}
