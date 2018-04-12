using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.CommonTypeSystem;

namespace DbShell.Xml
{
    public static class XmlTableAnalyser
    {
        internal class Node
        {
            internal string Name;
            internal Node Parent;
            internal Dictionary<string, Node> Children = new Dictionary<string, Node>();
            internal List<Node> ChildList = new List<Node>();
            internal HashSet<string> Attributes = new HashSet<string>();
            internal List<string> AttributeList = new List<string>();
            internal bool IsRepetetive;
            internal int Level;

            internal int CurrentCount;
            internal bool HasText;

            internal Node SubElement(string name)
            {
                Node res;
                if (Children.ContainsKey(name))
                {
                    res = Children[name];
                }
                else
                {
                    res = new Node { Parent = this, Name = name, Level = Level + 1 };
                    Children[name] = res;
                    ChildList.Add(res);
                }
                res.CurrentCount++;

                foreach (var child in res.ChildList) child.ClearCurrentCounts();

                return res;
            }

            private void ClearCurrentCounts()
            {
                CurrentCount = 0;
                foreach (var child in ChildList) child.ClearCurrentCounts();
            }

            internal void Attribute(string name)
            {
                if (!Attributes.Contains(name))
                {
                    Attributes.Add(name);
                    AttributeList.Add(name);
                }
            }

            internal string GetXPath(Node relativeTo)
            {
                if (relativeTo == null) return GetXPathRelativeToParent(relativeTo);
                if (relativeTo == this) return ".";
                var commonParent = GetCommonParent(this, relativeTo);
                if (relativeTo == commonParent) return GetXPathRelativeToParent(relativeTo);

                var node = relativeTo;
                string xpathPrefix = "";
                while (node != commonParent)
                {
                    node = node.Parent;
                    xpathPrefix = xpathPrefix + "../";
                }
                return xpathPrefix + GetXPathRelativeToParent(commonParent);
            }

            internal static Node GetCommonParent(Node a, Node b)
            {
                while (a.Level > b.Level) a = a.Parent;
                while (b.Level > a.Level) b = b.Parent;
                while (a != b)
                {
                    a = a.Parent;
                    b = b.Parent;
                }
                return a;
            }

            internal string GetXPathRelativeToParent(Node relativeTo)
            {
                if (relativeTo == this) return ".";
                if (Parent == relativeTo) return Name;
                if (Parent == null) return Name;
                return Parent.GetXPathRelativeToParent(relativeTo) + "/" + Name;
            }

            private string _absXPath;

            internal string AbsXPath
            {
                get
                {
                    if (_absXPath == null) _absXPath = GetXPathRelativeToParent(null);
                    return _absXPath;
                }
            }

            //internal bool IsStructured => Attributes.Any() || Children.Any();

            //internal int StructuredChildrenCount => Children.Values.Count(x => x.IsStructured);
        }

        public static TableInfo GetRowFormat(List<XmlReadInstructions> instructions)
        {
            var res = new TableInfo(null);
            foreach (var instruction in instructions)
            {
                foreach (var col in instruction.Columns)
                {
                    if (res.Columns.Any(x => x.Name == col.Name)) continue;
                    res.Columns.Add(new ColumnInfo(res) { CommonType = new DbTypeString(), DataType = "nvarchar(max)", Name = col.Name });
                }
            }
            return res;
        }

        public static List<XmlReadInstructions> AnalyseXmlReader(System.Xml.XmlReader reader, bool globalUniqueColumnNames)
        {
            var root = new Node();
            var current = root;

            var resultSets = new Dictionary<string, Node>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        current = current.SubElement(reader.Name);
                        if (reader.HasAttributes)
                        {
                            reader.MoveToFirstAttribute();
                            do
                            {
                                current.Attribute(reader.Name);
                            } while (reader.MoveToNextAttribute());
                            reader.MoveToElement();
                        }
                        if (current.CurrentCount > 1)
                        {
                            string xpath = current.AbsXPath;
                            if (!resultSets.ContainsKey(xpath))
                            {
                                resultSets[xpath] = current;
                                current.IsRepetetive = true;
                            }
                        }
                        if (reader.IsEmptyElement) current = current.Parent;
                        break;
                    case XmlNodeType.Text:
                        if (!String.IsNullOrWhiteSpace(reader.Value))
                        {
                            current.HasText = true;
                        }
                        break;
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.ProcessingInstruction:
                    case XmlNodeType.Comment:
                        continue;
                    case XmlNodeType.EndElement:
                        current = current.Parent;
                        break;
                }
            }

            // remove repetetive parents. Remains only innermost repetetives
            foreach (var resultSet in resultSets.Values.ToList())
            {
                var node = resultSet;
                node = node.Parent;
                while (node != null && !node.IsRepetetive) node = node.Parent;
                if (node != null)
                {
                    resultSets.Remove(node.AbsXPath);
                    node.IsRepetetive = false;
                }
            }

            if (!resultSets.Any())
            {
                resultSets["/"] = root;
            }

            var res = new List<XmlReadInstructions>();
            var addedColumns = new HashSet<string>();
            var collectionNames = new HashSet<string>();
            foreach (var resultSet in resultSets.Values)
            {
                var instruction = new XmlReadInstructions();
                instruction.XPath = resultSet.AbsXPath ?? "/";

                string collectionName = resultSet.Name;
                if (collectionNames.Contains(collectionName))
                {
                    int index = 2;
                    while (collectionNames.Contains(collectionName + index)) index++;
                    collectionName = collectionName + index;
                }
                instruction.CollectionName = collectionName;

                if (!globalUniqueColumnNames) addedColumns.Clear();

                CollectColumns(instruction, root, addedColumns, resultSet);
                if (resultSet != root)
                {
                    CollectColumns(instruction, resultSet, addedColumns, resultSet);
                }

                res.Add(instruction);
            }

            return res;
        }

        private static void AddAttribute(XmlReadInstructions instruction, string name, string xpath, HashSet<string> addedColumns)
        {
            if (addedColumns.Contains(name))
            {
                int index = 2;
                while (addedColumns.Contains(name + index)) index++;
                name = name + index;
            }
            addedColumns.Add(name);
            instruction.Columns.Add(new XmlColumn
            {
                Name = name,
                XPath = xpath,
            });
        }

        private static void CollectColumns(XmlReadInstructions instruction, Node current, HashSet<string> addedColumns, Node relativeTo)
        {
            if (current.HasText)
            {
                AddAttribute(instruction, current.Name, current.GetXPath(relativeTo), addedColumns);
            }

            foreach (var attr in current.AttributeList)
            {
                if (attr.Contains(":")) continue;
                string xpath = current.GetXPath(relativeTo);
                if (!String.IsNullOrEmpty(xpath) && !xpath.EndsWith("/")) xpath += "/";
                xpath += "@" + attr;
                AddAttribute(instruction, attr, xpath, addedColumns);
            }

            foreach (var child in current.ChildList)
            {
                if (child.IsRepetetive) continue;
                CollectColumns(instruction, child, addedColumns, relativeTo);
            }
        }


        public static List<XmlReadInstructions> AnalyseFile(string file, bool globalUniqueColumnNames)
        {
            using (var textReader = System.IO.File.OpenText(file))
            {
                using (var reader = System.Xml.XmlReader.Create(textReader))
                {
                    return AnalyseXmlReader(reader, globalUniqueColumnNames);
                }
            }
        }
    }
}
