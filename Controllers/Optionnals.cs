using Microsoft.AspNetCore.Mvc;
using TP.Models;

namespace TP.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionnalsController : ControllerBase
{
    private readonly ILogger<TaskController> _logger1;
    public OptionnalsController(ILogger<TaskController> logger)
    {
        _logger1 = logger;
    }
    
    //creer un trieur de toute les tache en fonction de completed
    [HttpGet("tasks/{completed}")]
    public IActionResult GetTasksByCompleted(bool completed)
    {
        var task = Taches._tasks.Where(t => t.completed == completed);
        if (task == null)
        {
            return NotFound("Tâche introuvable");
        }
        return Ok(task);
    }
    
    //recuperer toutes les tasks par user id 
    [HttpGet("tasks/{userId}")]
    public IActionResult GetTasksByUserId(long userId)
    {
        var task = Taches._tasks.Where(t => t.UtilisateurId == userId);
        if (task == null)
        {
            return NotFound("Tâche introuvable");
        }
        return Ok(task);
    }
}