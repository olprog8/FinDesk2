using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace FinDesk2.ViewModels
{
    public class SimpleIssueMailViewModel
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DateTime IssueTS { get; set; }

        public string IssueType { get; set; }

        public string Category { get; set; }

        public string LongDescr { get; set; }

        public string SolveDescr { get; set; }

        public string IssueStatus { get; set; }
    }
}
