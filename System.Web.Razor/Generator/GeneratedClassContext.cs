using System.Globalization;
using Microsoft.Internal.Web.Utils;

namespace System.Web.Razor.Generator {
    public struct GeneratedClassContext {
        public static readonly string DefaultWriteMethodName = "Write";
        public static readonly string DefaultWriteLiteralMethodName = "WriteLiteral";
        public static readonly string DefaultExecuteMethodName = "Execute";

        public static readonly GeneratedClassContext Default = new GeneratedClassContext(DefaultExecuteMethodName,
                                                                                         DefaultWriteMethodName,
                                                                                         DefaultWriteLiteralMethodName);

        public string WriteMethodName { get; set; }
        public string WriteLiteralMethodName { get; set; }
        public string WriteToMethodName { get; set; }
        public string WriteLiteralToMethodName { get; set; }
        public string ExecuteMethodName { get; set; }

        // Optional Items
        public bool AllowSections { get { return !String.IsNullOrEmpty(DefineSectionMethodName); } }
        public string DefineSectionMethodName { get; private set; }

        public bool AllowTemplates { get { return !String.IsNullOrEmpty(TemplateTypeName); } }
        public string TemplateTypeName { get; private set; }

        public GeneratedClassContext(string executeMethodName, string writeMethodName, string writeLiteralMethodName)
            : this() {
            if (String.IsNullOrEmpty(executeMethodName)) { throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Cannot_Be_Null_Or_Empty, "executeMethodName"), "executeMethodName"); }
            if (String.IsNullOrEmpty(writeMethodName)) { throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Cannot_Be_Null_Or_Empty, "writeMethodName"), "writeMethodName"); }
            if (String.IsNullOrEmpty(writeLiteralMethodName)) { throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Cannot_Be_Null_Or_Empty, "writeLiteralMethodName"), "writeLiteralMethodName"); }

            WriteMethodName = writeMethodName;
            WriteLiteralMethodName = writeLiteralMethodName;
            ExecuteMethodName = executeMethodName;

            WriteToMethodName = null;
            WriteLiteralToMethodName = null;
            TemplateTypeName = null;
            DefineSectionMethodName = null;
        }

        public GeneratedClassContext(string executeMethodName,
                                  string writeMethodName,
                                  string writeLiteralMethodName,
                                  string writeToMethodName,
                                  string writeLiteralToMethodName,
                                  string templateTypeName)
            : this(executeMethodName, writeMethodName, writeLiteralMethodName) {
            WriteToMethodName = writeToMethodName;
            WriteLiteralToMethodName = writeLiteralToMethodName;
            TemplateTypeName = templateTypeName;
        }

        public GeneratedClassContext(string executeMethodName,
                                  string writeMethodName,
                                  string writeLiteralMethodName,
                                  string writeToMethodName,
                                  string writeLiteralToMethodName,
                                  string templateTypeName,
                                  string defineSectionMethodName)
            : this(executeMethodName, writeMethodName, writeLiteralMethodName, writeToMethodName, writeLiteralToMethodName, templateTypeName) {

            DefineSectionMethodName = defineSectionMethodName;
        }

        public override bool Equals(object obj) {
            if (!(obj is GeneratedClassContext)) {
                return false;
            }
            GeneratedClassContext other = (GeneratedClassContext)obj;
            return String.Equals(DefineSectionMethodName, other.DefineSectionMethodName, StringComparison.Ordinal) &&
                   String.Equals(WriteMethodName, other.WriteMethodName, StringComparison.Ordinal) &&
                   String.Equals(WriteLiteralMethodName, other.WriteLiteralMethodName, StringComparison.Ordinal) &&
                   String.Equals(WriteToMethodName, other.WriteToMethodName, StringComparison.Ordinal) &&
                   String.Equals(WriteLiteralToMethodName, other.WriteLiteralToMethodName, StringComparison.Ordinal) &&
                   String.Equals(ExecuteMethodName, other.ExecuteMethodName, StringComparison.Ordinal) &&
                   String.Equals(TemplateTypeName, other.TemplateTypeName, StringComparison.Ordinal);
        }

        public static bool operator ==(GeneratedClassContext left, GeneratedClassContext right) {
            return left.Equals(right);
        }

        public static bool operator !=(GeneratedClassContext left, GeneratedClassContext right) {
            return !left.Equals(right);
        }

        public override int GetHashCode() {
            return DefineSectionMethodName.GetHashCode() ^
                   WriteMethodName.GetHashCode() ^
                   WriteLiteralMethodName.GetHashCode() ^
                   WriteToMethodName.GetHashCode() ^
                   WriteLiteralToMethodName.GetHashCode() ^
                   ExecuteMethodName.GetHashCode() ^
                   TemplateTypeName.GetHashCode();
        }
    }
}
