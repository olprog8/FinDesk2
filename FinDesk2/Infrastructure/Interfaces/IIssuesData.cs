using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;

namespace FinDesk2.Infrastructure.Interfaces
{
    public interface IIssuesData
    {
        IEnumerable<Issue> GetAll();

        Issue GetById(int id);

        void Add(Issue Issue);

        void Edit(int id, Issue Issue);

        bool Delete(int id);

        void SaveChanges();
    }
}
