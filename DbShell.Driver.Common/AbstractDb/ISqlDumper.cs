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
    public enum SqlQualifierMode { Original, OmitDefaultSchema, OmitAll }
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

        //[XmlSubElem]
        //public SqlDumpWriterConfig DumpWriterConfig { get; set; }

        [XmlElem]
        //[SettingsKey("sql.format.command_case")]
        public CharacterCase SqlCommandCase { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.use_domains")]
        public bool UseDomains { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.indentation")]
        public int Indentation { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.omit_version_tests")]
        public bool OmitVersionTests { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.command_separator")]
        public string CommandSeparator { get; set; }
        //[XmlElem]
        //[SettingsKey("sql.format.header")]
        //public string DumpFileBegin { get; set; }
        //[XmlElem]
        //[SettingsKey("sql.format.footer")]
        //public string DumpFileEnd { get; set; }
        //[Browsable(false)]
        //public Dictionary<string, string> SpecificData { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.indentation_level")]
        public SqlIndentationLevel IndentationLevel { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.identifier_case")]
        public CharacterCase IdentifierCase { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.keyword_identifier_case")]
        public CharacterCase KeywordIdentifierCase { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.qualifier_mode")]
        public SqlQualifierMode QualifierMode { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.identifier_quote_mode")]
        public SqlIdentifierQuoteMode IdentifierQuoteMode { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.use_original_values")]
        public bool UseOriginalValues { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.cleanup_specific_object_code")]
        public bool CleanupSpecificObjectCode { get; set; }
        [XmlElem]
        //[SettingsKey("sql.format.binary_strings")]
        public bool BinaryStrings { get; set; }

        [XmlElem]
        //[SettingsKey("sql.format.binary_strings")]
        //[DatAdmin.DisplayName("s_encoding")]
        //[TypeConverter(typeof(EncodingTypeConverter))]
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
            KeywordIdentifierCase = CharacterCase.Original;
            IndentationLevel = SqlIndentationLevel.Large;
            Indentation = 4;
            OmitVersionTests = false;
            CommandSeparator = null; // use value from dialect
            //SpecificData = new Dictionary<string, string>();
            QualifierMode = SqlQualifierMode.Original;
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

    public enum DropFlags
    {
        None = 0,
        TestIfExist = 1,
        DropReferences = 2,
    }

    public interface ISqlDumper
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
    }
}
