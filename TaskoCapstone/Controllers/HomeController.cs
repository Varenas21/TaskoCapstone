using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskoCapstone.Data;
using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;

namespace TaskoCapstone.Controllers
{
    //[Authorize (Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataAccessLayer dal;

        public HomeController(ApplicationDbContext context, IDataAccessLayer dal)
        {
            _context = context;
            this.dal = dal;
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

        public IActionResult TaskFullView(int id)
        {
            var task = dal.GetTasks(id);
            return View(task);
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