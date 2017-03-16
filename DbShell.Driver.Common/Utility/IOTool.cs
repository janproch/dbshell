using System;
using System.Collections.Generic;
using System.Collections.Specialized;
#if !NETCOREAPP1_1
using System.Drawing;
using System.Drawing.Imaging;
#endif
using System.IO;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public enum CopyFileMode { Copy, Move }

    public static class IOTool
    {
        public static void CopyStream(Stream fr, Stream fw)
        {
            byte[] buffer = new byte[0x100];
            for (; ; )
            {
                int len = fr.Read(buffer, 0, buffer.Length);
                fw.Write(buffer, 0, len);
                if (len <= 0) break;
            }
        }
        public static byte[] ReadToEnd(Stream fr)
        {
            MemoryStream fw = new MemoryStream();
            CopyStream(fr, fw);
            return fw.ToArray();
        }

        /// <summary>
        /// Creates a relative path from one file
        /// or folder to another.
        /// </summary>
        /// <param name="fromDirectory">
        /// Contains the directory that defines the
        /// start of the relative path.
        /// </param>
        /// <param name="toPath">
        /// Contains the path that defines the
        /// endpoint of the relative path.
        /// </param>
        /// <returns>
        /// The relative path from the start
        /// directory to the end path.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RelativePathTo(
            string fromDirectory, string toPath)
        {
            if (fromDirectory == null)
                throw new ArgumentNullException("fromDirectory", "DBSH-00051 fromDirectory is null");

            if (toPath == null)
                throw new ArgumentNullException("toPath", "DBSH-00052 toPath is null");

            bool isRooted = Path.IsPathRooted(fromDirectory)
                && Path.IsPathRooted(toPath);

            if (isRooted)
            {
                bool isDifferentRoot = String.Compare(
                    Path.GetPathRoot(fromDirectory),
                    Path.GetPathRoot(toPath), true) != 0;

                if (isDifferentRoot)
                    return toPath;
            }

            var relativePath = new List<string>();
            string[] fromDirectories = fromDirectory.Split(
                Path.DirectorySeparatorChar);

            string[] toDirectories = toPath.Split(
                Path.DirectorySeparatorChar);

            int length = Math.Min(
                fromDirectories.Length,
                toDirectories.Length);

            int lastCommonRoot = -1;

            // find common root
            for (int x = 0; x < length; x++)
            {
                if (String.Compare(fromDirectories[x],
                    toDirectories[x], true) != 0)
                    break;

                lastCommonRoot = x;
            }
            if (lastCommonRoot == -1)
                return toPath;

            // add relative folders in from path
            for (int x = lastCommonRoot + 1; x < fromDirectories.Length; x++)
                if (fromDirectories[x].Length > 0)
                    relativePath.Add("..");

            // add to folders to path
            for (int x = lastCommonRoot + 1; x < toDirectories.Length; x++)
                relativePath.Add(toDirectories[x]);

            // create relative path
            string[] relativeParts = new string[relativePath.Count];
            relativePath.CopyTo(relativeParts, 0);

            string newPath = String.Join(
                Path.DirectorySeparatorChar.ToString(),
                relativeParts);

            return newPath;
        }

        public static string LoadTextFile(string file)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(file))) return sr.ReadToEnd();
        }

        public static IEnumerable<string> LoadLines(string file)
        {
            if (!File.Exists(file)) yield break;
            using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine().TrimEnd();
                }
            }
        }

        public static bool FileIsLink(string file)
        {
            return file.ToLower().EndsWith(".lnk");
        }

        //public static bool FileIsDirectoryLink(string file)
        //{
        //    return file.ToLower().EndsWith(".dln");
        //}

        public static void CreateLink(string origfile, string linkpath)
        {
            string fn = origfile;
            fn = Path.ChangeExtension(fn, ".lnk");
            fn = Path.GetFileName(fn);
            fn = Path.Combine(linkpath, fn);
            fn = GetUniqueFileName(fn);
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(fn))) sw.Write(origfile);
        }

        public static string GetLinkContent(string file)
        {
            if (FileIsLink(file))
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(file)))
                {
                    return sr.ReadToEnd().Trim();
                }
            }
            return file;
        }

        public static string GetUniqueFileName(string fn)
        {
            string fn0 = Path.Combine(Path.GetDirectoryName(fn), Path.GetFileNameWithoutExtension(fn));
            string ext = Path.GetExtension(fn);
            fn = fn0;
            int dindex = 1;
            while (File.Exists(fn + ext))
            {
                fn = fn0 + dindex;
                dindex++;
            }
            return fn + ext;
        }

        public static bool IsVersioningDirectory(string dir)
        {
            dir = Path.GetFileName(dir).ToLower();
            return dir == ".svn" || dir == "cvs";
        }


        public static void CopyDirectory(string origpath, string newpath)
        {
            CopyDirectory(new DirectoryInfo(origpath), new DirectoryInfo(newpath));
        }

        public static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (!Directory.Exists(target.FullName))
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it’s new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }

