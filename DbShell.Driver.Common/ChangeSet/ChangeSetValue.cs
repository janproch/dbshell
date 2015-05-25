using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetValue
    {
        public string Column;
        public object Value;

        public void SaveToXml(XmlElement xml)
        {
            xml.SetAttribute("Column", Column);
            string xtype = null, xdata = null;
            CdlTool.GetValueAsXml(Value, ref xtype, ref xdata);
            xml.SetAttribute("DataType", xtype);
            xml.InnerText = xdata;
        }
    }
}
