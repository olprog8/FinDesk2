using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using FinDesk.Domain.Identity;

namespace FinDesk2.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        
    }
}
