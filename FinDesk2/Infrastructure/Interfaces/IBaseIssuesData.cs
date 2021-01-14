using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk.Domain.Entities;

using FinDesk2.ViewModels;

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

        /// <summary>
        /// Получить Запрос по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор требуемого Запроса</param>
        /// <returns>Запрос(Issue)</returns>
        BaseIssue GetIssueById(int id);

        Task<BaseIssue> CreateBaseIssueAsync(BaseIssue baseIssue);

    }
}
