    using Microsoft.AspNetCore.Mvc;
    using TP_CS.Business.IServices;
    using TP_CS.Business.Models;
    using TP_CS.DTOs;

    namespace TP_CS.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class UserController : ControllerBase
        {
            private readonly ILogger<UserController> _logger;
            private readonly IUtilisateursService _userService;

            public UserController(ILogger<UserController> logger, IUtilisateursService userService)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            }

            [HttpGet]
            public IActionResult GetUsers()
            {
                var users = _userService.GetUsers();
                return Ok(users);
            }

            [HttpGet("{id:long}", Name = "GetUserById")]
            public IActionResult GetUserById(long id)
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound($"Utilisateur avec l'ID {id} introuvable.");
                }
                return Ok(user);
            }

            [HttpPost]
            public IActionResult CreateUser(UserCreateDto userDto)
            {
                var user = MapToUser(userDto);
                var createdUser = _userService.CreateUser(user);

                if (createdUser == null)
                {
                    return BadRequest("Erreur lors de la création de l'utilisateur.");
                }

                var createdUserDto = MapToUserDto(createdUser.Data);

                return CreatedAtRoute("GetUserById", new { id = createdUserDto.Id }, createdUserDto);
            }
            private User MapToUser(UserCreateDto userDto)
            {
                return new User
                {
                    Nom = userDto.Nom
                };
            }
            private UserDto MapToUserDto(User user)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Nom = user.Nom
                };
            }
            [HttpPut("{id:long}")]
            public IActionResult UpdateUser(long id, UserDto userDto)
            {
                User existingUser = _userService.GetUserById(id);

                if (existingUser == null)
                {
                    return NotFound($"Utilisateur avec l'ID {id} introuvable pour la mise à jour.");
                }

                existingUser.Nom = userDto.Nom;

                var updatedUser = _userService.UpdateUser(id, existingUser);

                return Ok(updatedUser);
            }

            [HttpDelete("{id:long}")]
            public IActionResult DeleteUser(long id)
            {
                var result = _userService.DeleteUser(id);
                if (result == null)
                {
                    return NotFound($"Utilisateur avec l'ID {id} introuvable pour la suppression.");
                }
                return NoContent();
            }
        }
    }
