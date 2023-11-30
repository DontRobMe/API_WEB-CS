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

        public UtilisateurService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
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
            var newUser = _userRepository.CreateUser(item);
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