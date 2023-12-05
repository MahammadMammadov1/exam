using Exam.Core.Models;
using Exam.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Exam.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDb;

        public HomeController(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public IActionResult Index()
        {
            List<Slider > slider = _appDb.Sliders.ToList();
            return View(slider);
        }

    }
}