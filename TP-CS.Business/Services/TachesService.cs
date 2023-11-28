using TP_CS.Business.IRepositories;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;
using UserTask = TP_CS.Business.Models.UserTask;

namespace TP_CS.Business.Services
{
    public class TacheService : ITacheService
    {
        private readonly ITaskRepository _taskRepository;

        public TacheService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }

        public BusinessResult<IEnumerable<UserTask>> GetTasks()
        {
            try
            {
                var tasks = _taskRepository.GetTasks();
                return BusinessResult<IEnumerable<UserTask>>.FromSuccess(tasks);
            }
            catch (Exception ex)
            {
                return BusinessResult<IEnumerable<UserTask>>.FromError("Erreur lors de la récupération des tâches.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<UserTask?> GetTaskById(long id)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                return BusinessResult<UserTask?>.FromSuccess(task);
            }
            catch (Exception ex)
            {
                return BusinessResult<UserTask?>.FromError($"Erreur lors de la récupération de la tâche avec l'ID {id}.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<UserTask> CreateTask(UserTask item)
        {
            try
            {
                _taskRepository.CreateTask(item); // Assuming the task is directly created in the repository

                // If the repository returns the created task, you can directly return it.
                return BusinessResult<UserTask>.FromSuccess(item);
            }
            catch (Exception ex)
            {
                return BusinessResult<UserTask>.FromError("Erreur lors de l'ajout de la tâche.", BusinessErrorReason.BusinessRule);
            }
        }


        public BusinessResult<UserTask> UpdateTaskStatus(long id, UserTask model)
        {
            try
            {
                var existingTask = _taskRepository.GetTaskById(id);

                if (existingTask != null)
                {
                    existingTask.Completed = model.Completed; // Assuming 'model.Completed' is the completion status
                    return BusinessResult<UserTask>.FromSuccess(existingTask);
                }
                else
                {
                    return BusinessResult<UserTask>.FromError($"La tâche avec l'ID {id} n'a pas été trouvée.", BusinessErrorReason.NotFound);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult<UserTask>.FromError($"Erreur lors de la mise à jour de la tâche avec l'ID {id}.", BusinessErrorReason.BusinessRule);
            }
        }




        public BusinessResult DeleteTask(long id)
        {
            try
            {
                // Utilisation de la méthode du repository pour supprimer une tâche par son ID
                _taskRepository.DeleteTask(id);
                return BusinessResult.FromSuccess();
            }
            catch (Exception ex)
            {
                return BusinessResult.FromError($"Erreur lors de la suppression de la tâche avec l'ID {id}.",
                    BusinessErrorReason.BusinessRule);
            }
        }


        public BusinessResult<List<UserTask>> GetTasksByCompleted(bool completed)
        {
            try
            {
                var tasks = _taskRepository.GetTasksByCompleted(completed);
                return BusinessResult<List<UserTask>>.FromSuccess(tasks?.ToList());
            }
            catch (Exception ex)
            {
                return BusinessResult<List<UserTask>>.FromError(
                    "Erreur lors de la récupération des tâches par statut.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<IEnumerable<UserTask>> GetTasksByUserId(long userId)
        {
            try
            {
                var tasks = _taskRepository.GetTasksByUserId(userId);
                return BusinessResult<IEnumerable<UserTask>>.FromSuccess(tasks);
            }
            catch (Exception ex)
            {
                return BusinessResult<IEnumerable<UserTask>>.FromError(
                    "Erreur lors de la récupération des tâches par utilisateur.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<List<UserTask>> SearchTasks(string keyword)
        {
            try
            {
                var matchingTasks = _taskRepository.SearchTasks(keyword);
                return BusinessResult<List<UserTask>>.FromSuccess(matchingTasks?.ToList());
            }
            catch (Exception ex)
            {
                return BusinessResult<List<UserTask>>.FromError(
                    "Erreur lors de la recherche des tâches par mot-clé.",
                    BusinessErrorReason.BusinessRule);
            }
        }
        
    }
}