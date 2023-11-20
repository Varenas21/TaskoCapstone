using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskoCapstone.Data;
using TaskoCapstone.Models;

namespace TaskoCapstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Parent()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Tasks()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}