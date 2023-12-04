using TP_CS.Business.IRepositories;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;
using UserTask = TP_CS.Business.Models.UserTask;

namespace TP_CS.Business.Services
{
    public class TacheService : ITacheService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public TacheService(ITaskRepository taskRepository, IProjectRepository projectService, IUserRepository userRepository)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _projectRepository = projectService ?? throw new ArgumentNullException(nameof(projectService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public BusinessResult<IEnumerable<UserTask>> GetTasks()
        {
            var tasks = _taskRepository.GetTasks();
            return BusinessResult<IEnumerable<UserTask>>.FromSuccess(tasks);
        }

        public BusinessResult<UserTask> GetTaskById(long id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task != null)
            {
                return BusinessResult<UserTask>.FromSuccess(task);
            }
            else
            {
                return BusinessResult<UserTask>.FromError($"La tâche avec l'ID {id} est introuvable.",
                    BusinessErrorReason.NotFound);
            }
        }


        public BusinessResult<UserTask> CreateTask(UserTask item)
        {
            Project proj = _projectRepository.GetProjectById(item.ProjectId);
            User user = _userRepository.GetUserById(item.UserId);
            if (proj is null)
            {
                return BusinessResult<UserTask>.FromError("Le projet n'existe pas");
            }
            _taskRepository.CreateTask(item, proj, user);
            return BusinessResult<UserTask>.FromSuccess(item);
        }


        public BusinessResult UpdateTaskStatus(long id, bool isDone)
        {
            var existingTask = _taskRepository.UpdateTaskStatus(id, isDone);
            return BusinessResult.FromSuccess(existingTask);
        }


        public BusinessResult DeleteTask(long id)
        {
            _taskRepository.DeleteTask(id);
            return BusinessResult.FromSuccess();
        }


        public BusinessResult<List<UserTask>> GetTasksByCompleted(bool completed)
        {
            var tasks = _taskRepository.GetTasksByCompleted(completed);
            return BusinessResult<List<UserTask>>.FromSuccess(tasks?.ToList());
        }

        public BusinessResult<IEnumerable<UserTask>> GetTasksByUserId(long userId)
        {
            var tasks = _taskRepository.GetTasksByUserId(userId);
            return BusinessResult<IEnumerable<UserTask>>.FromSuccess(tasks);
        }

        public BusinessResult<List<UserTask>> SearchTasks(string keyword)
        {
            var matchingTasks = _taskRepository.SearchTasks(keyword);
            return BusinessResult<List<UserTask>>.FromSuccess(matchingTasks?.ToList());
        }
    }
}