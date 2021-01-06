using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using FinDesk.Domain.Identity;

using FinDesk2.Infrastructure.Interfaces;


namespace FinDesk2.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class BaseIssuesController : Controller
    {
        private readonly IBaseIssuesData _BaseIssuesData;
        public BaseIssuesController(IBaseIssuesData BaseIssuesData) { _BaseIssuesData = BaseIssuesData; }
        public IActionResult Index() => View(_BaseIssuesData.GetBaseIssues());
    }
}
