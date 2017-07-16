using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public class TriggerInfo : ProgrammableInfo
    {
        private string _tableOrViewName;

        [XmlAttrib("table_or_view_name")]
        [DataMember]
        public string TableOrViewName
        {
            get
            {
                if (RelatedTable != null) return RelatedTable.Name;
                if (RelatedView != null) return RelatedView.Name;
                return _tableOrViewName;
            }
            set
            {
                _tableOrViewName = value;
                RelatedTable = null;
                RelatedView = null;
            }
        }

        private string _tableOrViewSchema;
        [XmlAttrib("table_or_view_schema")]
        [DataMember]
        public string TableOrViewSchema
        {
            get
            {
                if (RelatedTable != null) return RelatedTable.Schema;
                if (RelatedView != null) return RelatedView.Schema;
                return _tableOrViewSchema;
            }
            set
            {
                _tableOrViewSchema = value;
                RelatedTable = null;
                RelatedView = null;
            }
        }

        public NameWithSchema TableOrView
        {
            get
            {
                if (TableOrViewName == null) return null;
                return new NameWithSchema(TableOrViewSchema, TableOrViewName);
            }
            set
            {
                if (value == null)
                {
                    _tableOrViewName = null;
                    _tableOrViewSchema = null;
                }
                else
                {
                    _tableOrViewName = value.Name;
                    _tableOrViewSchema = value.Schema;
                }
                RelatedTable = null;
                RelatedView = null;
            }
        }

        public TableInfo RelatedTable;
        public ViewInfo RelatedView;

        public TriggerInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Trigger; }
        }

        public TriggerInfo CloneTrigger(DatabaseInfo ownerDb = null)
        {
            var res = new TriggerInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneTrigger(owner as DatabaseInfo);
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (TriggerInfo) source;
            TableOrView = src.TableOrView;
        }

        public override void AfterLoadLink()
        {
            base.AfterLoadLink();

            if (RelatedTable == null)
            {
                RelatedTable = OwnerDatabase.GetTable(new NameWithSchema(_tableOrViewSchema, _tableOrViewName));
            }
            if (RelatedView == null)
            {
                RelatedView = OwnerDatabase.GetView(new NameWithSchema(_tableOrViewSchema, _tableOrViewName));
            }
            _tableOrViewName = null;
            _tableOrViewSchema = null;
        }
    }
}
