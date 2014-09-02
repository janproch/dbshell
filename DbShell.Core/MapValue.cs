using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// Column mapping for value expression.
    /// </summary>
    /// <remarks>
    /// Maximally of on of Value or Expression should be set. If none of these properties are set, NULL value is used
    /// </remarks>
    public class MapValue : ElementBase, IColumnMapping
    {
        private CdlValueHolder _value;

        /// <summary>
        /// Gets or sets the name of output column.
        /// </summary>
        /// <value>
        /// The name of output column.
        /// </value>
        [XamlProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of column. Must not be set, when Expression is set.
        /// </summary>
        /// <value>
        /// The expression value.
        /// </value>
        [XamlProperty]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether column values are available in expressions
        /// </summary>
        /// <value>
        ///   if <c>true</c>, replace expressions are available. By default it is <c>true</c>. Change it to false for performance reasons.
        /// </value>
        [XamlProperty]
        public bool NeedColumnValues { get; set; }

        /// <summary>
        /// Gets or sets the expression. Must not be set, when Value is set.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        [XamlProperty]
        public string Expression { get; set; }

        ColumnInfo[] IColumnMapping.GetOutputColumns(TableInfo inputTable)
        {
            var column = new ColumnInfo(new TableInfo(null)) {CommonType = new DbTypeString(), Name = Name, DataType = "nvarchar", Length = -1};
            return new[] {column};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapValue" /> class.
        /// </summary>
        public MapValue()
        {
            NeedColumnValues = true;
        }

        private void CreateColumnValues(ICdlRecord record)
        {
            if (NeedColumnValues)
            {
                Context.EnterScope();
                for (int i = 0; i < record.FieldCount; i++)
                {
                    Context.SetVariable(record.GetName(i), record.GetValue(i));
                }
            }
        }

        private void FreeColumnValues()
        {
            if (NeedColumnValues)
            {
                Context.LeaveScope();
            }
        }

        void IColumnMapping.ProcessMapping(int column, int rowNumber, ICdlRecord record, ICdlValueWriter writer)
        {
            if (_value == null)
            {
                _value = new CdlValueHolder();
            }
            if (Expression != null && Value != null)
            {
                throw new Exception("DBSH-00004 MapValue: Both Expression and Value is set");
            }
            if (Value != null)
            {
                try
                {
                    CreateColumnValues(record);
                    string value = Replace(Value);
                    _value.ReadFrom(value);
                    _value.WriteTo(writer);
                }
                finally
                {
                    FreeColumnValues();
                }
            }
            if (Expression != null)
            {
                try
                {
                    CreateColumnValues(record);
                    object value = Context.Evaluate(Expression);
                    _value.ReadFrom(value);
                    _value.WriteTo(writer);
                }
                finally
                {
                    FreeColumnValues();
                }
            }
            if (Expression == null && Value == null)
            {
                _value.SetNull();
                _value.WriteTo(writer);
            }
        }
    }
}
