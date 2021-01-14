using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using FinDesk.Domain.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using FinDesk.Domain.Identity;

using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Logging.Console;



namespace FinDesk.DAL.Context
{
    public class FinDeskDB: IdentityDbContext<User, Role, string>
    {

        public DbSet<BaseIssue> BaseIssues { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<IssueType> IssueTypes { get; set; }

        public DbSet<IssueStatus> IssueStatuses { get; set; }
        public FinDeskDB(DbContextOptions<FinDeskDB> Options) : base(Options)
        {
            //var loggerFactory = LoggerFactory.Create(builder =>
            //{
                //builder.AddFilter("Microsoft", LogLevel.Warning)
                //       .AddFilter("System", LogLevel.Warning)
                //       .AddFilter("SampleApp.Program", LogLevel.Debug)
                //       .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Information)
                //       .AddConsole();
                //builder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Information)
                //       .AddConsole();
            //});
        }

    }
}
