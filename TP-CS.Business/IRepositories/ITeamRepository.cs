using TP_CS.Business.Models;

namespace TP_CS.Business.IRepositories;

public interface ITeamRepository
{
    List<Team>? GetTeams();
    Team GetTeamById(long id);
    void CreateTeam(Team team);
    BusinessResult<Team> UpdateTeam(Team team);
    void DeleteTeam(long id);
    IEnumerable<Team>? SearchTeams(string keyword);
}