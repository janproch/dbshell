using DbShell.Core.Utility;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Utility;
using Irony.Parsing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DbShell.Core.ScriptParser
{
    public class DbShellParser : IDbShellParser
    {
        private IDbShellLanguageProvider _language;
        private IJsonElementFactory _elementFactory;
        private ILogger<DbShellParser> _logger;

        public DbShellParser(IDbShellLanguageProvider language, IJsonElementFactory elementFactory, ILogger<DbShellParser> logger)
        {
            _language = language;
            _elementFactory = elementFactory;
            _logger = logger;
        }

        private object ConvertNode(ParseTreeNode node)
        {
            switch (node.Term.Name)
            {
                case "CommandList":
                    var batch = new Batch();
                    ConvertCommandList(batch.Commands, node.ChildNodes);
                    return batch;
                case "true":
                    return true;
                case "false":
                    return true;
                case "string":
                    return node.Token.ValueString;
                case "Command":
                    if (node.ChildNodes[0].Term.Name == "Assign")
                    {
                        return ConvertNode(node.ChildNodes[0]);
                    }
                    string typeName = node.ChildNodes[0].Token.Text;
                    var type = _elementFactory.JsonBinder.BindToType(null, typeName);
                    var instance = Activator.CreateInstance(type);

                    if (node.ChildNodes[1].Term.Name == "CommandValue")
                    {
                        var singleHolder = instance as ISingleValueDbShellObject;
                        object propValue = ConvertNode(node.ChildNodes[1].ChildNodes[0]);
                        singleHolder.SingleValue = propValue;
                    }
                    else
                    {
                        foreach (var paramNode in node.ChildNodes[1].ChildNodes)
                        {
                            string propName = MiscTool.ToPascalCase(paramNode.ChildNodes[0].Token.Text);

                            var valueNode = paramNode.ChildNodes[1].ChildNodes[0];
                            object propValue = ConvertNode(valueNode);

                            var prop = type.GetProperty(propName);
                            if (prop == null)
                            {
                                _logger.LogWarning("Type {type} has not property {property}", typeName, propName);
                                continue;
                            }
                            prop.SetValue(instance, propValue);
                        }
                    }

                    foreach (var subnode in node.ChildNodes[2].ChildNodes)
                    {
                        IList collection = null;

                        if (subnode.ChildNodes.Count == 2)
                        {
                            string propName = subnode.ChildNodes[0].Token.Text;
                            var propInfo = type.GetProperty(propName);
                            collection = (IList)propInfo.GetValue(instance);
                        }
                        else
                        {
                            var provider = instance as IDefaultCollectionProvider;
                            if (provider == null)
                                throw new Exception($"DBSH-00000 Type {typeName} has no default collection provider");
                            collection = provider.DefaultCollection;
                        }

                        if (collection == null)
                            throw new Exception($"DBSH-00000 Type {typeName} has collection not set");

                        foreach (var propNode in subnode.ChildNodes.Last().ChildNodes)
                        {
                            var converted = ConvertNode(propNode);
                            collection.Add(converted);
                        }
                    }

                    return instance;
                case "Assign":
                    string varName = node.ChildNodes[0].Token.Text;
                    string strExpr = node.ChildNodes[1].Token.ValueString;
                    return new SetVariable
                    {
                        Name = varName,
                        Value = strExpr,
                    };

            }
            return new Batch();
        }

        private void ConvertCommandList(List<IRunnable> commands, ParseTreeNodeList childNodes)
        {
            foreach (var node in childNodes)
            {
                var converted = ConvertNode(node);
                if (!(converted is IRunnable))
                    throw new Exception("DBSH-00000 Runnable expected");
                commands.Add((IRunnable)converted);
            }
        }

        public IRunnable Parse(string text)
        {
            var parser = new Parser(_language.DbShellLanguage);
            var tree = parser.Parse(text);

            foreach (var error in tree.ParserMessages)
            {
                _logger.LogError("Parse error: {message}, location: {location}", error.Message, error.Location);
                Trace.WriteLine($"Parse error: {error.Message}, location: {error.Location}");
            }
            if (tree.HasErrors())
                return null;

            return ConvertNode(tree.Root) as IRunnable;
        }
    }
}
