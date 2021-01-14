using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Models;
using FinDesk2.Data;


using FinDesk.DAL.Context;
using FinDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;



namespace FinDesk2.Infrastructure.Services.InSQL
{
    public class SQLSimpleIssuesData : ISimpleIssuesData
    {
        private readonly FinDeskDB _db;

        public SQLSimpleIssuesData(FinDeskDB db) => _db = db;


        public void Add(SimpleIssue SimpleIssue)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                //ПШ L8 1.45 Формируем новый заказ
                var simpleIssue = new SimpleIssue
                {
                    User = "Fantomas",
                    IssueType = SimpleIssue.IssueType,
                    LongDescr = SimpleIssue.LongDescr,
                    SolveDescr = SimpleIssue.SolveDescr
                };

                _db.SimpleIssues.Add(simpleIssue);

                _db.SaveChanges();
                transaction.CommitAsync();

            }
        }
            public bool Delete(int id)
        {
            var db_simpleIssue = GetById(id);
            if (db_simpleIssue is null)
                return false;

            int numberOfDeleted = _db.Database.ExecuteSqlRaw("DELETE FROM SimpleIssues WHERE Name={0}", id);

            if (numberOfDeleted > 0)
                return true;
            else
                return false;
        }

        public void Edit(int id, SimpleIssue SimpleIssue)
        {
            if(SimpleIssue is null)
                throw new ArgumentOutOfRangeException(nameof(SimpleIssue));


            var db_simpleIssue = _db.SimpleIssues
            .FirstOrDefault(p => p.Id == id);

            if(db_simpleIssue is null)
                throw new InvalidOperationException($"Инцидент с id:{db_simpleIssue.Id} в базе данных не найден!");

            db_simpleIssue.IssueType = SimpleIssue.IssueType;
            db_simpleIssue.User = SimpleIssue.User;
            db_simpleIssue.LongDescr= SimpleIssue.LongDescr;
            db_simpleIssue.SolveDescr = SimpleIssue.SolveDescr;

        }

        public IEnumerable<SimpleIssue> GetAll() => _db.SimpleIssues
            .AsEnumerable();

        public SimpleIssue GetById(int id) => _db.SimpleIssues
            .FirstOrDefault(p => p.Id == id);
    

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
