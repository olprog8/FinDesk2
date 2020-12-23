using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinDesk2.Controllers
{
    public class BaseIssueController : Controller
    {
        public IActionResult BaseIssues()
        {
            return View();
        }


        public IActionResult Details()
        {
            return View();
        }
    }
}
