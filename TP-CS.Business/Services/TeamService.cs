using System;
using System.Collections.Generic;
using TP_CS.Business.IRepositories;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;

namespace TP_CS.Business.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public BusinessResult<Team> GetTeamById(long id)
        {
            var team = _teamRepository.GetTeamById(id);
            return BusinessResult<Team>.FromSuccess(team);
        }

        public BusinessResult<IEnumerable<Team>> GetTeams()
        {
            var teams = _teamRepository.GetTeams();
            return BusinessResult<IEnumerable<Team>>.FromSuccess(teams);
        }

        public BusinessResult<Team> CreateTeam(Team team)
        {
            _teamRepository.CreateTeam(team);
            return BusinessResult<Team>.FromSuccess(team);
        }

        public BusinessResult UpdateTeam(Team team, long id)
        {
            var existingTeam = _teamRepository.UpdateTeam(team, id);
            return BusinessResult.FromSuccess(existingTeam);
        }

        public BusinessResult DeleteTeam(long id)
        {
            _teamRepository.DeleteTeam(id);
            return BusinessResult.FromSuccess();
        }
        
        public BusinessResult<List<Team>> SearchTeam(string keyword)
        {
            var matchingTasks = _teamRepository.SearchTeams(keyword);
            return BusinessResult<List<Team>>.FromSuccess(matchingTasks?.ToList());
        }
    }
}