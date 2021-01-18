using System;
using System.Collections.Generic;
using System.Text;

using FinDesk.Domain.Entities.Base.Interfaces;
using FinDesk.Domain.Entities.Base;

namespace FinDesk.Domain.Entities
{
    public class IssueType: NamedDictEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public virtual ICollection<BaseIssue> BaseIssues { get; set; }
    }
}
