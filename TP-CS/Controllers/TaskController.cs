using Microsoft.AspNetCore.Mvc;
using TP.Models;

namespace TP_CS.Controllers;
[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger1;
    public TaskController(ILogger<TaskController> logger)
    {
        _logger1 = logger;
    }

    // Create a new task via HTTP POST
    [HttpPost("create-task")]
    public IActionResult CreateTask([FromBody] Taches newTask)
    {
        try
        {
            if (newTask.UtilisateurId == null)
            {
                return BadRequest("L'ID de l'utilisateur est requis.");
            }

            // Vérifier si l'utilisateur avec l'ID existe
            var user = Utilisateurs._users.FirstOrDefault(u => u.id == newTask.UtilisateurId);

            if (user == null)
            {
                // L'utilisateur n'existe pas, renvoyer une réponse d'erreur
                return NotFound("L'utilisateur avec l'ID spécifié n'existe pas.");
            }

            newTask.id = Taches._nextTaskId;
            newTask.completed = false;
            Taches._tasks.Add(newTask);
            Taches._nextTaskId++;

            return Ok(newTask);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur : {ex.Message}");
        }
    }


    [HttpGet("tasks")]
    public IActionResult GetTasks()
    {
        return Ok(Taches._tasks);
    }


    [HttpDelete("delete-task/{taskId}")]
    public IActionResult DeleteTask(long taskId)
    {
        var task = Taches._tasks.FirstOrDefault(t => t.id == taskId);
        if (task == null)
        {
            return NotFound("Tâche introuvable");
        }
        Taches._tasks.Remove(task);
        // ReSharper disable once HeapView.BoxingAllocation
        return Ok($"Tâche avec l'ID {taskId} supprimée.");
    }

  

    [HttpGet("tasks/{taskId}")]
    public IActionResult GetTaskById(long taskId)
    {
        var task = Taches._tasks.FirstOrDefault(t => t.id == taskId);
        if (task == null)
        {
            return NotFound("Tâche introuvable");
        }
        return Ok(task);
    }

  

    [HttpPatch("update-task-status/{taskId}")]
    public IActionResult UpdateTaskStatus(long taskId, [FromBody] bool isDone)
    {
        var task = Taches._tasks.FirstOrDefault(t => t.id == taskId);
        if (task == null)
        {
            return NotFound("Tâche introuvable");
        }
        task.completed= isDone;
        return Ok(task);
    }
}