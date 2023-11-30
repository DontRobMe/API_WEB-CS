using TP_CS.Business.Models;
using Task = TP_CS.Business.Models.Task;

namespace TP_CS.Business.IServices
{
    public interface ITacheService
    {
        public BusinessResult<List<Task>> GetTasks();

        public Task GetTaskById(long id);

        public BusinessResult<Task> CreateTask(Task item);

        public BusinessResult<Task> UpdateTaskStatus(long id, Task model);

        public BusinessResult DeleteTask(long id);
        BusinessResult<List<Task>> GetTasksByCompleted(bool completed);
        BusinessResult<List<Task>> GetTasksByUserId(long userId);
        BusinessResult<List<Task>> SearchTasks(string keyword);
    }
}