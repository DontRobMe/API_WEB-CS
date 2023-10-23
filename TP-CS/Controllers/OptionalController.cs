using Microsoft.AspNetCore.Mvc;
using TP.Models;

namespace TP_CS.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionnalsController : ControllerBase
{
    private readonly ILogger<TaskController> _logger1;
    public OptionnalsController(ILogger<TaskController> logger)
    {
        _logger1 = logger;
    }
    
    [HttpGet("tasks/completed/{completed}", Name = "GetTasksByCompleted")]
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
    [HttpGet("tasks/user/{userId}", Name = "GetTasksByUserId")]
    public IActionResult GetTasksByUserId(long userId)
    {
        var task = Taches._tasks.Where(t => t.UtilisateurId == userId);
        if (task == null)
        {
            return NotFound("Tâche introuvable");
        }
        return Ok(task);
    }

    [HttpGet("search")]
    public IActionResult SearchTasks([FromQuery] string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest("Le paramètre 'keyword' est requis pour la recherche.");
        }

        
        var matchingTasks = Taches._tasks
            .Where(task =>
                    task.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) // Recherche insensible à la casse
            )
            .ToList();

        if (matchingTasks.Count == 0)
        {
            return NotFound("Aucune tâche correspondant au mot-clé trouvé.");
        }

        return Ok(matchingTasks);
    }
}