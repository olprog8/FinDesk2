using System;
using System.Collections.Generic;
using System.Text;

using FinDesk.Domain.Entities.Base.Interfaces;

namespace FinDesk.Domain.Entities
{
    public class SimpleIssue : IBaseEntity
    {
        public int Id { get; set; }
        public string User { get; set; }

        public DateTime IssueTS { get; set; }
        public string IssueType { get; set; }
        public string Category { get; set; }
        public string IssueStatus { get; set; }
        public string LongDescr { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        public string SolveDescr { get; set; }


    }
}
