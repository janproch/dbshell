using System.Text;
using System.Xml;
using System.ComponentModel;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface ISqlOutputStream
    {
        void Write(string text);
        void EndCommand();
        void OverrideCommandDelimiter(string delimiter);
    }

    public enum CharacterCase { Original, Lower, Upper };
    public enum SqlIndentationLevel { Original, SingleLine, Compact, Large }
    public enum SqlIdentifierQuoteMode { Original, Plain, Quoted }
    public enum CharacterCase2
    {
        [Description("Lower case")]
        Lower,
        [Description("Upper case")]
        Upper
    }

    public class SqlFormatProperties
    {
        public static readonly SqlFormatProperties Default = new SqlFormatProperties();

        public CharacterCase SqlCommandCase { get; set; }
        public bool UseDomains { get; set; }
        public int Indentation { get; set; }
        public bool OmitVersionTests { get; set; }
        public string CommandSeparator { get; set; }
        public SqlIndentationLevel IndentationLevel { get; set; }
        public CharacterCase IdentifierCase { get; set; }
        public bool UseSchema { get; set; }
        public SqlIdentifierQuoteMode IdentifierQuoteMode { get; set; }
        public bool UseOriginalValues { get; set; }
        public bool CleanupSpecificObjectCode { get; set; }
        public bool BinaryStrings { get; set; }

        public string BinaryEncoding
        {
            get { return m_binaryEncoding.WebName; }
            set { m_binaryEncoding = System.Text.Encoding.GetEncoding(value); }
        }
        Encoding m_binaryEncoding = Encoding.UTF8;
        public Encoding RealBinaryEncoding
        {
            get { return m_binaryEncoding; }
            set { m_binaryEncoding = value; }
        }

        public SqlFormatProperties()
        {
            SqlCommandCase = CharacterCase.Upper;
            IdentifierCase = CharacterCase.Original;
            IndentationLevel = SqlIndentationLevel.Large;
            Indentation = 4;
            OmitVersionTests = false;
            CommandSeparator = null; // use value from dialect
            UseSchema = true;
            IdentifierQuoteMode = SqlIdentifierQuoteMode.Original;
            UseDomains = true;
            UseOriginalValues = true;
            CleanupSpecificObjectCode = true;
            BinaryStrings = false;
        }

        public void SaveToXml(XmlElement xml)
        {
            this.SaveProperties(xml);
        }

        public void LoadFromXml(XmlElement xml)
        {
            this.LoadProperties(xml);
        }

        public static SqlFormatProperties CreateOriginal()
        {
            var res = new SqlFormatProperties();
            res.IndentationLevel = SqlIndentationLevel.Original;
            res.SqlCommandCase = CharacterCase.Original;
            res.CleanupSpecificObjectCode = false;
            return res;
        }
    }

    public class SqlFormatterState
    {
        public int IndentLevel = 0;
        // flag is true when before % or ^ mark separator must be use
        public bool SeparatorNeeded = false;
        // if true, new line must be pushed before next data
        public bool LineFeedNeeded = false;
        // whether current line allready contains any data
        public bool WasDataOnCurrentLine = false;
        // DDA which can be used (can be null)
        public IDialectDataAdapter DDA;
        // value holder for internal usage
        public CdlValueHolder _Holder = new CdlValueHolder();
    }

    //public enum AlterTableMode { Conservative, RecreateWhenNeeded, RecreateAllways }

    public class CreateDatabaseObjectsProps
    {
        //public bool IncludeDropStatement = false;
        public bool CreateTables = true;
        public bool CreateFixedData = true;
        //public bool CreateReferences = true;
        public bool CreateSpecificObjects = true;
        public bool CreateSchemata = true;
        public bool CreateDomains = true;

        public bool AllFlags
        {
            get { return false; }
            set
            {
                //IncludeDropStatement = value;
                CreateTables = value;
                CreateFixedData =  value;
                CreateSpecificObjects =  value;
                CreateSchemata =  value;
                CreateDomains = value;
            }
        }
    }

    public interface ISqlDumper : IAlterProcessor
    {
        /// <summary>
        /// returns underlying SQL stream
        /// </summary>
        ISqlOutputStream Stream { get; }
        /// <summary>
        /// returns format properties used by this formatter
        /// modifiying of this structure can have unexpected results
        /// </summary>
        SqlFormatProperties FormatProperties { get; }
        /// <summary>
        /// underlying dialect
        /// </summary>
        ISqlDialect Dialect { get; }
        /// <summary>
        /// returns underlying formatter state
        /// </summary>
        SqlFormatterState FormatterState { get; }
        /// <summary>
        /// underlying dialect
        /// </summary>
        IDatabaseFactory Factory { get; }

        void AllowIdentityInsert(NameWithSchema table, bool allow);

        void EnableConstraints(NameWithSchema table, bool enabled);

        // table operations
        void TruncateTable(NameWithSchema name);

        void UpdateData(TableInfo table, SingleTableDataScript script);
        void UpdateData(MultiTableUpdateScript script);

        void Put(string format, params object[] args);
        void PutCmd(string format, params object[] args);
        void WriteRaw(string data);
        void EndCommand();

        string Format(string format, params object[] args);
    }
}
