using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk.DAL.Context;
using FinDesk.Domain.Entities;
using FinDesk2.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FinDesk2.Infrastructure.Services.InSQL
{
    public class SQLBaseIssuesData : IBaseIssuesData
    {
        private readonly FinDeskDB _db;

        public SQLBaseIssuesData(FinDeskDB db) => _db = db;

        public IEnumerable<Category> GetCategories() => _db.Categories
            .Include(Category => Category.BaseIssues)
            .AsEnumerable();


        public IEnumerable<IssueStatus> GetIssueStatuses() => _db.IssueStatuses
            .Include(IssueStatus => IssueStatus.BaseIssues)
            .AsEnumerable();

        public IEnumerable<IssueType> GetIssueTypes() => _db.IssueTypes
            .Include(IssueType => IssueType.BaseIssues)
            .AsEnumerable();

        public IEnumerable<BaseIssue> GetBaseIssues(BaseIssueFilter Filter = null)
        {
            IQueryable<BaseIssue> query = _db.BaseIssues;

            if (Filter?.CategoryId != null)
                query = query.Where(BaseIssue => BaseIssue.CategoryId == Filter.CategoryId);

            if (Filter?.IssueTypeId != null)
                query = query.Where(BaseIssue => BaseIssue.IssueTypeId == Filter.IssueTypeId);

            if (Filter?.IssueStatusId != null)
                query = query.Where(BaseIssue => BaseIssue.IssueStatusId == Filter.IssueStatusId);

            return query.AsEnumerable();
        }
    }
}
