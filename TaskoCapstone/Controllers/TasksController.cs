using Microsoft.AspNetCore.Mvc;
using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;

namespace TaskoCapstone.Controllers
{
    public class TasksController : Controller
    {
        IDataAccessLayer dal;

        public TasksController(IDataAccessLayer indal)
        {
            dal = indal;
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            TaskManager findTask = dal.GetTasks(id);

            dal.EditTasks(findTask);
            return View(findTask);
        }

        [HttpPost]
        public IActionResult Edit(TaskManager task)
        {
            if (ModelState.IsValid)
            {
                dal.EditTasks(task);
                return RedirectToAction("Index");

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
                return RedirectToAction("Home", "Parent");
            }
            return RedirectToAction("Home", "Parent");
        }
    }

    
}

