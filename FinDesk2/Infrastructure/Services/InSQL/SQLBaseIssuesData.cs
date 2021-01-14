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

        /// <summary>
        /// Реаллизация получения Issue из SQL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseIssue GetIssueById(int id) => _db.BaseIssues
            .Include(p => p.Category)
            .Include(p => p.IssueStatus)
            .Include(p => p.IssueType)
            .FirstOrDefault(p => p.Id == id);

        public async Task<BaseIssue> CreateBaseIssueAsync(BaseIssue baseIssue)
        {
                //ПШ L8 1.43 Начинаем Транзакцию
                //using (var transaction = _db.Database.BeginTransaction())
                //{
                //ПШ L8 1.45 Формируем новый заказ
                var NewBaseIssue = new BaseIssue
                {
                    //User = baseIssue.User,

                    //IssueTS = baseIssue.IssueTS,
                    //LongDescr = baseIssue.LongDescr,

                    //CategoryId = baseIssue.CategoryId,
                    //IssueStatusId = baseIssue.IssueStatusId,
                    //IssueTypeId = baseIssue.IssueTypeId,

                    //SolveDescr = baseIssue.SolveDescr,
                    //SolveTS = baseIssue.SolveTS,
                    //SolveUser = baseIssue.SolveUser

                    User = "arivanov",

                    IssueTS = DateTime.Now,
                    LongDescr = "Test1",

                    CategoryId = 1,
                    IssueStatusId = 1,
                    IssueTypeId = 1,

                    SolveDescr = "",
                    SolveTS = DateTime.Now,
                    SolveUser = ""

                };

                await _db.BaseIssues.AddAsync(NewBaseIssue);

                await _db.SaveChangesAsync();
                //await transaction.CommitAsync();

                return NewBaseIssue;
            //}
        }

    }
}