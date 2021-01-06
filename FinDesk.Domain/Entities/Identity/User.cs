using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity;


namespace FinDesk.Domain.Identity
{
    public class User : IdentityUser
    {

        //ПШ сразу определим константы
        public const string Administrator = "Admin";
        public const string AdminDefaultPassword = "AdminPassword";
    }
}
