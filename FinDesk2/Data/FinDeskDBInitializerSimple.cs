using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk.DAL.Context;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;

using FinDesk.Domain.Identity;


namespace FinDesk2.Data
{
    public class FinDeskDBInitializerSimple
    {
        private readonly FinDeskDB _db;
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleManager;

        public FinDeskDBInitializerSimple(FinDeskDB db, UserManager<User> UserManager, RoleManager<Role> RoleManager)
        {
            _db = db;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
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

            //Инициализация данных в БД
            await InitializeIdentityAsync().ConfigureAwait(false);

            await InitializeSimpleIssuesAsync().ConfigureAwait(false);

        }

        private async Task InitializeSimpleIssuesAsync()
        {
            if (await _db.SimpleIssues.AnyAsync()) return;

            var db = _db.Database;

            using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
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
                await _db.SimpleIssues.AddRangeAsync(TestData.SimpleIssues).ConfigureAwait(false);

                //В один момент времени в состоянии с выключенным ID может находиться одна таблица
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[SimpleIssues] ON");
                await _db.SaveChangesAsync().ConfigureAwait(false);
                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[SimpleIssues] OFF");

                await transaction.CommitAsync().ConfigureAwait(false);
            }

        }



        //Инициализация пользователя и ролей
        private async Task InitializeIdentityAsync()
        {
            if (!await _RoleManager.RoleExistsAsync(Role.Administrator))
                await _RoleManager.CreateAsync(new Role { Name = Role.Administrator });

            if (!await _RoleManager.RoleExistsAsync(Role.User))
                await _RoleManager.CreateAsync(new Role { Name = Role.User });

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User
                {
                    UserName = User.Administrator,
                    //Email = "admin@server.com"
                };

                var create_result = await _UserManager.CreateAsync(admin, User.AdminDefaultPassword);

                //Role.Administrator - это константа в классе Role
                if (create_result.Succeeded)
                    await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                else
                {
                    var errors = create_result.Errors.Select(error => error.Description);
                    throw new InvalidOperationException($"Ошибка при создании пользователя - Администратора: {string.Join(',', errors)}");
                }
            }

        }


    }
}
