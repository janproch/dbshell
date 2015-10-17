using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;
using DbShell.RelatedDataSync.SqlModel;

namespace DbShell.RelatedDataSync
{
    public enum CompareColumnContext
    {
        Update,
        MarkUpdated,
    }

    public enum UpdateColumnContext
    {
        Update,
        MarkUpdated,
        MarkDelete,
        MarkRelive,
    }

    public class LifetimeHandlerBase
    {
        public virtual bool CreateInsert => true;
        public virtual bool CreateUpdate => true;
        public virtual bool CreateDelete => false;
        public virtual bool CreateMarkDeleted => false;
        public virtual bool CreateMarkUpdated => false;
        public virtual bool CreateMarkRelived => false;

        internal virtual void CreateLifetimeConditions(DmlfCommandBase cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
        }
        internal virtual void CreateReliveConditions(DmlfCommandBase cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
        }
        internal virtual void CreateReliveUpdateFields(DmlfUpdate cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
        }
        internal virtual void CreateSetDeletedUpdateFields(DmlfUpdate cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
        }
        internal virtual void CreateSetUpdatedUpdateFields(DmlfUpdate cmd, string targetEntityAlias, TargetEntitySqlModel targetEntityModel)
        {
        }

        public virtual bool? CompareColumn(string name, CompareColumnContext ctx) => null;
        public virtual bool? UpdateColumn(string name, UpdateColumnContext ctx) => null;

        internal virtual void AddTargetColumns(TargetEntitySqlModel targetEntityModel)
        {
        }
    }
}
