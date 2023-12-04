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
        private readonly IProjectRepository _projRepository;

        public TeamService(ITeamRepository teamRepository, IProjectRepository projRepository)
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            _projRepository = projRepository ?? throw new ArgumentNullException(nameof(projRepository));
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
            Project proj = _projRepository.GetProjectById(team.projectId);
            if (proj is null)
            {
                return BusinessResult<Team>.FromError("Le projet n'existe pas");
            }
            
            _teamRepository.CreateTeam(team, proj);
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