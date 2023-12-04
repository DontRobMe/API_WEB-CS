using TP_CS.Business.Models;

namespace TP_CS.Business.IRepositories;

public interface IProjectRepository
{
    IEnumerable<Project>? GetProjects();
    
    Project GetProjectById(long id);
    
    void CreateProject(Project project);
    
    BusinessResult<Project> UpdateProject(Project project, long id);
    
    void DeleteProject(long id);
    
    IEnumerable<Project>? SearchProjects(string keyword);
}