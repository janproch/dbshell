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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value expression of column. Must not be set, when Expression is set.
        /// </summary>
        /// <value>
        /// The expression value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether expression syntax in Value field is supported
        /// </summary>
        /// <value>
        ///   if <c>true</c>, replace expressions can be used. There are available variables for all columns.
        /// </value>
        public bool UseExpression { get; set; }

        /// <summary>
        /// Gets or sets the expression. Must not be set, when Value is set.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        public string Expression { get; set; }

        ColumnInfo[] IColumnMapping.GetOutputColumns(TableInfo inputTable)
        {
            var column = new ColumnInfo(new TableInfo(null)) {CommonType = new DbTypeString(), Name = Name, DataType = "nvarchar", Length = -1};
            return new[] {column};
        }

        void IColumnMapping.ProcessMapping(int column, ICdlRecord record, ICdlValueWriter writer)
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
                if (UseExpression)
                {
                    try
                    {
                        Context.EnterScope();
                        for (int i = 0; i < record.FieldCount; i++)
                        {
                            Context.SetVariable(record.GetName(i), record.GetValue(i));
                        }
                        string value = Context.Replace(Value);
                        _value.ReadFrom(value);
                    }
                    finally
                    {
                        Context.LeaveScope();
                    }
                    _value.WriteTo(writer);
                }
                else
                {
                    _value.ReadFrom(Value);
                    _value.WriteTo(writer);
                }
            }
            if (Expression != null)
            {
                try
                {
                    Context.EnterScope();
                    for (int i = 0; i < record.FieldCount; i++)
                    {
                        Context.SetVariable(record.GetName(i), record.GetValue(i));
                    }
                    object value = Context.Evaluate(Expression);
                    _value.ReadFrom(value);
                }
                finally
                {
                    Context.LeaveScope();
                }
                _value.WriteTo(writer);
            }
            if (Expression == null && Value == null)
            {
                _value.SetNull();
                _value.WriteTo(writer);
            }
        }
    }
}
