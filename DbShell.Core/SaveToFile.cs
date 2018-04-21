using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using System.ComponentModel;
using Microsoft.Extensions.Logging;

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
        [XamlProperty]
        public string File { get; set; }

        /// <summary>
        /// Gets or sets the value to be saved.
        /// </summary>
        /// <value>
        /// The value to be saved. Can contain replace expressions. If set, Expression cannot be set. Can be used only for textual data.
        /// When saving binary data, use Expression instead.
        /// </value>
        [XamlProperty]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the expression to be saved.
        /// </summary>
        /// <value>
        /// The expression to be saved. If set, Value cannot be set.
        /// </value>
        [XamlProperty]
        public string Expression { get; set; }


        /// <summary>
        /// Gets or sets the encoding.
        /// </summary>
        /// <value>
        /// The encoding.
        /// </value>
        [XamlProperty]
#if !NETSTANDARD2_0
        [TypeConverter(typeof(EncodingTypeConverter))]
#endif
        public Encoding Encoding { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Output);
            if (Expression != null && Value != null) throw new Exception("DBSH-00078 SaveToFile: both Expression and Value is set");
            if (Expression == null && Value == null) throw new Exception("DBSH-00079 SaveToFile: none of Expression and Value is set");
            if (Expression != null)
            {
                object obj = context.Evaluate(Expression);

                if (obj == null)
                {
                    context.GetLogger<SaveToFile>().LogWarning("DBSH-00000 Skipping SaveToFile, Expression {expression} evaluates to null", Expression);
                    return;
                }

                if (obj is byte[])
                {
                    var bytes = (byte[])obj;
                    using (var fw = System.IO.File.OpenWrite(file))
                    {
                        fw.Write(bytes, 0, bytes.Length);
                        context.GetLogger<SaveToFile>().LogInformation("Saved {bytes} bytes to file {file}", bytes.Length, Path.GetFullPath(file));
                    }
                }
                else
                {
                    using (var fw = new StreamWriter(System.IO.File.OpenWrite(file), Encoding))
                    {
                        string s = obj.ToString();
                        fw.Write(s);
                        context.GetLogger<SaveToFile>().LogInformation("Saved {length} characters to file {file}", s.Length, Path.GetFullPath(file));
                    }
                }
            }
            if (Value != null)
            {
                string val = context.Replace(Value);
                using (var fw = new StreamWriter(System.IO.File.OpenWrite(file), Encoding))
                {
                    fw.Write(val);
                    context.GetLogger<SaveToFile>().LogInformation("Saved {length} characters to file {file}", val.Length, Path.GetFullPath(file));
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
