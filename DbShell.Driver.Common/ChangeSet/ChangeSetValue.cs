using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.ChangeSet
{
    [DataContract]
    public class ChangeSetValue : IExplicitXmlPersistent
    {
        [XmlAttrib]
        [DataMember]
        public string Column { get; set; }

        [DataMember]
        public object Value { get; set; }

        public void SaveToXml(XmlElement xml)
        {
            this.SavePropertiesCore(xml);

            string xtype = null, xdata = null;
            CdlTool.GetValueAsXml(Value, ref xtype, ref xdata);
            xml.SetAttribute("DataType", xtype);
            xml.InnerText = xdata;
        }

        public void LoadFromXml(XmlElement xml)
        {
            this.LoadPropertiesCore(xml);

            string xtype = xml.GetAttribute("DataType");
            string xdata = xml.InnerText;

            Value = CdlTool.GetValueFromXml(xtype, xdata);
        }
    }
}
