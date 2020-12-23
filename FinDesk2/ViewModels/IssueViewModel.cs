using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FinDesk2.ViewModels
{
    public class IssueViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Заявитель")]
        [Required(ErrorMessage = "<Заявитель> является обязательным")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символов")]
        [RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Ошибка формата имени либо кириллица, либо латиница")]
        public string User { get; set; }

        [Display(Name = "Дата Создания")]
        [Required(ErrorMessage = "<Дата Создания> является обязательным")]
        public DateTime IssueTS { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "<Категория> является обязательным")]
        public string Category { get; set; }
        
        [Display(Name = "Описание проблемы")]
        [Required(ErrorMessage = "<Описание> является обязательным")]
        [MinLength(10, ErrorMessage = "Минимальная длина 10 символов")]
        public string LongDescr { get; set; }

        [Display(Name = "Статус")]
        [Required(ErrorMessage = "<Статус> является обязательным")]
        public string Status { get; set; }

        [Display(Name = "Дата решения")]
        public DateTime SolveTS { get; set; }

        [Display(Name = "Описание решения")]
        public string SolveDescr { get; set; }

        [Display(Name = "Сотрудник")]
        [RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Ошибка формата имени либо кириллица, либо латиница")]
        public string SolveUser { get; set; }

    }
}
