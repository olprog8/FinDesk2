using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;
using FinDesk.Domain.Entities;

namespace FinDesk2.Infrastructure.Interfaces
{
    public interface ISimpleIssuesData
    {
        IEnumerable<SimpleIssue> GetAll();

        SimpleIssue GetById(int id);

        void Add(SimpleIssue Issue);

        void Edit(int id, SimpleIssue Issue);

        bool Delete(int id);

        void SaveChanges();
    }
}
