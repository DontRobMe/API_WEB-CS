using Task = TP_CS.Business.Models.Task;

namespace TP_CS.Business.IRepositories
{
    public interface ITaskRepository
    {
        void CreateTask(Task newTask);
        
        IEnumerable<Task> GetTasks();
        
        void DeleteTask(long taskId);
        
        Task GetTaskById(long taskId);
        
        void UpdateTaskStatus(long taskId, bool isDone);
        
        IEnumerable<Task> GetTasksByCompleted(bool completed);
        
        IEnumerable<Task> GetTasksByUserId(long userId);
        
        IEnumerable<Task> SearchTasks(string keyword);
    }
}