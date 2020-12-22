using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using FinDesk2.Data;
using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Models;

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

        public IActionResult Create()
        {
            return View(new Issue());

        }

        [HttpPost]
        public IActionResult Create(Issue Issue)
        {
            if (Issue is null)
                throw new ArgumentNullException(nameof(Issue));

            if (!ModelState.IsValid)
                return View(Issue);

            _IssuesData.Add(Issue);
            _IssuesData.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new Issue());

            if (Id < 0)
                return BadRequest();

            var issue = _IssuesData.GetById((int)Id);

            if (issue is null)
                return NotFound();
            
            return View(issue);
        }

        //Ответная часть. То, что происходит после нажатия кнопки Сохранить. В качестве параметра обычно указывается ViewModel
        [HttpPost]
        public IActionResult Edit(Issue Issue)
        {
            if (Issue is null)
                throw new ArgumentNullException(nameof(Issue));

            if (!ModelState.IsValid)
                return View(Issue);

            var id = Issue.Id;
            if (id == 0)
                _IssuesData.Add(Issue);
            else
                _IssuesData.Edit(id, Issue);

            _IssuesData.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}
