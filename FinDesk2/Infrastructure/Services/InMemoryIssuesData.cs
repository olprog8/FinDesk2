using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Models;
using FinDesk2.Data;

namespace FinDesk2.Infrastructure.Services
{
    public class InMemoryIssuesData : IIssuesData
    {
        private readonly List<Issue> _Issues = TestData.Issues;

        public IEnumerable<Issue> GetAll() => _Issues;


        public Issue GetById(int id) => _Issues.FirstOrDefault(e => e.Id == id);

        public void Add(Issue Issue)
        {
            if (Issue is null)
                throw new ArgumentNullException(nameof(Issue));

            if (_Issues.Contains(Issue)) return;

            Issue.Id = _Issues.Count == 0 ? 1 : _Issues.Max(e => e.Id) + 1;
            _Issues.Add(Issue);
        }

        public bool Delete(int id)
        {
            var db_issue = GetById(id);
            if (db_issue is null)
                return false;

            return _Issues.Remove(db_issue);

        }

        public void Edit(int id, Issue Issue)
        {
            if (Issue is null)
                throw new ArgumentNullException(nameof(Issue));

            if (_Issues.Contains(Issue)) return;

            var db_issue = GetById(id);
            if (db_issue is null)
                return;

            db_issue.IssueTS = Issue.IssueTS;
            db_issue.User = Issue.User;
            db_issue.Category = Issue.Category;
            db_issue.LongDescr = Issue.LongDescr;
            db_issue.Status = Issue.Status;
            db_issue.SolveDescr = Issue.SolveDescr;
            db_issue.SolveTS = Issue.SolveTS;

        }


        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
