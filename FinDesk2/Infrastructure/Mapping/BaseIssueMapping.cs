using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;
using FinDesk2.ViewModels;

using FinDesk.Domain.Entities;

namespace FinDesk2.Infrastructure.Mapping
{
    public static class BaseIssueMapping
    {
        public static BaseIssueViewModel ToViewModel(this BaseIssue i) => new BaseIssueViewModel
        {
            Id = i.Id,
            User = i.User,
            IssueTS = i.IssueTS,
            IssueTypeId = i.IssueTypeId,
            CategoryId = i.CategoryId,
            LongDescr = i.LongDescr,
            IssueStatusId = i.IssueStatusId,
            SolveTS = i.SolveTS,
            SolveDescr = i.SolveDescr,
            SolveUser = i.SolveUser
        };

        //Реализация преобразования во BaseIssueViewModel
        public static IEnumerable<BaseIssueViewModel> ToViewModel(this IEnumerable<BaseIssue> i) => i.Select(ToViewModel);

        public static BaseIssue ToModel(this BaseIssueViewModel i) => new BaseIssue
        {
            Id = i.Id,
            User = i.User,
            IssueTS = i.IssueTS,
            IssueTypeId = i.IssueTypeId,
            CategoryId = i.CategoryId,
            LongDescr = i.LongDescr,
            IssueStatusId = i.IssueStatusId,
            SolveTS = i.SolveTS,
            SolveDescr = i.SolveDescr,
            SolveUser = i.SolveUser
        };

    }
}
