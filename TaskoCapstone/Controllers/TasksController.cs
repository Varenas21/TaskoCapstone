using Microsoft.AspNetCore.Mvc;
using TaskoCapstone.Data;
using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;
using Microsoft.AspNetCore.Hosting.Builder;

namespace TaskoCapstone.Controllers
{
    public class TasksController : Controller
    {
        private readonly IDataAccessLayer dal;
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment env;
        

        public TasksController(IDataAccessLayer indal, ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            dal = indal;
            dbContext = db;
            env = hostingEnvironment;
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
        public IActionResult Create(TasksViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if(model.ImageofTask != null)
                {
                   string uploadsFolder = Path.Combine(env.WebRootPath, "images");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + model.ImageofTask.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    model.ImageofTask.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                TaskManager newTask = new TaskManager
                {
                    NameofTask = model.NameofTask,
                    Description = model.Description,
                    StepsofTask = model.StepsofTask,
                    CompletionofTask = model.CompletionofTask,
                    CountdownTimer = model.CountdownTimer,
                    ImageofTask = uniqueFilename
                
                };

                
                dal.CreateTask(model);
                return RedirectToAction("Parent", "Home");
            }
            return View(model);
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

