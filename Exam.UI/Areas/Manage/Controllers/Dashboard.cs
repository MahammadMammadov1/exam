using Microsoft.AspNetCore.Mvc;

namespace Exam.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
