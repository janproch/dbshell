using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using SocialExplorer.IO.FastDBF;

namespace DbShell.Dbf
{
    /// <summary>
    /// DBF(dBase or FoxPro) data file
    /// </summary>
    public class DbfFile : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        /// <summary>
        /// File name (should have .dbf extension)
        /// </summary>
        [XamlProperty]
        public string Name { get; set; }



        public bool AllowFoxProInteger { get; set; }

        public int DefaultStringLength { get; set; }

        public int DefaultNumericScale { get; set; }

        protected Encoding _encoding = System.Text.Encoding.UTF8;

        /// <summary>
        /// Gets or sets the file encoding.
        /// </summary>
        /// <value>
        /// The encoding, by default UTF-8
        /// </value>
        [XamlProperty]
        [TypeConverter(typeof(EncodingTypeConverter))]
        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }


        public DbfFile()
        {
            DefaultStringLength = 50;
            DefaultNumericScale = 5;
        }

        private SocialExplorer.IO.FastDBF.DbfFile OpenDbfRead(IShellContext context)
        {
            var dbf = new SocialExplorer.IO.FastDBF.DbfFile(Encoding);
            var name = context.ResolveFile(context.Replace(Name), ResolveFileMode.Input);
            dbf.Open(name, System.IO.FileMode.Open);
            return dbf;
        }

        TableInfo GetStructure(SocialExplorer.IO.FastDBF.DbfFile dbf)
        {
            var res = new TableInfo(null);
            //output column names
            for (int i = 0; i < dbf.Header.ColumnCount; i++)
            {
                DbTypeBase type;
                // convert DBF type to DA type
                switch (dbf.Header[i].ColumnType)
                {
                    case DbfColumn.DbfColumnType.Binary:
                        type = new DbTypeBlob();
                        break;
                    case DbfColumn.DbfColumnType.Boolean:
                        type = new DbTypeLogical();
                        break;
                    case DbfColumn.DbfColumnType.Date:
                        type = new DbTypeDatetime {SubType = DbDatetimeSubType.Date};
                        break;
                    case DbfColumn.DbfColumnType.Character:
                        type = new DbTypeString {Length = dbf.Header[i].Length};
                        break;
                    case DbfColumn.DbfColumnType.Integer:
                        type = new DbTypeInt();
                        break;
                    case DbfColumn.DbfColumnType.Memo:
                        type = new DbTypeText();
                        break;
                    case DbfColumn.DbfColumnType.Number:
                        type = new DbTypeNumeric {Precision = dbf.Header[i].DecimalCount};
                        break;
                    default:
                        type = new DbTypeString();
                        break;
                }
                var col = new ColumnInfo(res);
                col.Name = dbf.Header[i].Name;
                col.CommonType = type;
                //col.FillTypeFromCommonType();
                res.Columns.Add(col);
            }
            return res;
        }


        TableInfo ITabularDataSource.GetRowFormat(IShellContext context)
        {
            var dbf = OpenDbfRead(context);
            try
            {
                return GetStructure(dbf);
            }
            finally
            {
                dbf.Close();
            }
        }

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            var reader = OpenDbfRead(context);
            return new DbfReader(GetStructure(reader), reader);
        }

        bool ITabularDataTarget.IsAvailableRowFormat(IShellContext context)
        {
            return false;
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options, IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(Name), ResolveFileMode.Output);
            context.OutputMessage("Writing file " + Path.GetFullPath(file));
            var dbf = new SocialExplorer.IO.FastDBF.DbfFile(Encoding);
            if (File.Exists(file)) File.Delete(file);
            dbf.Create(file);

            foreach (var col in rowFormat.Columns)
            {
                DbfColumn.DbfColumnType type;
                int len = 0, scale = 0;
                switch (col.CommonType.Code)
                {
                    case DbTypeCode.Array:
                    case DbTypeCode.Generic:
                    case DbTypeCode.Text:
                    case DbTypeCode.Xml:
                        type = DbfColumn.DbfColumnType.Memo;
                        break;
                    case DbTypeCode.Blob:
                        type = DbfColumn.DbfColumnType.Binary;
                        break;
                    case DbTypeCode.Datetime:
                        var dtype = (DbTypeDatetime) col.CommonType;
                        if (dtype.SubType == DbDatetimeSubType.Date)
                        {
                            type = DbfColumn.DbfColumnType.Date;
                        }
                        else
                        {
                            type = DbfColumn.DbfColumnType.Character;
                            len = DateTime.UtcNow.ToString("s").Length;
                        }
                        break;
                    case DbTypeCode.Float:
                        type = DbfColumn.DbfColumnType.Number;
                        len = 18;
                        scale = DefaultNumericScale;
                        break;
                    case DbTypeCode.Int:
                        if (AllowFoxProInteger)
                        {
                            type = DbfColumn.DbfColumnType.Integer;
                        }
                        else
                        {
                            type = DbfColumn.DbfColumnType.Number;
                            len = 18;
                        }
                        break;
                    case DbTypeCode.Logical:
                        type = DbfColumn.DbfColumnType.Boolean;
                        break;
                    case DbTypeCode.Numeric:
                        type = DbfColumn.DbfColumnType.Number;
                        len = 18;
                        scale = ((DbTypeNumeric) col.CommonType).Scale;
                        break;
                    case DbTypeCode.String:
                        var stype = (DbTypeString) col.CommonType;
                        if (stype.IsBinary)
                        {
                            type = DbfColumn.DbfColumnType.Binary;
                        }
                        else if (stype.Length <= 254)
                        {
                            type = DbfColumn.DbfColumnType.Character;
                            len = stype.Length;
                            if (len <= 0) len = DefaultStringLength;
                        }
                        else
                        {
                            type = DbfColumn.DbfColumnType.Memo;
                        }
                        break;
                    default:
                        type = DbfColumn.DbfColumnType.Character;
                        len = DefaultStringLength;
                        break;

                }
                dbf.Header.AddColumn(col.Name, type, len, scale);
            }

            return new DbfWriter(dbf);
        }

        TableInfo ITabularDataTarget.GetRowFormat(IShellContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("[DbfFile {0}]", Name);
        }
    }
}
