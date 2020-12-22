using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using FinDesk2.Data;

namespace FinDesk2.Controllers
{
    public class IssueController : Controller
    {
        public IActionResult Index() => View(TestData.Issues);

        public IActionResult Details(int Id)
        {
            var issue = TestData.Issues.FirstOrDefault(i => i.Id == Id);

            if (issue is null)
                return NotFound();

            return View(issue);

        }
    }
}
