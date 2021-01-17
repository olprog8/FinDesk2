using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using FinDesk2.Data;
using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Models;
using FinDesk2.Infrastructure.Mapping;
using FinDesk2.ViewModels;

using Microsoft.AspNetCore.Authorization;

using FinDesk.Domain.Identity;

namespace FinDesk2.Controllers
{
    [Authorize]
    public class SimpleIssueController : Controller
    {
        private readonly ISimpleIssuesData _IssuesData;

        public SimpleIssueController(ISimpleIssuesData IssuesData) => _IssuesData = IssuesData;

        public IActionResult Index() => View(_IssuesData.GetAll().Select(e => e.ToViewModel()));

        public IActionResult Details(int Id)
        {
            var issue = _IssuesData.GetById(Id);

            if (issue is null)
                return NotFound();

            return View(issue.ToViewModel());
        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Create()
        {
            var issueViewModel = new SimpleIssueViewModel();
            //issueViewModel.IssueTS = DateTime.Now;

            return View(issueViewModel);

        }

        [Authorize(Roles = Role.Administrator)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(SimpleIssueViewModel SimpleIssue)
        {
            if (SimpleIssue is null)
                throw new ArgumentNullException(nameof(SimpleIssue));

            if (!ModelState.IsValid)
                return View(SimpleIssue);

            _IssuesData.Add(SimpleIssue.ToModel());
            _IssuesData.SaveChanges();

            return RedirectToAction("Index");

        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new SimpleIssueViewModel());

            if (Id < 0)
                return BadRequest();

            var issue = _IssuesData.GetById((int)Id);

            if (issue is null)
                return NotFound();

            return View(issue.ToViewModel());
        }

        //Ответная часть. То, что происходит после нажатия кнопки Сохранить. В качестве параметра обычно указывается ViewModel
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(SimpleIssueViewModel SimpleIssue)
        {
            if (SimpleIssue is null)
                throw new ArgumentNullException(nameof(SimpleIssue));

            if (!ModelState.IsValid)
                return View(SimpleIssue);

            var id = SimpleIssue.Id;
            if (id == 0)
                _IssuesData.Add(SimpleIssue.ToModel());
            else
                _IssuesData.Edit(id, SimpleIssue.ToModel());

            _IssuesData.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var issue = _IssuesData.GetById(id);

            if (issue is null)
                return NotFound();

            return View(issue.ToViewModel());

        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            _IssuesData.Delete(id);
            _IssuesData.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
