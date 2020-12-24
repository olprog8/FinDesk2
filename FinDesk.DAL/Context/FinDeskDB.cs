using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using FinDesk.Domain.Entities;

namespace FinDesk.DAL.Context
{
    public class FinDeskDB: DbContext
    {
        public DbSet<BaseIssue> BaseIssues { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<IssueType> IssueTypes { get; set; }

        public DbSet<IssueStatus> IssueStatuses { get; set; }
        public FinDeskDB(DbContextOptions<FinDeskDB> Options) : base(Options)
        {}


    }
}
