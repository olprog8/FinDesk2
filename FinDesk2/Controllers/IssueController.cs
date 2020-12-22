using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using FinDesk2.Data;
using FinDesk2.Infrastructure.Interfaces;

namespace FinDesk2.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssuesData _IssuesData;

        public IssueController(IIssuesData IssuesData) => _IssuesData = IssuesData;

        public IActionResult Index() => View(_IssuesData.GetAll());

        public IActionResult Details(int Id)
        {
            var issue = _IssuesData.GetById(Id);

            if (issue is null)
                return NotFound();

            return View(issue);

        }
    }
}
