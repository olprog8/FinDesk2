﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using FinDesk2.Data;
using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Models;
using FinDesk2.Infrastructure.Mapping;
using FinDesk2.ViewModels;

namespace FinDesk2.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssuesData _IssuesData;

        public IssueController(IIssuesData IssuesData) => _IssuesData = IssuesData;

        public IActionResult Index() => View(_IssuesData.GetAll().Select(e=>e.ToViewModel()));

        public IActionResult Details(int Id)
        {
            var issue = _IssuesData.GetById(Id);

            if (issue is null)
                return NotFound();

            return View(issue.ToViewModel());
        }

        public IActionResult Create()
        {
            return View(new IssueViewModel());

        }

        [HttpPost]
        public IActionResult Create(IssueViewModel Issue)
        {
            if (Issue is null)
                throw new ArgumentNullException(nameof(Issue));

            if (!ModelState.IsValid)
                return View(Issue);

            _IssuesData.Add(Issue.ToModel());
            _IssuesData.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new IssueViewModel());

            if (Id < 0)
                return BadRequest();

            var issue = _IssuesData.GetById((int)Id);

            if (issue is null)
                return NotFound();
            
            return View(issue.ToViewModel());
        }

        //Ответная часть. То, что происходит после нажатия кнопки Сохранить. В качестве параметра обычно указывается ViewModel
        [HttpPost]
        public IActionResult Edit(IssueViewModel Issue)
        {
            if (Issue is null)
                throw new ArgumentNullException(nameof(Issue));

            if (!ModelState.IsValid)
                return View(Issue);

            var id = Issue.Id;
            if (id == 0)
                _IssuesData.Add(Issue.ToModel());
            else
                _IssuesData.Edit(id, Issue.ToModel());

            _IssuesData.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var issue = _IssuesData.GetById(id);

            if (issue is null)
                return NotFound();
            
            return View(issue.ToViewModel());

        }

        public IActionResult DeleteConfirmed(int id)
        {
            _IssuesData.Delete(id);
            _IssuesData.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
