using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DbShell.LocalDb.LocalDbModels
{
    [SQLiteFunction(Name = "SqliteFunctionTransform", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class SqliteFunctionTransform : SQLiteFunction
    {
        private TransformData _dbsh;

        public SqliteFunctionTransform() { }

        public SqliteFunctionTransform(TransformData dbsh)
        {
            _dbsh = dbsh;
        }

        public override object Invoke(object[] args)
        {
            if (_dbsh == null) return args[0];
            if (args[0] == null) return null;

            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = _dbsh.Program;
                process.StartInfo.Arguments = _dbsh.Arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.Start();

                process.StandardInput.Write(args[0].SafeToString() ?? "");
                process.StandardInput.Close();

                string output = process.StandardOutput.ReadToEnd();
                return output;
            }
            catch (Exception err)
            {
                return args[0];
            }
        }
    }
}
