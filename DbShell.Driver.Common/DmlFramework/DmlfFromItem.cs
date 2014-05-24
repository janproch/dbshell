using System;
using System.Collections.Generic;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfFromItem : DmlfBase
    {
        public DmlfFromItem()
        {
            Relations = new DmlfRelationCollection();
        }

        /// <summary>
        /// can be null (implicit source), than Handler.GetStructure(null) must be implemented
        /// </summary>
        [XmlSubElem]
        public DmlfSource Source { get; set; }
        [XmlCollection(typeof(DmlfRelation), "Relations")]
        public DmlfRelationCollection Relations { get; set; }

        /// <summary>
        /// finds column in joined tables
        /// </summary>
        /// <param name="expr">column expression</param>
        /// <returns>column reference or null, if not found</returns>
        public DmlfColumnRef FindColumn(string expr)
        {
            return null;
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            if (Source != null) Source.ForEachChild(action);
            if (Relations != null) Relations.ForEachChild(action);
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            var src = Source;
            if (src == null) src = handler.BaseTable;
            src.GenSqlDef(dmp, handler);
            dmp.Put(" ");
            Relations.GenSql(dmp, handler);
        }

        public DmlfSource FindSourceWithAlias(string alias)
        {
            if (Source != null && Source.Alias == alias) return Source;
            return Relations.FindSourceWithAlias(alias);
        }

        public IEnumerable<DmlfSource> GetAllSources()
        {
            if (Source != null) yield return Source;
            else yield return DmlfSource.BaseTable;
            foreach (var rel in Relations)
            {
                if (rel.Reference != null)
                {
                    yield return rel.Reference;
                }
            }
        }
    }
}