using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Infrastructure.Mapping;

namespace FinDesk2.Controllers
{
    public class BaseIssueController : Controller
    {
        private readonly IBaseIssuesData _BaseIssueData;

        public BaseIssueController(IBaseIssuesData BaseIssueData) => _BaseIssueData = BaseIssueData;


        public IActionResult BaseIssues()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            var BaseIssue = _BaseIssueData.GetIssueById(id);

            if (BaseIssue is null)
                return NotFound();

            return View(BaseIssue.ToViewModel());
        }
    }
}
