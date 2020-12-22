using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;

namespace FinDesk2.Data
{
    public class TestData
    {
        public static List<Issue> Issues { get;  } = new List<Issue>
        {
            new Issue
            {
                Id = 1,
                User = "Ivanov",
                IssueTS = DateTime.Now,
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
                Category = "1c Cash",
                LongDescr = "Не может зайти в 1с",
                Status = "Solved",
                SolveTS = DateTime.Now,
                SolveDescr = "",
                SolveUser = "",
            },

        };
    }
}
