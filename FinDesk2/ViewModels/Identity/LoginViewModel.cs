using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FinDesk2.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(256)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Корпоративная почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

        //ПШ L6 1.34 Адрес на который нужно вернуться после того, как пользователь прошел авторизацию
        //ПШ L6 при визуализации создасться скрытый элемент формы средствами MVC
        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }

    }
}