#if !NETCOREAPP1_1
        public static string ImageToText(Bitmap image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            return Convert.ToBase64String(ms.ToArray());
        }

        public static Bitmap ImageFromText(string text)
        {
            var ms = new MemoryStream(Convert.FromBase64String(text));
            return new Bitmap(Image.FromStream(ms));
        }
#endif

        public static void SaveLines(string path, HashSetEx<string> lines)
        {
            using (var sw = new StreamWriter(File.OpenWrite(path)))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public static string NormalizePath(string fn)
        {
            if (fn == null) return null;
            fn = fn.Replace("\\", "/").ToLower();
            if (fn.EndsWith("/")) fn = fn.Substring(0, fn.Length - 1);
            return fn;
        }

        public static bool FileIsInDirectory(string file, string directory)
        {
            return NormalizePath(file).StartsWith(NormalizePath(directory));
        }

        public static void CopyFile(string srcfile, string dstfile, CopyFileMode mode)
        {
            try { Directory.CreateDirectory(Path.GetDirectoryName(dstfile)); }
            catch { }
            switch (mode)
            {
                case CopyFileMode.Copy:
                    File.Copy(srcfile, dstfile, true);
                    break;
                case CopyFileMode.Move:
                    if (File.Exists(dstfile)) File.Delete(dstfile);
                    File.Move(srcfile, dstfile);
                    break;
            }
        }

        public static bool FileLinkExists(string file)
        {
            string path = GetLinkContent(file);
            return File.Exists(path);
        }

        public static bool DirectoryLinkExists(string file)
        {
            string path = GetLinkContent(file);
            return Directory.Exists(path);
        }

        public static string CreateFileFriendlyName(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (Char.IsLetterOrDigit(c)) sb.Append(c);
                else if (c == '_' || c == '-') sb.Append(c);
                else if (c == ' ') sb.Append('_');
            }
            return sb.ToString();
        }

        public static string GetDataFileExtension(string path)
        {
            string ext = Path.GetExtension(path) ?? "";
            if (ext != null && ext.StartsWith(".")) ext = ext.Substring(1);
            return ext.ToLower();
        }

        public static bool FileHasExtension(string file, string ext)
        {
            if (String.IsNullOrEmpty(ext)) return true;
            if (ext.StartsWith(".")) return file.ToLower().EndsWith(ext.ToLower());
            return file.ToLower().EndsWith("." + ext.ToLower());
        }

        public static bool FileHasOneOfExtension(string file, string extensions)
        {
            if (String.IsNullOrEmpty(extensions)) return false;
            var exts = extensions.Split('|');
            foreach (string ext in exts)
            {
                if (FileHasExtension(file, ext)) return true;
            }
            return false;
        }

        public static string AddFirstExtension(string name, string extensions)
        {
            if (String.IsNullOrEmpty(extensions)) return name;
            var exts = extensions.Split('|');
            foreach (string ext in exts)
            {
                if (FileHasExtension(name, ext)) return name;
            }

            return name + "." + exts[0];
        }

        public static string GenerateFileName(string directory, string name)
        {
            string ext = Path.GetExtension(name);
            string nameNoExt = Path.GetFileNameWithoutExtension(name);

            if (!File.Exists(Path.Combine(directory, nameNoExt + ext))) return Path.Combine(directory, nameNoExt + ext);
            int i = 1;
            while (File.Exists(Path.Combine(directory, nameNoExt + i.ToString() + ext))) i++;
            return Path.Combine(directory, nameNoExt + i.ToString() + ext);
        }
    }
}
