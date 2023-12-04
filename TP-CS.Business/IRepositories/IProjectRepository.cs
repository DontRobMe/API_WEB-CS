using TP_CS.Business.Models;

namespace TP_CS.Business.IRepositories;

public interface IProjectRepository
{
    IEnumerable<Project>? GetProjects();
    
    public Project GetProjectById(long id);
    
    public void CreateProject(Project project);
    
    public BusinessResult<Project> UpdateProject(Project project, long id);
    
    public void DeleteProject(long id);
    
    public IEnumerable<Project>? SearchProjects(string keyword);
}