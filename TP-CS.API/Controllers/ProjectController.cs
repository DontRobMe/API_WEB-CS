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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _projectService.GetProjects();
            return Ok(projects);
        }

        [HttpGet("{id:long}", Name = "GetProjectById")]
        public IActionResult GetProjectById(long id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound($"Projet avec l'ID {id} introuvable.");
            }

            return Ok(project);
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectDTO.CreateProjetDto project)
        {
            Project createdProject = new Project()
            {
                Name = project.Name,
                Description = project.Description,
                Status = project.Status,
                ResponsibleUserId = project.ResponsibleUserId
            };
            
            var createdProjectResult = _projectService.CreateProject(createdProject);
            
            return CreatedAtRoute("GetProjectById", new { id = createdProject.Id }, createdProject);
        }
        
        [HttpDelete]
        public IActionResult DeleteProject(long id)
        {
            var project = _projectService.DeleteProject(id);
            if (project == null)
            {
                return NotFound($"Projet avec l'ID {id} introuvable.");
            }

            return NoContent();
        }
        
        [HttpPut("{id:long}")]
        public IActionResult UpdateProject(long id, ProjectDTO.UpdateProjetDto project)
        {
            return NoContent();
        }
    }
}