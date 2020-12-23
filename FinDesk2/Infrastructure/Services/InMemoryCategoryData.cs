using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Models;
using FinDesk2.Data;
using FinDesk.Domain.Entities;

namespace FinDesk2.Infrastructure.Services
{
    public class InMemoryCategoryData : ICategoryData
    {
        public IEnumerable<Category> GetCategories() => TestData.Categories;
        
        public IEnumerable<IssueStatus> GetIssueStatuses() => TestData.IssueStatuses;

        public IEnumerable<IssueType> GetIssueTypes() => TestData.IssueTypes;

        public IEnumerable<BaseIssue> GetBaseIssues(BaseIssueFilter Filter = null) 
        {
            var query = TestData.BaseIssues;
            if (Filter?.CategoryId != null)
                query = query.Where(BaseIssue => BaseIssue.CategoryId == Filter.CategoryId);

            if (Filter?.IssueTypeId != null)
                query = query.Where(BaseIssue => BaseIssue.IssueTypeId == Filter.IssueTypeId);

            if (Filter?.IssueStatusId != null)
                query = query.Where(BaseIssue => BaseIssue.IssueStatusId == Filter.IssueStatusId);

            return query;
        }
    }
}
