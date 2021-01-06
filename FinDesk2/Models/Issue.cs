using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinDesk2.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string User { get; set; }

        public DateTime IssueTS { get; set; }
        
        public string IssueType { get; set; }
        public string Category { get; set; }
        public string LongDescr { get; set; }

        public string Status { get; set; }

        //
        public DateTime SolveTS { get; set; }
        public string SolveDescr { get; set; }
        public string SolveUser { get; set; }
            
    }
}
