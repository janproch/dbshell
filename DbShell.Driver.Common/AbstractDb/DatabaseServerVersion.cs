using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public class DatabaseServerVersion
    {
        public readonly bool IsMax = false;
        public readonly int V1;
        public readonly int V2;
        public readonly int V3;
        public readonly string OrigName;
        public string Description { get; set; }
        public string SellingName { get; set; }

        public DatabaseServerVersion(string version)
        {
            OrigName = version;

            if (version == null)
            {
                IsMax = true;
                return;
            }
            try
            {
                string[] vers = version.Split('.');
                V1 = StringTool.ParseIntStart(vers[0]);
                V2 = vers.Length >= 2 ? StringTool.ParseIntStart(vers[1]) : 0;
                V3 = vers.Length >= 3 ? StringTool.ParseIntStart(vers[2]) : 0;
            }
            catch
            {
                V1 = V2 = V3 = 0;
                IsMax = true;
            }
        }

        public bool IsMinimally(int m1, int m2, int m3)
        {
            if (IsMax) return true;
            if (V1 < m1) return false;
            if (V1 > m1) return true;
            if (V2 < m2) return false;
            if (V2 > m2) return true;
            if (V3 < m3) return false;
            if (V3 > m3) return true;
            return true;
        }

        public override string ToString()
        {
            if (IsMax) return "";
            return String.Format("{0}.{1}.{2}", V1, V2, V3);
        }

        public string ToString(int minimalNumberCount)
        {
            if (IsMax) return "";
            if (minimalNumberCount == 1 && V2 == 0 && V3 == 0) V1.ToString();
            if (minimalNumberCount == 2 && V3 == 0) return String.Format("{0}.{1}", V1, V2);
            return ToString();
        }

    }
}
