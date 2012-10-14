namespace DbShell.Driver.Common.Structure
{
    public static class NameWithSchemaExtension
    {
        public static string SafeGetName(this NameWithSchema name)
        {
            if (name != null) return name.Name;
            return null;
        }

        public static string SafeGetSchema(this NameWithSchema name)
        {
            if (name != null) return name.Schema;
            return null;
        }
    }
}