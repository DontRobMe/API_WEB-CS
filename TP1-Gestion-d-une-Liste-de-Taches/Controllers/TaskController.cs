using TP1_Gestion_d_une_Liste_de_Taches.Models;
using Microsoft.AspNetCore.Mvc;
namespace TP1_Gestion_d_une_Liste_de_Taches.Controllers;


[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger1;

    public TaskController(ILogger<TaskController> logger)
    {
        _logger1 = logger;
    }

    [HttpPost("create-user")]
    public IActionResult CreateUser([FromBody] Utilisateurs newUser)
    {
        try
        {
            newUser.id = Utilisateurs._nextUserId;
            Utilisateurs._users.Add(newUser);
            Utilisateurs._nextUserId++;
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur : {ex.Message}");
        }
    }

    // Create a new task via HTTP POST
    [HttpPost("create-task")]
    public IActionResult CreateTask([FromBody] Taches newTask)
    {
        try
        {
            newTask.id = Taches._nextTaskId;
            Taches._tasks.Add(newTask);
            Taches._nextTaskId++;
            return Ok(newTask);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur : {ex.Message}");
        }
    }

    // Delete a user by ID via HTTP DELETE
    [HttpDelete("delete-user/{userId}")]
    public IActionResult DeleteUser(long userId)
    {
        var user = Utilisateurs._users.FirstOrDefault(u => u.id == userId);
        if (user == null)
        {
            return NotFound("Utilisateur introuvable");
        }

        Utilisateurs._users.Remove(user);
        // ReSharper disable once HeapView.BoxingAllocation
        return Ok($"Utilisateur avec l'ID {userId} supprimé.");
    }

    // Delete a task by ID via HTTP DELETE
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

    // Retrieve all users via HTTP GET
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        return Ok(Utilisateurs._users);
    }

    // Retrieve all tasks via HTTP GET
    [HttpGet("tasks")]
    public IActionResult GetTasks()
    {
        return Ok(Taches._tasks);
    }

    // Retrieve a user by ID via HTTP GET
    [HttpGet("users/{userId}")]
    public IActionResult GetUserById(long userId)
    {
        var user = Utilisateurs._users.FirstOrDefault(u => u.id == userId);
        if (user == null)
        {
            return NotFound("Utilisateur introuvable");
        }

        return Ok(user);
    }

    // Retrieve a task by ID via HTTP GET
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

    // Update user information via HTTP PUT
    [HttpPut("update-user/{userId}")]
    public IActionResult UpdateUser(long userId, [FromBody] Utilisateurs updatedUser)
    {
        var user = Utilisateurs._users.FirstOrDefault(u => u.id == userId);
        if (user == null)
        {
            return NotFound("Utilisateur introuvable");
        }

        user.Nom = updatedUser.Nom; // Mettre à jour le nom de l'utilisateur
        return Ok(user);
    }

    // Update task status via HTTP PATCH
    [HttpPatch("update-task-status/{taskId}")]
    public IActionResult UpdateTaskStatus(long taskId, [FromBody] bool isDone)
    {
        var task = Taches._tasks.FirstOrDefault(t => t.id == taskId);
        if (task == null)
        {
            return NotFound("Tâche introuvable");
        }

        task.Statut = isDone;
        return Ok(task);
    }
}