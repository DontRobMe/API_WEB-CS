using TP_CS.Business.Models;

namespace TP_CS.Business.IServices;

public interface ITeamService
{
    BusinessResult<Team> GetTeamById(long id);
    BusinessResult<IEnumerable<Team>> GetTeams();
    BusinessResult<Team> CreateTeam(Team team);
    BusinessResult UpdateTeam(Team team, long id);
    BusinessResult DeleteTeam(long id);
    BusinessResult<List<Team>> SearchTeam(string keyword);
}