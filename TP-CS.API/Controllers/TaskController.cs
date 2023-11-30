using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;
using TP_CS.DTOs;
using Task = TP_CS.Business.Models.Task;

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
        public IActionResult CreateTask(TaskCreateDto taskDto)
        {
            var createdTask = _taskService.CreateTask(MapToTask(taskDto));
            if (createdTask == null)
            {
                return BadRequest("Erreur lors de la création de la tâche.");
            }
            return CreatedAtRoute("GetTaskById", new { id = createdTask.Data.Id }, createdTask.Data);
        }
        private Task MapToTask(TaskCreateDto taskDto)
        {
            return new Task
            {
                Name = taskDto.Name,
                Completed = taskDto.Completed,
                UtilisateurId = taskDto.UtilisateurId
            };
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateTask(long id, TaskUpdateDto taskUpdateDto)
        {
            var existingTask = _taskService.GetTaskById(id);

            if (existingTask == null)
            {
                return NotFound($"Tâche avec l'ID {id} introuvable pour la mise à jour.");
            }

            existingTask.Completed = taskUpdateDto.Completed;

            var updatedTask = _taskService.UpdateTaskStatus(id, existingTask);

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
