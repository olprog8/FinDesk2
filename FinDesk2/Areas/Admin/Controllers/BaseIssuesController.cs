using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using FinDesk.Domain.Identity;

using FinDesk2.Infrastructure.Interfaces;

using FinDesk.Domain.Entities;

namespace FinDesk2.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class BaseIssuesController : Controller
    {
        private readonly IBaseIssuesData _BaseIssuesData;
        public BaseIssuesController(IBaseIssuesData BaseIssuesData) { _BaseIssuesData = BaseIssuesData; }
        public IActionResult Index() => View(_BaseIssuesData.GetBaseIssues());

        public IActionResult Edit(int? id)
        {
            var baseIssue = id is null ? new BaseIssue() : _BaseIssuesData.GetIssueById((int)id);


            if (baseIssue is null)
                return NotFound();
                
                return View(baseIssue);
        }

        public IActionResult Delete(int id) {
      
            var baseIssue = _BaseIssuesData.GetIssueById((int)id);


            if (baseIssue is null)
                return NotFound();

            return View(baseIssue);
        }

        [HttpPost, ValidateAntiForgeryToken,ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(int id) => RedirectToAction(nameof(Index));
    }

    
}
