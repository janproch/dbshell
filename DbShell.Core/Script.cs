using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Utility;
using log4net;

namespace DbShell.Core
{
    /// <summary>
    /// Job, which is aible to run SQL script, from file or given inline.
    /// </summary>
    public class Script : RunnableBase
    {
        private readonly static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets or sets the script file file.
        /// </summary>
        /// <value>
        /// The SQL file name. If this property is set, Command cannot be set.
        /// </value>
        public string File { get; set; }

        /// <summary>
        /// Gets or sets the SQL command.
        /// </summary>
        /// <value>
        /// The SQL command. If this property is set, File cannot be set.
        /// </value>
        public string Command { get; set; }


        /// <summary>
        /// Gets or sets the replace pattern.
        /// </summary>
        /// <value>
        /// The regular expression, which is used for replacing in scripts. By default, it is @"\$\{([^\}]+)\}"
        /// </value>
        public string ReplacePattern { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether use replacements.
        /// </summary>
        /// <value>
        ///   <c>true</c> if use replacements using ReplacePattern; otherwise, <c>false</c>. By default, true for inline Command, false for File
        /// </value>
        public bool? UseReplacements { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether use transaction.
        /// </summary>
        /// <value>
        ///   <c>true</c> if command executing is encosed in transaction; otherwise, <c>false</c>. Default is <c>false</c>
        /// </value>
        public bool UseTransactions { get; set; }

        private void RunScript(TextReader reader, DbConnection conn, DbTransaction tran, bool replace, bool logEachQuery, bool logCount)
        {
            int count = 0;
            foreach (string item in GoSplitter.GoSplit(reader))
            {
                string sql = item;
                if (replace)
                {
                    sql = Replace(sql, ReplacePattern);
                }
                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = tran;
                try
                {
                    if (logEachQuery) _log.InfoFormat("DBSH-00064 Executing SQL command {0}", sql);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    _log.ErrorFormat("DBSH-00065 Error {0} when executing script {1}", err.Message, sql);
                    throw;
                }
                count++;
            }
            if (logCount) _log.InfoFormat("DBSH-00073 Executed {0} commands", count);
        }

        protected override void DoRun()
        {
            if (File != null && Command != null) throw new Exception("DBSH-00060 Both Script.File and Script.Command properties are set");
            if (File == null && Command == null) throw new Exception("DBSH-00061 None of Script.File and Script.Command properties are set");

            using (var conn = Connection.Connect())
            {
                DbTransaction tran = null;
                try
                {
                    if (UseTransactions) tran = conn.BeginTransaction();

                    // execute inline command
                    if (Command != null)
                    {
                        RunScript(new StringReader(Command), conn, tran, UseReplacements == null || UseReplacements == true, true, false);
                    }

                    // execute linked file
                    if (File != null)
                    {
                        string fn = Context.ResolveFile(File, ResolveFileMode.Input);
                        using (var reader = new StreamReader(fn))
                        {
                            _log.InfoFormat("DBSH-00067 Executing SQL file {0}", fn);
                            RunScript(reader, conn, tran, UseReplacements == true, false, true);
                        }
                    }
                    if (tran != null)
                    {
                        tran.Commit();
                    }
                }
                finally
                {
                    if (tran != null) tran.Dispose();
                }
            }
        }
    }
}
