using System;
using System.Collections.Generic;
using System.Text;

using FinDesk.Domain.Entities.Base.Interfaces;

namespace FinDesk.Domain.Entities
{
    public class BaseIssue: IBaseEntity
    {
        public int Id { get; set; }
        public string User { get; set; }

        public DateTime IssueTS { get; set; }

        public int IssueTypeId { get; set; }
        public int CategoryId { get; set; }
        public string LongDescr { get; set; }

        public int IssueStatusId { get; set; }

        //
        public DateTime SolveTS { get; set; }
        public string SolveDescr { get; set; }
        public string SolveUser { get; set; }
    }
}
