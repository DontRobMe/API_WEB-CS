using TP_CS.Business.IRepositories;
using TP_CS.Business.Models;
using TP_CS.Data.Context;

namespace TP_CS.Data.Repositories;

public class DatabaseTeamRepository : ITeamRepository
{
    private readonly MyDbContext _dbContext;

    public DatabaseTeamRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public List<Team>? GetTeams()
    {
        return _dbContext.Teams?.ToList();
    }

    public Team GetTeamById(long id)
    {
        return _dbContext.Teams?.FirstOrDefault(t => t.Id == id)!;
    }

    public void CreateTeam(Team team)
    {
        _dbContext.Teams?.Add(team);
        _dbContext.SaveChanges();
    }

    public BusinessResult<Team> UpdateTeam(Team team)
    {
        var existingTeam = _dbContext.Teams?.FirstOrDefault(t => t.Id == team.Id);

        if (existingTeam != null)
        {
            existingTeam.Name = team.Name;
            existingTeam.Description = team.Description;
            int affected = _dbContext.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException("Équipe introuvable");
        }

        return BusinessResult<Team>.FromSuccess(existingTeam);
    }

    public void DeleteTeam(long id)
    {
        var team = _dbContext.Teams?.FirstOrDefault(t => t.Id == id);
        if (team == null)
        {
            throw new InvalidOperationException("Équipe introuvable");
        }

        _dbContext.Teams?.Remove(team);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Team>? SearchTeams(string keyword)
    {
        return _dbContext.Teams?.AsEnumerable().Where(team => team.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}