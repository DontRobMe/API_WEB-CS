using TP_CS.Business.Models;
using UserTask = TP_CS.Business.Models.UserTask;

namespace TP_CS.Business.IRepositories
{
    public interface ITaskRepository
    {
        void CreateTask(UserTask newTask);
        
        IEnumerable<UserTask>? GetTasks();
        
        void DeleteTask(long taskId);
        
        UserTask GetTaskById(long taskId);
        
        BusinessResult<UserTask> UpdateTaskStatus(long taskId, bool isDone);
        
        IEnumerable<UserTask>? GetTasksByCompleted(bool completed);
        
        IEnumerable<UserTask>? GetTasksByUserId(long userId);
        
        IEnumerable<UserTask>? SearchTasks(string keyword);
    }
}