using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// reader for more files of the some format from directory
    /// </summary>
    public class DirectoryTabularDataSource : ElementBase, ITabularDataSource
    {
        [XamlProperty]
        public string PrimaryFile { get; set; }

        [XamlProperty]
        public ITabularDataSource SourceTemplate { get; set; }

        [XamlProperty]
        public string PropertyName { get; set; }

        [XamlProperty]
        public string Filter { get; set; }

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            string filter = context.Replace(Filter);
            if (filter == null)
            {
                string path = context.Replace(PrimaryFile);
                filter = context.Replace(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), "*" + System.IO.Path.GetExtension(path)));
            }

            string pathPart = System.IO.Path.GetDirectoryName(filter);
            string filterPart = System.IO.Path.GetFileName(filter);

            string[] files = System.IO.Directory.GetFiles(pathPart, filterPart);

            return new DirectoryTabularDataReader(context, SourceTemplate, PropertyName, files);
        }

        TableInfo ITabularDataSource.GetRowFormat(IShellContext context)
        {
            using (var childCtx = context.CreateChildContext())
            {
                childCtx.SetVariable(context.Replace(PropertyName), context.Replace(PrimaryFile));
                return SourceTemplate.GetRowFormat(childCtx);
            }
        }

        DataFormatSettings ITabularDataSource.GetSourceFormat(IShellContext context)
        {
            using (var childCtx = context.CreateChildContext())
            {
                childCtx.SetVariable(context.Replace(PropertyName), context.Replace(PrimaryFile));
                return SourceTemplate.GetSourceFormat(childCtx);
            }
        }
    }
}
