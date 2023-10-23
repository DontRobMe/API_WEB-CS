using Microsoft.AspNetCore.Mvc;
using TP.Models;

namespace TP_CS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User : Controller
    {

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
            return Ok($"Utilisateur avec l'ID {userId} supprimÃ©.");
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            if(Utilisateurs._users.Count == 0)
            {
                return NotFound("Aucun utilisateur");
            }
            return Ok(Utilisateurs._users);
        }

      
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

        [HttpPut("update-user/{userId}")]
        public IActionResult UpdateUser(long userId, [FromBody] Utilisateurs updatedUser)
        {
            var user = Utilisateurs._users.FirstOrDefault(u => u.id == userId);
            if (user == null)
            {
                return NotFound("Utilisateur introuvable");
            }
            user.Nom = updatedUser.Nom;
            return Ok(user);
        }

    }
}