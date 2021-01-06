using System;
using System.Collections.Generic;
using System.Text;

namespace FinDesk.Domain.Entities
{
    public class BaseIssueFilter
    {
        public int? IssueStatusId { get; set; }
        public int? IssueTypeId { get; set; }

        public int? CategoryId { get; set; }
    }
}
