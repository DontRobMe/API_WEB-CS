using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;
using UserTask = TP_CS.Business.Models.UserTask;

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

        [HttpGet("{id:long}", Name = "GetTaskById")]
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
        public IActionResult CreateTask(UserTask task)
        {
            var createdTaskResult = _taskService.CreateTask(task);

            return CreatedAtRoute("GetTaskById", new { id = task.Id }, task);
        }


        [HttpPut("{id:long}")]
        public IActionResult UpdateTask(long id, bool isDone)
        {
            var updatedTask = _taskService.UpdateTaskStatus(id, isDone);
            if (updatedTask == null)
            {
                return NotFound($"Tâche avec l'ID {id} introuvable pour la mise à jour.");
            }

            return Ok(updatedTask);
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteTask(long id)
        {
            var result = _taskService.DeleteTask(id);
            if (result == null)
            {
                return NotFound($"Tâche avec l'ID {id} introuvable pour la suppression.");
            }

            return NoContent();
        }
        
        [HttpGet("completed/{completed:bool}")]
        public IActionResult GetTasksByCompleted(bool completed)
        {
            var tasks = _taskService.GetTasksByCompleted(completed);
            return Ok(tasks);
        }
        
        [HttpGet("user/{userId:long}")]
        public IActionResult GetTasksByUserId(long userId)
        {
            var tasks = _taskService.GetTasksByUserId(userId);
            return Ok(tasks);
        }
        
        [HttpGet("search/{keyword}")]
        public IActionResult SearchTasks(string keyword)
        {
            var tasks = _taskService.SearchTasks(keyword);
            return Ok(tasks);
        }
    }
}