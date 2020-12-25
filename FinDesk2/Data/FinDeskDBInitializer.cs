using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk.DAL.Context;

using Microsoft.EntityFrameworkCore;


namespace FinDesk2.Data
{
    public class FinDeskDBInitializer
    {
        private readonly FinDeskDB _db;

        public FinDeskDBInitializer(FinDeskDB db)
        {
            _db = db;
        }
        public void Initialize() => InitializeAsync().Wait();

        public async Task InitializeAsync() 
        {
            var db = _db.Database;

            //if(await db.EnsureCreatedAsync().ConfigureAwait(false))
            //{
            //    if (await db.EnsureCreatedAsync().ConfigureAwait(false))
            //        throw new InvalidOperationException("Не удалось создать БД");
            //}

            await db.MigrateAsync().ConfigureAwait(false);

            if (await _db.BaseIssues.AnyAsync()) return;

            using (var transaction  = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                await _db.Categories.AddRangeAsync(TestData.Categories).ConfigureAwait(false);

                //В один момент времени в состоянии с выключенным ID может находиться одна таблица
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Categories] ON");
                await _db.SaveChangesAsync().ConfigureAwait(false);
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Categories] OFF");

                await transaction.CommitAsync().ConfigureAwait(false);
            }

            using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                await _db.IssueStatuses.AddRangeAsync(TestData.IssueStatuses).ConfigureAwait(false);

                //В один момент времени в состоянии с выключенным ID может находиться одна таблица
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[IssueStatuses] ON");
                await _db.SaveChangesAsync().ConfigureAwait(false);
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[IssueStatuses] OFF");

                await transaction.CommitAsync().ConfigureAwait(false);
            }

            using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                await _db.IssueTypes.AddRangeAsync(TestData.IssueTypes).ConfigureAwait(false);

                //В один момент времени в состоянии с выключенным ID может находиться одна таблица
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[IssueTypes] ON");
                await _db.SaveChangesAsync().ConfigureAwait(false);
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[IssueTypes] OFF");

                await transaction.CommitAsync().ConfigureAwait(false);
            }

            using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                await _db.BaseIssues.AddRangeAsync(TestData.BaseIssues).ConfigureAwait(false);

                //В один момент времени в состоянии с выключенным ID может находиться одна таблица
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BaseIssues] ON");
                await _db.SaveChangesAsync().ConfigureAwait(false);
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BaseIssues] OFF");

                await transaction.CommitAsync().ConfigureAwait(false);
            }

        }
    }
}
