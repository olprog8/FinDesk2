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
            new Category{Id = 1, Name = "InforSystems", Order = 0},
            new Category{Id = 2, Name = "1C", Order = 1},
            new Category{Id = 3, Name = "Other", Order = 2},
            new Category{Id = 4, Name = "SunSystems 6.X", Order = 3},
            new Category{Id = 5, Name = "Vision", Order = 4},
            new Category{Id = 6, Name = "Collect", Order = 5},
            new Category{Id = 7, Name = "1C Cash", Order = 6, ParentId = 2 },
            new Category{Id = 8, Name = "1C Trade Exp", Order = 7, ParentId = 2 },
            new Category{Id = 9, Name = "1C Trade Int", Order = 8, ParentId = 2 },
            new Category{Id = 10, Name = "1C DutyBilling Exp", Order = 9, ParentId = 2 },
            new Category{Id = 11, Name = "1C DutyBilling Int", Order = 10, ParentId = 2 },
            new Category{Id = 12, Name = "1C Edo Clients", Order = 11, ParentId = 2 },
            new Category{Id = 13, Name = "1C Edo Suppliers", Order = 12, ParentId = 2 },
            new Category{Id = 14, Name = "Excel Macro", Order = 13, ParentId = 3 },

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
            new IssueType{Id = 1, Name = "Bug", Order = 0, NameRus="Проблема", ChangeUser="Admin", ChangeDt= DateTime.Now, Descr01="Bug (Проблема)"},
            new IssueType{Id = 2, Name = "Change", Order = 1, NameRus="Изменение", ChangeUser="Admin", ChangeDt= DateTime.Now, Descr01="Change (Изменение)"},
            new IssueType{Id = 3, Name = "Project", Order = 2, NameRus="Проект", ChangeUser="Admin", ChangeDt= DateTime.Now, Descr01="Project (Проект)"},
            };


        public static IEnumerable<SimpleIssue> SimpleIssues { get; } = new[]
        {
            new SimpleIssue
            {
                Id = 1,
                User = "arivanov",
                IssueTS = DateTime.Now.AddDays(-10).AddHours(-1).AddMinutes(-10),
                IssueType="Bug",
                Category="",
                LongDescr = "Не могу зайти в SUN",
                IssueStatus="",
                SolveDescr = ""
            },
            new SimpleIssue
            {
                Id = 2,
                User = "elukashi",
                IssueTS = DateTime.Now.AddDays(-8).AddHours(-2).AddMinutes(-5),
                IssueType="Task",
                Category="",
                LongDescr = "Доработать отчет SUN",
                IssueStatus="",
                SolveDescr = ""
            },
            new SimpleIssue
            {
                Id = 3,
                IssueType="Task",
                Category="",
                IssueTS = DateTime.Now.AddDays(-6).AddHours(-1).AddMinutes(-3),
                User = "olipodat",
                LongDescr = "Добавить данные в справочник 1С Cash",
                IssueStatus="",
                SolveDescr = ""
            },
            new SimpleIssue
            {
                Id = 4,
                IssueType="Project",
                Category="",
                IssueTS = DateTime.Now.AddDays(-30).AddHours(-1).AddMinutes(-3),
                User = "ansuvorova",
                LongDescr = "Разработать систему занесения данных в SUN",
                IssueStatus="",
                SolveDescr = ""
            },

        };


    }

}
