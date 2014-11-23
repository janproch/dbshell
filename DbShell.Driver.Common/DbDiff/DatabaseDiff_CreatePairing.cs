using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    partial class DatabaseDiff
    {
        public bool IsPaired(DatabaseObjectInfo obj)
        {
            return srcGroupIds.ContainsKey(obj.GroupId) && dstGroupIds.ContainsKey(obj.GroupId);
        }

        public T FindPair<T>(T obj)
            where T : DatabaseObjectInfo
        {
            var src = srcGroupIds.Get(obj.GroupId, null);
            var dst = dstGroupIds.Get(obj.GroupId, null);
            if (src == obj) return (T)dst;
            if (dst == obj) return (T)src;
            return null;
        }

        public DatabaseObjectInfo FindSource(string groupid)
        {
            if (groupid == null) return null;
            return srcGroupIds.Get(groupid, null);
        }

        public DatabaseObjectInfo FindTarget(string groupid)
        {
            if (groupid == null) return null;
            return dstGroupIds.Get(groupid, null);
        }

        // sparovani objektu
        private void CreatePairing()
        {
            //PairDomains();
            PairTables();
            PairSpecificObjects();
        }

        //private void PairDomains()
        //{
        //    foreach (DomainStructure dsrc in m_src.Domains)
        //    {
        //        if (IsPaired(dsrc)) continue;
        //        foreach (DomainStructure ddst in m_dst.Domains)
        //        {
        //            if (DbDiffTool.EqualFullNames(dsrc.FullName, ddst.FullName, m_options))
        //            {
        //                if (!IsPaired(ddst)) PairObjects(dsrc, ddst);
        //            }
        //        }
        //    }
        //}

        //private void PairViews()
        //{
        //    foreach (var osrc in m_src.Views)
        //    {
        //        if (IsPaired(osrc)) continue;
        //        foreach (SpecificObjectStructure odst in m_dst.Views)
        //        {
        //            if (odst.ObjectType == osrc.ObjectType && DbDiffTool.EqualFullNames(osrc.ObjectName, odst.ObjectName, m_options))
        //            {
        //                if (!IsPaired(odst)) PairObjects(osrc, odst);
        //            }
        //        }
        //    }
        //}

        private void PairSpecificObjects()
        {
            foreach (var osrc in m_src.GetAllSpecificObjects())
            {
                if (IsPaired(osrc)) continue;
                foreach (var odst in m_dst.GetAllSpecificObjects())
                {
                    if (odst.ObjectType == osrc.ObjectType && DbDiffTool.EqualFullNames(osrc.FullName, odst.FullName, m_options))
                    {
                        if (!IsPaired(odst)) PairObjects(osrc, odst);
                    }
                }
            }
        }

        private void PairTables()
        {
            foreach (var tsrc in m_src.Tables)
            {
                if (IsPaired(tsrc)) continue;
                foreach (var tdst in m_dst.Tables)
                {
                    if (DbDiffTool.EqualFullNames(tsrc.FullName, tdst.FullName, m_options) && !IsPaired(tdst))
                    {
                        PairObjects(tsrc, tdst);
                        break;
                    }
                }
                //TableStructure tdst = m_dst.FindTable(tsrc.FullName);
                //if (tdst != null) PairObjects(tsrc, tdst);
            }

            if (m_options.AllowPairRenamedTables)
            {
                // snazime se tabulky sparovat na zaklade stejnych jmen VSECH sloupcu
                foreach (var tsrc in m_src.Tables)
                {
                    if (IsPaired(tsrc)) continue;
                    foreach (var tdst in m_dst.Tables)
                    {
                        if (DbDiffTool.EqualColumnNames(tsrc, tdst) && !IsPaired(tdst))
                        {
                            PairObjects(tsrc, tdst);
                            break;
                        }
                    }
                }
            }

            foreach (var tsrc in m_src.Tables)
            {
                var tdst = FindPair(tsrc);
                if (tdst != null)
                {
                    PairTableContent(tsrc, tdst);
                }
            }
        }

        private void PairTableContent(TableInfo tsrc, TableInfo tdst)
        {
            // parovani sloupcu podle jmen
            foreach (var csrc in tsrc.Columns)
            {
                var cdst = tdst.Columns.FirstOrDefault(c => c.Name == csrc.Name);
                if (cdst != null)
                {
                    PairObjects(csrc, cdst);
                }
            }

            // parovani sloupcu dle indexu (jen ty nesparovane podle jmen)
            foreach (var csrc in tsrc.Columns)
            {
                if (IsPaired(csrc)) continue;
                int cindex = tsrc.Columns.GetIndex(csrc.Name);
                if (cindex < tdst.Columns.Count && !IsPaired(tdst.Columns[cindex]))
                {
                    PairObjects(csrc, tdst.Columns[cindex]);
                }
            }

            // sparovani primarnich klicu
            var psrc = tsrc.PrimaryKey;
            var pdst = tdst.PrimaryKey;
            if (psrc != null && pdst != null) PairObjects(psrc, pdst);

            // sparovani na zaklade jmen constraintu
            foreach (var csrc in tsrc.Constraints)
            {
                if (IsPaired(csrc)) continue;
                var cdst = tdst.Constraints.FirstOrDefault(c => c.ConstraintName != null && c.ConstraintName == csrc.ConstraintName);

                if (cdst != null && !IsPaired(cdst) && csrc.GetType() == cdst.GetType())
                {
                    PairObjects(csrc, cdst);
                }
            }

            // sparovani na zaklade typu a obsahu constraintu (jmen sloupcu/vyrazu CHECK)
            foreach (var csrc in tsrc.Constraints)
            {
                if (IsPaired(csrc)) continue;

                foreach (var cdst in tdst.Constraints)
                {
                    if (IsPaired(cdst)) continue;
                    if (csrc.GetType() != cdst.GetType()) continue;

                    if (csrc is ColumnsConstraintInfo)
                    {
                        if (((ColumnsConstraintInfo)csrc).Columns.EqualSequence(((ColumnsConstraintInfo)cdst).Columns))
                        {
                            PairObjects(csrc, cdst);
                            break;
                        }
                    }

                    if (csrc is CheckInfo)
                    {
                        if (((CheckInfo)csrc).Definition == ((CheckInfo)cdst).Definition)
                        {
                            PairObjects(csrc, cdst);
                            break;
                        }
                    }
                }
            }
        }

        private void PairObjects(DatabaseObjectInfo src, DatabaseObjectInfo dst)
        {
            dstGroupIds.Remove(dst.GroupId);
            dst.GroupId = src.GroupId;
            dstGroupIds[dst.GroupId] = dst;
        }
    }
}
