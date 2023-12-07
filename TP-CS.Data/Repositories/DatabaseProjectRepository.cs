using Microsoft.EntityFrameworkCore;
using TP_CS.Business.IRepositories;
using TP_CS.Business.Models;
using TP_CS.Data.Context;

namespace TP_CS.Data.Repositories;

public class DatabaseProjectRepository : IProjectRepository
{
    private readonly MyDbContext _dbContext;

    public DatabaseProjectRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    public IEnumerable<Project>? GetProjects()
    {
        return _dbContext.Projects?
            .Include(b => b.Teams)
            .ThenInclude(t => t.Users)
            .ThenInclude(c => c.UserTasks)
            .ThenInclude(d => d.Tags)
            .ToList();
    }

    public Project GetProjectById(long? id)
    {
        return _dbContext.Projects?.FirstOrDefault(t => t.Id == id)!;

    }

    public void CreateProject(Project newproject)
    {
        _dbContext.Users?.FirstOrDefault(u => u.Id == newproject.ResponsibleUserId);
        _dbContext.Projects?.Add(newproject);
        _dbContext.SaveChanges();
    }

    public BusinessResult<Project> UpdateProject(Project project, long id)
    {
        var existingTeam = _dbContext.Projects?.FirstOrDefault(t => t.Id == id);

        if (existingTeam != null)
        {
            existingTeam.Name = project.Name;
            existingTeam.Description = project.Description;
            existingTeam.Status = project.Status; 
        }
        else
        {
            throw new InvalidOperationException("Projet introuvable");
        }    
        _dbContext.SaveChanges();
        return BusinessResult<Project>.FromSuccess(existingTeam);
    }

    public void DeleteProject(long id)
    {
        var proj = _dbContext.Projects?.FirstOrDefault(t => t.Id == id);
        if (proj == null)
        {
            throw new InvalidOperationException("Projet introuvable");
        }

        _dbContext.Projects?.Remove(proj);
        _dbContext.SaveChanges();    
    }

    public IEnumerable<Project>? SearchProjects(string keyword)
    {
        return _dbContext.Projects?.AsEnumerable().Where(proj => proj.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();    
    }
}