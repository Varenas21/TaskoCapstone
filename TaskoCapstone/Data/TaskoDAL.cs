using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;

namespace TaskoCapstone.Data
{
    public class TaskoDAL : IDataAccessLayer
    {
        private ApplicationDbContext db;

        public TaskoDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CompleteTasks(int taskId)
        {
            var task = await db.Tasks.FindAsync(taskId);
            task.CompletionofTask = true;

            await db.SaveChangesAsync();

        }



        public void CreateTask(TasksViewModel task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void DeleteTasks(int? id)
        {
            TaskManager taskFound = GetTasks(id);
            db.Tasks.Remove(taskFound);
            db.SaveChanges();
        }

        public void EditTasks(TaskManager task)
        {
            db.Tasks.Update(task);
            db.SaveChanges();
        }

        public TaskManager GetTasks(int? id)
        {
            return db.Tasks.Where(g => g.Id == id).FirstOrDefault();
        }

        public IEnumerable<TaskManager> GetTasks()
        {
            return db.Tasks.ToList();
        }



        public IEnumerable<UserProfile> GetUser()
        {
            return db.UserProfiles.ToList();
        }

    }
}
