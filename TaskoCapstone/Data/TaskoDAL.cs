using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;

namespace TaskoCapstone.Data
{
    public class TaskoDAL : IDataAccessLayer
    {
        private ApplicationDbContext db;

        public TaskoDAL()
        {
        }

        public TaskoDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CompleteTasks(int? id)
        {
            throw new NotImplementedException();
        }

        public void CreateTask(TaskManager task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void DeleteTasks(int? id)
        {
            throw new NotImplementedException();
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
