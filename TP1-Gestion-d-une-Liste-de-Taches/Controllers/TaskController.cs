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
    
    private long _nextUserId = 1;
    private long _nextTaskId = 1;

    private readonly List<Utilisateurs> _users = new List<Utilisateurs>();
    private readonly List<Taches> _tasks = new List<Taches>();
    
    public void CreateUser(string userName)
    {
        var user = new Utilisateurs
        {
            id = _nextUserId,
            Nom = userName
        };
        _users.Add(user);
        _nextUserId++;
    }
    
    public void CreateTask(string taskName, long userId)
    {
        var task = new Taches
        {
            id = _nextTaskId,
            Name = taskName,
            UtilisateurId = userId
        };
        _tasks.Add(task);
        _nextTaskId++;
    }
    
    [HttpPost("create-user")]
    public IActionResult CreateUser([FromBody] Utilisateurs newUser)
    {
        return Ok(newUser);
    }

    [HttpPost("create-task")]
    public IActionResult CreateTask([FromBody] Taches newTask)
    {
        return Ok(newTask);
    }
    
    [HttpDelete("delete-user/{userId:long}")]
    public IActionResult DeleteUser(long userId)
    {
        // ReSharper disable once HeapView.BoxingAllocation
        return Ok($"User with ID {userId} deleted.");
    }
    
    [HttpDelete("delete-task/{taskId:long}")]
    public IActionResult DeleteTask(long taskId)
    {
        // ReSharper disable once HeapView.BoxingAllocation
        return Ok($"Task with ID {taskId} deleted.");
    }
    
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        return Ok(_users);
    }

    // Retrieve all tasks
    [HttpGet("tasks")]
    public IActionResult GetTasks()
    {
        return Ok(_tasks);
    }
    
    [HttpGet("users/{userId}")]
    public IActionResult GetUserById(long userId)
    {
        var user = _users.FirstOrDefault(u => u.id == userId);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }

    // Retrieve a task by ID
    [HttpGet("tasks/{taskId}")]
    public IActionResult GetTaskById(long taskId)
    {
        var task = _tasks.FirstOrDefault(t => t.id == taskId);
        if (task == null)
        {
            return NotFound("Task not found");
        }
        return Ok(task);
    }
    
    [HttpPut("update-user/{userId}")]
    public IActionResult UpdateUser(long userId, [FromBody] Utilisateurs updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.id == userId);
        if (user == null)
        {
            return NotFound("User not found");
        }
            
        user.Nom = updatedUser.Nom; // Update user's name
        return Ok(user);
    }

    // Update a task by ID
    [HttpPut("update-task/{taskId}")]
    public IActionResult UpdateTask(long taskId, [FromBody] Taches updatedTask)
    {
        var task = _tasks.FirstOrDefault(t => t.id == taskId);
        if (task == null)
        {
            return NotFound("Task not found");
        }
            
        task.Name = updatedTask.Name; // Update task's name
        return Ok(task);
    }
    
}