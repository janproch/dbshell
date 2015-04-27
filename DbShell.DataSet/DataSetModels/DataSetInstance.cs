using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.DataSet.DataSetModels
{
    public class DataSetInstance
    {
        public readonly object[] Values;
        public readonly DataSetClass Class;

        // variable, which is used as ID for new object (in WriteSql)
        // is filled if IsReferenced==true or instance contains not null not mandatory reference
        public int? IdVariable;

        // identity key of new variable (in OnTheFly copy)
        // is filled if IsReferenced==true or instance contains not null not mandatory reference
        public int? NewIdentity;

        // whether in export set exists reference to this identity value
        public bool IsReferenced; 

        public DataSetInstance(DataSetClass cls, object[] values)
        {
            Class = cls;
            Values = values;
        }

        public int IdentityValue
        {
            get
            {
                if (Class.IdentityColumnOrdinal < 0) throw new Exception(String.Format("Please define identity of table {0}", Class.TableName));
                return Int32.Parse(Values[Class.IdentityColumnOrdinal].ToString());
            }
        }

        public int SimpleKeyValue
        {
            get
            {
                if (Class.SimplePkColIndex < 0) throw new Exception(String.Format("Please define simple key of table {0}", Class.TableName));
                return Int32.Parse(Values[Class.SimplePkColIndex].ToString());
            }
        }

        public bool RequiredIdentity
        {
            get
            {
                if (IsReferenced) return true;
                foreach (var r in Class.References)
                {
                    if (!r.Mandatory)
                    {
                        object value = Values[Class.ColumnOrdinals[r.BindingColumn]];
                        if (value != null && value != DBNull.Value) return true;
                    }
                }
                return false;
            }
        }
    }
}
