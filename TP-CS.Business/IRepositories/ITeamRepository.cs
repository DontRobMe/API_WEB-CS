using TP_CS.Business.Models;

namespace TP_CS.Business.IRepositories;

public interface ITeamRepository
{
    List<Team>? GetTeams();
    Team GetTeamById(long id);
    void CreateTeam(Team team, Project proj);
    BusinessResult<Team> UpdateTeam(Team team, long id);
    void DeleteTeam(long id);
    IEnumerable<Team>? SearchTeams(string keyword);
}