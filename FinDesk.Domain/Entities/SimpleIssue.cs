using System;
using System.Collections.Generic;
using System.Text;

namespace FinDesk.Domain.Entities
{
    public class SimpleIssue
    {
        public int Id { get; set; }
        public string User { get; set; }

        public string IssueType { get; set; }
        public string LongDescr { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        public string SolveDescr { get; set; }


    }
}
