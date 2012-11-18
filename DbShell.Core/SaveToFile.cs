using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Writes string or binary data to file.
    /// </summary>
    public class SaveToFile : RunnableBase
    {
        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        /// <value>
        /// The file name.
        /// </value>
        public string File { get; set; }

        /// <summary>
        /// Gets or sets the value to be saved.
        /// </summary>
        /// <value>
        /// The value to be saved. Can contain replace expressions. If set, Expression cannot be set. Can be used only for textual data.
        /// When saving binary data, use Expression instead.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the expression to be saved.
        /// </summary>
        /// <value>
        /// The expression to be saved. If set, Value cannot be set.
        /// </value>
        public string Expression { get; set; }


        /// <summary>
        /// Gets or sets the encoding.
        /// </summary>
        /// <value>
        /// The encoding.
        /// </value>
        public Encoding Encoding { get; set; }

        protected override void DoRun()
        {
            string file = Context.ResolveFile(Context.Replace(File), ResolveFileMode.Output);
            if (Expression != null && Value != null) throw new Exception("DBSH-00078 SaveToFile: both Expression and Value is set");
            if (Expression == null && Value == null) throw new Exception("DBSH-00079 SaveToFile: none of Expression and Value is set");
            if (Expression != null)
            {
                object obj = Context.Evaluate(Expression);
                if (obj is byte[])
                {
                    var bytes = (byte[]) obj;
                    using (var fw = System.IO.File.OpenWrite(file))
                    {
                        fw.Write(bytes, 0, bytes.Length);
                    }
                }
                else
                {
                    using (var fw = new StreamWriter(file, false, Encoding))
                    {
                        fw.Write(obj.ToString());
                    }
                }
            }
            if (Value!=null)
            {
                string val = Context.Replace(Value);
                using (var fw = new StreamWriter(file, false, Encoding))
                {
                    fw.Write(val);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveToFile" /> class.
        /// </summary>
        public SaveToFile()
        {
            Encoding = Encoding.UTF8;
        }
    }
}
