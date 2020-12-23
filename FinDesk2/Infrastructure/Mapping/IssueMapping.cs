using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;
using FinDesk2.ViewModels;

namespace FinDesk2.Infrastructure.Mapping
{
    public static class IssueMapping
    {
        public static IssueViewModel ToViewModel(this Issue i) => new IssueViewModel
        {
            Id = i.Id,
            User = i.User,
            IssueTS = i.IssueTS,
            Category = i.Category,
            LongDescr = i.LongDescr,
            Status = i.Status,
            SolveTS = i.SolveTS,
            SolveDescr = i.SolveDescr,
            SolveUser = i.SolveUser
        };

        public static Issue ToModel(this IssueViewModel i) => new Issue
        {
            Id = i.Id,
            User = i.User,
            IssueTS = i.IssueTS,
            Category = i.Category,
            LongDescr = i.LongDescr,
            Status = i.Status,
            SolveTS = i.SolveTS,
            SolveDescr = i.SolveDescr,
            SolveUser = i.SolveUser
        };

    }
}
