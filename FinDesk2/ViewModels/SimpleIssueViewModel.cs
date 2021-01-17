using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FinDesk2.ViewModels
{
    public class SimpleIssueViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Заявитель")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "<Заявитель> является обязательным")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символов")]
        //[RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Ошибка формата имени либо кириллица, либо латиница")]
        public string User { get; set; }

        [Display(Name = "Дата Создания")]
        [Required(ErrorMessage = "<Дата Создания> является обязательным")]
        public DateTime IssueTS { get; set; }

        [Display(Name = "Тип Запроса")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "<ТипИнцидента> является обязательным")]
        public string IssueType { get; set; }

        [Display(Name = "Категория")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "<Категория> является обязательным")]
        public string Category { get; set; }

        [Display(Name = "Описание проблемы")]
        [StringLength(maximumLength: 300, MinimumLength = 10, ErrorMessage = "Длина сообщения от 10 до 300 символов")]
        [Required(ErrorMessage = "<Описание> является обязательным")]
        [MinLength(10, ErrorMessage = "Минимальная длина 10 символов")]
        public string LongDescr { get; set; }

        [Display(Name = "Описание решения")]
        public string SolveDescr { get; set; }

        [Display(Name = "Статус")]
        [Required(ErrorMessage = "<Статус> является обязательным")]
        public string IssueStatus { get; set; }

    }
}
