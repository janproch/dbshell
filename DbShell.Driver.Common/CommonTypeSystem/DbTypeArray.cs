using System;
using System.Data;
using System.Xml;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public class DbTypeArray : DbTypeStructured
    {
        DbTypeBase m_elementType;
        public DbTypeBase ElementType
        {
            get { return m_elementType; }
            set { m_elementType = value; }
        }

        ArrayDimensions m_dims = new ArrayDimensions(new ArrayDimension());
        public ArrayDimensions Dims
        {
            get { return m_dims; }
            set { m_dims = value; }
        }

        public override string ToString()
        {
            return String.Format("{0}[{1}]", ElementType, Dims);
        }
        public override DbTypeCode Code
        {
            get { return DbTypeCode.Array; }
        }
        public override TypeStorage DefaultStorage
        {
            get { return TypeStorage.String; }
        }
        public override string XsdType
        {
            get { return "xs:string"; }
        }
        public override Type DotNetType
        {
            get { return ElementType.DotNetType.MakeArrayType(); }
        }
        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            xml.SetAttribute("dims", Dims.ToString());
            ElementType.SaveToXml(xml.AddChild("Element"));
        }
        protected override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            Dims = new ArrayDimensions(xml.GetAttribute("dims"));
            ElementType = DbTypeBase.Load(xml.FindElement("Element"));
        }
        public override DbType GetProviderType()
        {
            return DbType.AnsiString;
        }
    }
}