using TP_CS.Business.IRepositories;
using TP_CS.Data.Context;
using UserTask = TP_CS.Business.Models.UserTask;

namespace TP_CS.Data.Repositories
{
    public class DatabaseTaskRepository : ITaskRepository
    {
        private readonly MyDbContext _dbContext;

        public DatabaseTaskRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public void CreateTask(UserTask newTask)
        {
            if (newTask.UserId == default)
            {
                throw new ArgumentException("L'ID de l'utilisateur est requis.");
            }

            var user = _dbContext.Users?.FirstOrDefault(u => u.Id == newTask.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("L'utilisateur avec l'ID spécifié n'existe pas.");
            }

            _dbContext.Tasks?.Add(newTask);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserTask>? GetTasks()
        {
            return _dbContext.Tasks?.ToList();
        }

        public void DeleteTask(long taskId)
        {
            var task = _dbContext.Tasks?.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Tâche introuvable");
            }

            _dbContext.Tasks?.Remove(task);
            _dbContext.SaveChanges();
        }

        public UserTask GetTaskById(long taskId)
        {
            var task = _dbContext.Tasks?.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Tâche introuvable");
            }

            return task;
        }

        public void UpdateTaskStatus(long taskId, bool isDone)
        {
            var task = _dbContext.Tasks?.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Tâche introuvable");
            }

            if (task.Completed == isDone)
            {
                throw new ArgumentException("La tâche est déjà complétée.");
            }

            task.Completed = isDone;
            _dbContext.SaveChanges();
        }
        public IEnumerable<UserTask>? GetTasksByCompleted(bool completed)
        {
            return _dbContext.Tasks?.Where(t => t.Completed == completed).ToList();
        }

        public IEnumerable<UserTask>? GetTasksByUserId(long userId)
        {
            return _dbContext.Tasks?.Where(t => t.Id == userId ).ToList();
        }

        public IEnumerable<UserTask>? SearchTasks(string keyword)
        {
            return _dbContext.Tasks?.Where(task => task.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}