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
        //refaire toutes les fonctions pour utiliser db et pas memory

        public BusinessResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = _userRepository.GetUsers();
                return BusinessResult<IEnumerable<User>>.FromSuccess(users);
            }
            catch (Exception ex)
            {
                return BusinessResult<IEnumerable<User>>.FromError("Erreur lors de la récupération des utilisateurs.",
                    BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<User?> GetUserById(long id)
        {
            try
            {
                var user = _userRepository.GetUserById(id);
                return BusinessResult<User?>.FromSuccess(user);
            }
            catch (Exception ex)
            {
                return BusinessResult<User?>.FromError($"Erreur lors de la récupération de l'utilisateur avec l'ID {id}.", BusinessErrorReason.BusinessRule);
            }
        }


        public BusinessResult<User> CreateUser(User item)
        {
            try
            {
                _userRepository.CreateUser(item);
                return BusinessResult<User>.FromSuccess(item);
            }
            catch (Exception ex)
            {
                return BusinessResult<User>.FromError("Erreur lors de l'ajout de l'utilisateur.", BusinessErrorReason.BusinessRule);
            }
        }


        public BusinessResult<User> UpdateUser(long id, User model)
        {
            try
            {
                BusinessResult<User> updatedUser = _userRepository.UpdateUser(id, model);

                if (updatedUser != null)
                {
                    return BusinessResult<User>.FromSuccess(updatedUser);
                }
                else
                {
                    return BusinessResult<User>.FromError($"L'utilisateur avec l'ID {id} n'a pas été trouvé.", BusinessErrorReason.NotFound);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult<User>.FromError($"Erreur lors de la mise à jour de l'utilisateur avec l'ID {id}.", BusinessErrorReason.BusinessRule);
            }
        }






        public BusinessResult DeleteUser(long id)
        {
            try
            {
                    _userRepository.DeleteUser(id);
                    return BusinessResult.FromSuccess();
            }
            catch (Exception ex)
            {
                return BusinessResult.FromError($"Erreur lors de la suppression de l'utilisateur avec l'ID {id}.",
                    BusinessErrorReason.BusinessRule);
            }
        }

    }
}
