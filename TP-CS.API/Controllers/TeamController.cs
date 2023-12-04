using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TP_CS.Business.DTO;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;

namespace TP_CS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _teamService.GetTeams();
            return Ok(teams);
        }

        [HttpGet("{id:long}", Name = "GetTeamById")]
        public IActionResult GetTeamById(long id)
        {
            var team = _teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound($"Équipe avec l'ID {id} introuvable.");
            }

            return Ok(team);
        }

        [HttpPost]
        public IActionResult CreateTeam(TeamDto.CreateTeamDto team)
        {
            Team createdTeam = new Team()
            {
                Name = team.Name,
                Description = team.Description,
                projectId = team.projectId,
                LeaderUserId = team.LeaderUserId

            };
            var createdTeamResult = _teamService.CreateTeam(createdTeam);
            return CreatedAtRoute("GetTeamById", new { id = createdTeam.Id }, createdTeam);
        }
        
        [HttpDelete]
        public IActionResult DeleteTeam(long id)
        {
            var team = _teamService.DeleteTeam(id);
            if (team == null)
            {
                return NotFound($"Équipe avec l'ID {id} introuvable.");
            }

            return NoContent();
        }
        
        [HttpPut("{id:long}")]
        public IActionResult UpdateTeam(TeamDto.UpdateTeamDto team, long id)
        {
            Team updatedTeam = new Team()
            {
                Name = team.Name,
                Description = team.Description, 
            };
            var updatedTask = _teamService.UpdateTeam(updatedTeam, id);
            if (updatedTask == null)
            {
                return NotFound($"Tâche avec l'ID {id} introuvable pour la mise à jour.");
            }

            return Ok(updatedTask);
        }
        [HttpGet("search/{keyword}")]
        public IActionResult SearchTeam(string keyword)
        {
            var tasks = _teamService.SearchTeam(keyword);
            return Ok(tasks);
        }
    }
}