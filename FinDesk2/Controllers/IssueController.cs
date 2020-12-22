using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FinDesk2.Models;

namespace FinDesk2.Controllers
{
    public class IssueController : Controller
    {
        private static readonly List<Issue> __Issues = new List<Issue>
        {
            new Issue
            {
                Id = 1,
                User = "Ivanov",
                IssueTS = DateTime.Now,
                Category = "Sun",
                LongDescr = "Не могу зайти в SUN",
                Status = "New",
            },
            new Issue
            {
                Id = 2,
                User = "Lukashina",
                IssueTS = DateTime.Now,
                Category = "1c Duty",
                LongDescr = "Не работает отчет",
                Status = "InProcess"
            },
            new Issue
            {
                Id = 3,
                User = "Lipodat",
                IssueTS = DateTime.Now,
                Category = "1c Cash",
                LongDescr = "Не может зайти в 1с",
                Status = "Solved"
            },

        };
        public IActionResult Index() => View(__Issues);

        public IActionResult Details(int Id)
        {
            var issue = __Issues.FirstOrDefault(i => i.Id == Id);

            if (issue is null)
                return NotFound();

            return View(issue);

        }
    }
}
