using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DbShell.DataSet.DataSetModels
{
    public class VariableRegistry
    {
        class Register
        {
            internal int varname;
            internal int content;
            internal int age;
            // if suspended variable cannot be removed from registry until ResumeVariables is called
            internal bool suspended;
        }

        public int MaxVarCount = 100;
        bool _isSuspended;
        Dictionary<int, Register> _registryByContent = new Dictionary<int, Register>();

        public void WriteVar(TextWriter twBefore, TextWriter twUsage, int content)
        {
            int varname = -1;
            if (_registryByContent.ContainsKey(content))
            {
                // move to last position
                _registryByContent[content].age = 0;
                varname = _registryByContent[content].varname;
            }
            else
            {
                while (_registryByContent.Count >= MaxVarCount)
                {
                    int maxkey = -1;
                    Register maxreg = null;
                    foreach (var reg in _registryByContent.Values)
                    {
                        if (maxreg == null || (reg.age > maxreg.age && !reg.suspended))
                        {
                            maxreg = reg;
                            maxkey = reg.content;
                        }
                    }
                    if (maxreg == null)
                    {
                        break;
                    }
                    else
                    {
                        _registryByContent.Remove(maxkey);
                    }
                    varname = maxreg.varname;
                }
                if (varname < 0)
                {
                    varname = _registryByContent.Count + 1;
                    twBefore.Write("declare @var{0} int;\n", varname);
                }
                twBefore.Write("set @var{0}=(select value from #memory where id={1});\n", varname, content);
                _registryByContent[content] = new Register
                {
                    content = content,
                    varname = varname,
                };
                foreach (var reg in _registryByContent.Values)
                {
                    if (reg.varname != varname) reg.age++;
                }
            }
            twUsage.Write("@var{0}", varname);
            if (_isSuspended) _registryByContent[content].suspended = true;
        }

        public void Clear()
        {
            _registryByContent.Clear();
        }

        public void SuspendVariables()
        {
            _isSuspended = true;
        }

        public void ResumeVariables()
        {
            _isSuspended = false;
            foreach (var reg in _registryByContent.Values) reg.suspended = false;
        }
    }
}
