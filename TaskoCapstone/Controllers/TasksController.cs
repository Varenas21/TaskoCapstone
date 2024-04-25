using Microsoft.AspNetCore.Mvc;
using TaskoCapstone.Data;
using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize (Roles = "Admin, Parent")]
        public IActionResult Edit(int id)
        {
            TaskManager findTask = dal.GetTasks().Where(g => g.Id == id).FirstOrDefault();
            EditViewModel editViewModel = new EditViewModel
            {
                Id = findTask.Id,
                NameofTask = findTask.NameofTask,
                Description = findTask.Description,
                StepsofTask = findTask.StepsofTask,
                CompletionofTask = findTask.CompletionofTask,
                CountdownTimer = findTask.CountdownTimer,
                ExistingImagePath = findTask.ImageofTask
            };

            return View(editViewModel);
        }




        [HttpPost]
        [Authorize(Roles = "Admin, Parent")]
        public IActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                TaskManager task = dal.GetTasks(model.Id);

                task.NameofTask = model.NameofTask;
                task.Description = model.Description;
                task.StepsofTask = model.StepsofTask;
                task.CompletionofTask = model.CompletionofTask;
                task.CountdownTimer = model.CountdownTimer;
                if (model.ImageofTask != null)
                {
                    if (model.ExistingImagePath != null)
                    {
                        string filePath = Path.Combine(env.WebRootPath, "images", model.ExistingImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    task.ImageofTask = ProcessUploadedFile(model);
                }

                dal.EditTasks(task);
                return RedirectToAction("Parent", "Home");
            }
            return View();
        }

        private string ProcessUploadedFile(TasksViewModel model)
        {
            string uniqueFilename = null;
            if (model.ImageofTask != null)
            {
                string uploadsFolder = Path.Combine(env.WebRootPath, "images");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + model.ImageofTask.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageofTask.CopyTo(fileStream);
                }
               
            }

            return uniqueFilename;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Parent")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TasksViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = ProcessUploadedFile(model);

                TaskManager newTask = new TaskManager
                {
                    NameofTask = model.NameofTask,
                    Description = model.Description,
                    StepsofTask = model.StepsofTask,
                    CompletionofTask = model.CompletionofTask,
                    CountdownTimer = model.CountdownTimer,
                    ImageofTask = uniqueFilename

                };

                dal.CreateTask(newTask);
                return RedirectToAction("Parent", "Home");
            }
            return View();
        }

        [Authorize(Roles = "Admin, Parent")]
        public IActionResult Delete(int id)
        {
            dal.DeleteTasks(id);
            TempData["Success"] = "Tasks Deleted!";
            return RedirectToAction("Parent", "Home");
        }

        [Authorize(Roles = "Admin, Parent")]
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

