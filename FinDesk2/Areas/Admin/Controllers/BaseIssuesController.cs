using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using FinDesk.Domain.Identity;


namespace FinDesk2.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class BaseIssuesController : Controller
    {
        public IActionResult Index() => View();
    }
}
