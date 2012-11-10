using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Xml;
using DbShell.Common;
using DbShell.Core;

namespace DbShell.Runtime
{
    public class ShellRunner : IDisposable
    {
        private IRunnable _main;
        private ShellContext _context;
        private string _loadedFile;

        public void LoadFile(string file)
        {
            _loadedFile = file;
            CoreLoader.Load();
            using (var fr = new FileInfo(file).OpenRead())
            {
                object obj = XamlReader.Load(fr);
                LoadObject(obj);
            }
        }

        public void LoadString(string content)
        {
            using (var fr = new StringReader(content))
            {
                using (var reader = XmlReader.Create(fr))
                {
                    object obj = XamlReader.Load(reader);
                    LoadObject(obj);
                }
            }
        }

        public void LoadObject(object obj)
        {
            if (_context != null) throw new Exception("Load function already called");
            _main = (IRunnable)obj;
            _context = new ShellContext();
            var element = _main as IShellElement;
            if (element != null) ProcessLoadedElement(element, null, _context);
        }

        public static void ProcessLoadedElement(IShellElement element, IShellElement parent, IShellContext context)
        {
            element.Context = context;
            if (element.Connection == null && parent != null && parent.Connection != null)
            {
                element.Connection = parent.Connection;
            }
            element.EnumChildren(child => ProcessLoadedElement(child, element, context));
        }

        public void Run()
        {
            if (_context == null) throw new Exception("Load function not called");
            if (_loadedFile != null) _context.PushExecutingFile(_loadedFile);
            _main.Run();
            if (_loadedFile != null) _context.PopExecutingFile();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
