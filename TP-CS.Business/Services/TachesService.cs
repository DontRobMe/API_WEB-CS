using TP_CS.Business.IServices;
using TP_CS.Business.Models;
using Task = TP_CS.Business.Models.Task;

namespace TP_CS.Business.Services
{
    public class TacheService : ITacheService
    {
        private readonly List<Task> _tasks;
        private ITacheService _tacheServiceImplementation;

        public TacheService(List<Task> tasks, ITacheService tacheServiceImplementation)
        {
            _tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
            _tacheServiceImplementation = tacheServiceImplementation;
        }

        public BusinessResult<List<Task>> GetTasks()
        {
            try
            {
                return BusinessResult<List<Task>>.FromSuccess(_tasks);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<Task>>.FromError("Erreur lors de la récupération des tâches.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public Task GetTaskById(long id)
        {
            try
            {
                Task? task = _tasks.Find(t => t.Id == id);
                if (task != null)
                {
                    return BusinessResult<Task?>.FromSuccess(task);
                }
                else
                {
                    return BusinessResult<Task?>.FromError($"La tâche avec l'ID {id} n'a pas été trouvée.",
                        BusinessErrorReason.NotFound);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult<Task?>.FromError($"Erreur lors de la récupération de la tâche avec l'ID {id}.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<Task> CreateTask(Task item)
        {
            try
            {
                item.Id = ++Task._nextTaskId;
                _tasks.Add(item);
                return BusinessResult<Task>.FromSuccess(item);
            }
            catch (Exception ex)
            {
                return BusinessResult<Task>.FromError("Erreur lors de l'ajout de la tâche.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<Task> UpdateTaskStatus(long id, Task model)
        {
            try
            {
                Task? existingTask = _tasks.Find(t => t.Id == id);
                if (existingTask != null)
                {
                    existingTask.Name = model.Name;
                    existingTask.Completed = model.Completed;
                    existingTask.UtilisateurId = model.UtilisateurId;

                    return BusinessResult<Task>.FromSuccess(existingTask);
                }
                else
                {
                    return BusinessResult<Task>.FromError($"La tâche avec l'ID {id} n'a pas été trouvée.",
                        BusinessErrorReason.NotFound);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult<Task>.FromError($"Erreur lors de la mise à jour de la tâche avec l'ID {id}.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult DeleteTask(long id)
        {
            try
            {
                Task? taskToRemove = _tasks.Find(t => t.Id == id);
                if (taskToRemove != null)
                {
                    _tasks.Remove(taskToRemove);
                    return BusinessResult.FromSuccess();
                }
                else
                {
                    return BusinessResult.FromError($"La tâche avec l'ID {id} n'a pas été trouvée.",
                        BusinessErrorReason.NotFound);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult.FromError($"Erreur lors de la suppression de la tâche avec l'ID {id}.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<List<Task>> GetTasksByCompleted(bool completed)
        {
            try
            {
                var tasks = _tasks.Where(t => t.Completed == completed).ToList();
                return BusinessResult<List<Task>>.FromSuccess(tasks);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<Task>>.FromError("Erreur lors de la récupération des tâches par statut.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<List<Task>> GetTasksByUserId(long userId)
        {
            try
            {
                var tasks = _tasks.Where(t => t.UtilisateurId == userId).ToList();
                return BusinessResult<List<Task>>.FromSuccess(tasks);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<Task>>.FromError(
                    "Erreur lors de la récupération des tâches par utilisateur.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<List<Task>> SearchTasks(string keyword)
        {
            try
            {
                var matchingTasks = _tasks
                    .Where(task =>
                        task.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();

                return BusinessResult<List<Task>>.FromSuccess(matchingTasks);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<Task>>.FromError("Erreur lors de la recherche des tâches par mot-clé.",
                    BusinessErrorReason.BusinessRule);
            }
        }
    }
}