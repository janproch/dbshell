using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Common;

namespace DbShell.RelatedDataSync
{
    public abstract class LogHandlerBase
    {
        public abstract void PutLogMessage(
            ISqlDumper dmp, 
            string operationExpr, 
            string targetEntityExpr, 
            string messageExpr, 
            string durationExpr, 
            string procedureExpr, 
            IShellContext context);
    }
}
