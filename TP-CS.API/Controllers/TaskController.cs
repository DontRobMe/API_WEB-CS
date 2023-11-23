using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;

namespace TP_CS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITacheService _taskService;

        public TaskController(ILogger<TaskController> logger, ITacheService taskService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetTasks();
            if (tasks == null || !tasks.Any())
            {
                return NotFound("Aucune tâche trouvée.");
            }
            return Ok(tasks);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public IActionResult GetTaskById(long id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound($"Tâche avec l'ID {id} introuvable.");
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask(Task task)
        {
            var createdTask = _taskService.CreateTask(task);
            if (createdTask == null)
            {
                return BadRequest("Erreur lors de la création de la tâche.");
            }
            return CreatedAtRoute("GetTaskById", new { id = createdTask.Data.id }, createdTask.Data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(long id, Task task)
        {
            var updatedTask = _taskService.UpdateTaskStatus(id, task);
            if (updatedTask == null)
            {
                return NotFound($"Tâche avec l'ID {id} introuvable pour la mise à jour.");
            }
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(long id)
        {
            var result = _taskService.DeleteTask(id);
            if (result == null)
            {
                return NotFound($"Tâche avec l'ID {id} introuvable pour la suppression.");
            }
            return NoContent();
        }
    }
}
