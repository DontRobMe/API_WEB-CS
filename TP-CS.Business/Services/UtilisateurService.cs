#nullable enable
using System;
using System.Collections.Generic;
using TP_CS.Business.IRepositories;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;


namespace TP_CS.Business.Services
{
    public class UtilisateurService : IUtilisateursService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        public UtilisateurService(IUserRepository userRepository, ITeamRepository teamRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public BusinessResult<IEnumerable<User>> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return BusinessResult<IEnumerable<User>>.FromSuccess(users);
        }

        public BusinessResult<User> GetUserById(long id)
        {
            var user = _userRepository.GetUserById(id);
            return BusinessResult<User>.FromSuccess(user);
        }


        public BusinessResult<User> CreateUser(User item)
        {
            Team team = _teamRepository.GetTeamById(item.TeamId);
            var newUser = _userRepository.CreateUser(item, team);
            return BusinessResult<User>.FromSuccess(newUser);
        }


        public BusinessResult UpdateUser(long id, User model)
        {
            var updatedUser = _userRepository.UpdateUser(id, model);

            return BusinessResult.FromSuccess(updatedUser);
        }


        public BusinessResult DeleteUser(long id)
        {
            _userRepository.DeleteUser(id);
            return BusinessResult.FromSuccess();
        }
    }
}