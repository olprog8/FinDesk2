using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinDesk2.Models;

namespace FinDesk2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly List<Issue> __Issues = new List<Issue>
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


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TestPage()
        {
            return View();
        }

        public IActionResult Issues() 
        {
            return View(__Issues);
        }

        public IActionResult Issue(int Id)
        {
            var issue = __Issues.FirstOrDefault(i => i.Id == Id);

            if (issue is null)
                return NotFound();

            return View(issue);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
