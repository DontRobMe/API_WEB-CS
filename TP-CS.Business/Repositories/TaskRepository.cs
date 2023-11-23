using System;
using System.Collections.Generic;
using System.Linq;
using TP_CS.Business.IRepositories;
using TP_CS.Business.Models;

namespace TP_CS.Business.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks;

        public TaskRepository(List<Task> tasks)
        {
            _tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
        }


        public void CreateTask(Task newTask)
        {
            if (newTask.UtilisateurId == default)
            {
                throw new ArgumentException("L'ID de l'utilisateur est requis.");
            }

            var user = User._users.FirstOrDefault(u => u.id == newTask.UtilisateurId);
            if (user == null)
            {
                throw new InvalidOperationException("L'utilisateur avec l'ID spécifié n'existe pas.");
            }

            newTask.id = Task._nextTaskId;
            newTask.completed = false;
            Task._tasks.Add(newTask);
            Task._nextTaskId++;
        }

        public IEnumerable<Task> GetTasks()
        {
            if (Task._tasks.Count == 0)
            {
                throw new InvalidOperationException("Aucune tâche n'a été trouvée.");
            }

            return Task._tasks;
        }

        public void DeleteTask(long taskId)
        {
            var task = Task._tasks.FirstOrDefault(t => t.id == taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Tâche introuvable");
            }

            Task._tasks.Remove(task);
        }

        public Task GetTaskById(long taskId)
        {
            var task = Task._tasks.FirstOrDefault(t => t.id == taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Tâche introuvable");
            }

            return task;
        }

        public void UpdateTaskStatus(long taskId, bool isDone)
        {
            var task = Task._tasks.FirstOrDefault(t => t.id == taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Tâche introuvable");
            }

            if (task.completed == isDone)
            {
                throw new ArgumentException("La tâche est déjà complétée.");
            }

            task.completed = true;
        }
        public IEnumerable<Task> GetTasksByCompleted(bool completed)
        {
            return _tasks.Where(t => t.completed == completed);
        }

        public IEnumerable<Task> GetTasksByUserId(long userId)
        {
            return _tasks.Where(t => t.UtilisateurId == userId);
        }

        public IEnumerable<Task> SearchTasks(string keyword)
        {
            return _tasks.Where(task => task.Name != null && task.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}