using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;
using FinDesk.Domain.Entities;

namespace FinDesk2.Data
{
    public class TestData
    {
        public static List<Issue> Issues { get; } = new List<Issue>
        {
            new Issue
            {
                Id = 1,
                User = "Ivanov",
                IssueTS = DateTime.Now,
                IssueType="Bug",
                Category = "Sun",
                LongDescr = "Не могу зайти в SUN",
                Status = "New",
                SolveTS = DateTime.Now,
                SolveDescr = "",
                SolveUser = "",
            },
            new Issue
            {
                Id = 2,
                User = "Lukashina",
                IssueTS = DateTime.Now,
                IssueType="Bug",
                Category = "1c Duty",
                LongDescr = "Не работает отчет",
                Status = "InProcess",
                SolveTS = DateTime.Now,
                SolveDescr = "",
                SolveUser = "",
            },
            new Issue
            {
                Id = 3,
                User = "Lipodat",
                IssueTS = DateTime.Now,
                IssueType="Bug",
                Category = "1c Cash",
                LongDescr = "Не может зайти в 1с",
                Status = "Solved",
                SolveTS = DateTime.Now,
                SolveDescr = "",
                SolveUser = "",
            },

        };

        public static IEnumerable<BaseIssue> BaseIssues { get; } = new []
        {
            new BaseIssue
            {
                Id = 1,
                User = "Ivanov",
                IssueTS = DateTime.Now,
                IssueTypeId=1,
                CategoryId = 1,
                LongDescr = "Не могу зайти в SUN",
                IssueStatusId = 1,
                SolveTS = DateTime.Now,
                SolveDescr = "",
                SolveUser = "",
            },
            new BaseIssue
            {
                Id = 2,
                User = "Lukashina",
                IssueTS = DateTime.Now,
                IssueTypeId=1,
                CategoryId = 2,
                LongDescr = "Не работает отчет",
                IssueStatusId = 2,
                SolveTS = DateTime.Now,
                SolveDescr = "",
                SolveUser = "",
            },
            new BaseIssue
            {
                Id = 3,
                User = "Lipodat",
                IssueTS = DateTime.Now,
                IssueTypeId=1,
                CategoryId = 2,
                LongDescr = "Не может зайти в 1с",
                IssueStatusId = 3,
                SolveTS = DateTime.Now,
                SolveDescr = "",
                SolveUser = "",
            },

        };
        public static IEnumerable<Category> Categories { get; } = new[]
            {
            new Category{Id = 1, Name = "1C", Order = 0},
            new Category{Id = 2, Name = "InforSystems", Order = 1},
            new Category{Id = 3, Name = "Other", Order = 2},
            new Category{Id = 4, Name = "1CCash", Order = 3, ParentId = 1 },
            new Category{Id = 5, Name = "Vision", Order = 4, ParentId = 2 },
            new Category{Id = 6, Name = "Vision", Order = 5, ParentId = 2 },
            };

        public static IEnumerable<IssueStatus> IssueStatuses { get; } = new[]
            {
            new IssueStatus{Id = 1, Name = "New", Order = 0 },
            new IssueStatus{Id = 2, Name = "InProcess", Order = 1 },
            new IssueStatus{Id = 3, Name = "Done", Order = 2 },
            new IssueStatus{Id = 4, Name = "Canceled", Order = 3 },
            };

        public static IEnumerable<IssueType> IssueTypes { get; } = new[]
            {
            new IssueType{Id = 1, Name = "Bug", Order = 0 },
            new IssueType{Id = 2, Name = "Task", Order = 1 },
            new IssueType{Id = 3, Name = "Project", Order = 2 },
            };


        public static IEnumerable<SimpleIssue> SimpleIssues { get; } = new[]
        {
            new SimpleIssue
            {
                Id = 1,
                User = "arianov",
                IssueType="Bug",
                LongDescr = "Не могу зайти в SUN",
                SolveDescr = ""
            },
            new SimpleIssue
            {
                Id = 2,
                User = "elukashina",
                IssueType="Task",
                LongDescr = "Доработать отчет SUN",
                SolveDescr = ""
            },
            new SimpleIssue
            {
                Id = 3,
                IssueType="Task",
                User = "olipodat",
                LongDescr = "Добавить данные в справочник 1С Cash",
                SolveDescr = ""
            },
            new SimpleIssue
            {
                Id = 4,
                IssueType="Project",
                User = "ansuvorova",
                LongDescr = "Разработать систему занесения данных в SUN",
                SolveDescr = ""
            },

        };


    }

}
