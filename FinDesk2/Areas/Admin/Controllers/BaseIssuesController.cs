using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using FinDesk.Domain.Identity;

using FinDesk2.Infrastructure.Interfaces;

using FinDesk.Domain.Entities;

using Microsoft.AspNetCore.Mvc.Rendering;

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

            var issueStatuses = _BaseIssuesData.GetIssueStatuses().ToArray();
            var issueCategories = _BaseIssuesData.GetCategories().Where(c => c.ParentCategory != null).ToArray();
            var issueTypes = _BaseIssuesData.GetIssueTypes().ToArray();

            ViewBag.IssueStatusesSL = new SelectList(issueStatuses, "Id", "Name");
            ViewBag.IssueGategoriesSL = new SelectList(issueCategories, "Id", "Name");
            ViewBag.IssueTypesSL = new SelectList(issueTypes, "Id", "Name");

            if (baseIssue is null)
                return NotFound();
                
                return View(baseIssue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(BaseIssue baseIssue)
        {
            if (baseIssue is null)
                throw new System.ArgumentNullException(nameof(baseIssue));

            //ПШ Делаем проверку модели, если не соответствует отправляем пользователю обратно
            if (!ModelState.IsValid)
                return View(baseIssue);

            //var id = baseIssue.Id;
            //ПШ если Id нулевой, то это новый сотрудник и мы его добавляем, иначе редактируем
            //if (id != 0)
                _BaseIssuesData.CreateBaseIssueAsync(baseIssue);

            return RedirectToAction("Index");

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
