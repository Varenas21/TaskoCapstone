using Microsoft.AspNetCore.Mvc;
using TaskoCapstone.Data;
using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;

namespace TaskoCapstone.Controllers
{
    public class TasksController : Controller
    {
        IDataAccessLayer dal;
        ApplicationDbContext dbContext;

        public TasksController(IDataAccessLayer indal, ApplicationDbContext db)
        {
            dal = indal;
            dbContext = db;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TaskManager findTask = dal.GetTasks().Where(g => g.Id == id).FirstOrDefault();

            dal.EditTasks(findTask);
            return View(findTask);
        }

        [HttpPost]
        public IActionResult Edit(TaskManager task)
        {
            if (ModelState.IsValid)
            {
                dal.EditTasks(task);
                TempData["success"] = task.NameofTask + " was updated!";
                return RedirectToAction("Parent", "Home");

            }
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskManager task)
        {
            if (ModelState.IsValid)
            {
                dal.CreateTask(task);
                return RedirectToAction("Parent", "Home");
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            dal.DeleteTasks(id);
            TempData["Success"] = "Tasks Deleted!";
            return RedirectToAction("Parent", "Home");
        }

        public IActionResult Complete(int id)
        {
            TaskManager task = dbContext.Tasks.Find(id);
            if (dbContext == null)
            {
                return NotFound();
            }

            task.CompletionofTask = true;
            dbContext.SaveChanges();
            TempData["Success"] = "Tasks Completed!";

            return RedirectToAction("Parent", "Home");
        }
    }


}

