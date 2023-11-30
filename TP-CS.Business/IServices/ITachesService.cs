using TP_CS.Business.Models;
using UserTask = TP_CS.Business.Models.UserTask;

namespace TP_CS.Business.IServices
{
    public interface ITacheService
    {
        public BusinessResult<IEnumerable<UserTask>> GetTasks();

        public BusinessResult<UserTask> GetTaskById(long id);

        public BusinessResult<UserTask> CreateTask(UserTask item);

        public BusinessResult UpdateTaskStatus(long id, bool isDone);

        public BusinessResult DeleteTask(long id);
        BusinessResult<List<UserTask>> GetTasksByCompleted(bool completed);
        BusinessResult<IEnumerable<UserTask>> GetTasksByUserId(long userId);
        BusinessResult<List<UserTask>> SearchTasks(string keyword);
    }
}