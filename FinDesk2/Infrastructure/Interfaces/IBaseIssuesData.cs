using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk.Domain.Entities;

namespace FinDesk2.Infrastructure.Interfaces
{
    public interface IBaseIssuesData
    {
        /// <summary>
        /// Получить все категории
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategories();
        IEnumerable<IssueStatus> GetIssueStatuses();
        IEnumerable<IssueType> GetIssueTypes();

        IEnumerable<BaseIssue> GetBaseIssues(BaseIssueFilter Filter = null);



    }
}
