using TP_CS.Business.Models;

namespace TP_CS.Business.IServices;

public interface IProjectService
{
    public BusinessResult<Project> GetProjectById(long id);
    public BusinessResult<IEnumerable<Project>> GetProjects();
    public BusinessResult<Project> CreateProject(Project project);
    public BusinessResult Update(Project project, long id);
    public BusinessResult DeleteProject(long id);
    public BusinessResult<List<Project>> SearchProject(string keyword);
}