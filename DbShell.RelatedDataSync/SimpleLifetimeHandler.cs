using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public class SimpleLifetimeHandler : LifetimeHandlerBase
    {
        [XamlProperty]
        public bool Update { get; set; } = true;

        [XamlProperty]
        public bool Insert { get; set; } = true;

        [XamlProperty]
        public bool Delete { get; set; } = false;

        public override bool CreateInsert => Insert;
        public override bool CreateUpdate => Update;
        public override bool CreateDelete => Delete;
    }
}
