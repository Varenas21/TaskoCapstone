using TaskoCapstone.Models;

namespace TaskoCapstone.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<UserProfile> GetUser();
        IEnumerable<TaskManager> GetTasks();

        void EditTasks(TaskManager task);
        TaskManager GetTasks(int? id);

   

        void DeleteTasks(int? id);
        void CompleteTasks(TaskManager task);
        void CreateTask(TaskManager task);
    }
}
