using TP_CS.Business.Models;

namespace TP_CS.Business.IServices;

public interface IProjectService
{
    BusinessResult<Project> GetProjectById(long id);
    BusinessResult<IEnumerable<Project>> GetProjects();
    BusinessResult<Project> CreateProject(Project project);
    BusinessResult Update(Project project, bool isDone);
    BusinessResult DeleteProject(long id);
}