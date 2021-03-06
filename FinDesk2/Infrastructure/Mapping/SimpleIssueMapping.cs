﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;
using FinDesk2.ViewModels;

using FinDesk.Domain.Entities;

namespace FinDesk2.Infrastructure.Mapping
{
    public static class SimpleIssueMapping
    {
        public static SimpleIssueViewModel ToViewModel(this SimpleIssue i) => new SimpleIssueViewModel
        {
            Id = i.Id,
            User = i.User,
            IssueTS = i.IssueTS,
            IssueType = i.IssueType,
            Category = i.Category,
            LongDescr = i.LongDescr,
            SolveDescr = i.SolveDescr,
            IssueStatus = i.IssueStatus
        };

        public static SimpleIssue ToModel(this SimpleIssueViewModel i) => new SimpleIssue
        {
            Id = i.Id,
            User = i.User,
            IssueTS = i.IssueTS,
            IssueType = i.IssueType,
            Category = i.Category,
            LongDescr = i.LongDescr,
            SolveDescr = i.SolveDescr,
            IssueStatus = i.IssueStatus
        };

    }
}
