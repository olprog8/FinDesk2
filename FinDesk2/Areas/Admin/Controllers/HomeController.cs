using Microsoft.AspNetCore.Mvc;

namespace FinDesk2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        
    }
}
