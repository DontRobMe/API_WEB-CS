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
        return _dbContext.Projects?.ToList();
    }

    public Project GetProjectById(long id)
    {
        return _dbContext.Projects?.FirstOrDefault(t => t.Id == id)!;

    }

    public void CreateProject(Project newproject)
    {
        if (newproject.ResponsibleUserId == default)
        {
            throw new ArgumentException("L'ID de l'utilisateur responsable est requis.");
        }

        var proj = _dbContext.Users?.FirstOrDefault(u => u.Id == newproject.ResponsibleUserId);
        if (proj == null)
        {
            throw new InvalidOperationException("L'utilisateur avec l'ID spécifié n'existe pas.");
        }

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
            throw new InvalidOperationException("Équipe introuvable");
        }    
        _dbContext.SaveChanges();
        return BusinessResult<Project>.FromSuccess(existingTeam);
    }

    public void DeleteProject(long id)
    {
        var proj = _dbContext.Projects?.FirstOrDefault(t => t.Id == id);
        if (proj == null)
        {
            throw new InvalidOperationException("Tâche introuvable");
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