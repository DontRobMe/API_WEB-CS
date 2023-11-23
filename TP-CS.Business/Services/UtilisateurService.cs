#nullable enable
using System;
using System.Collections.Generic;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;


namespace TP_CS.Business.Services
{
    public class UtilisateurService : IUtilisateursService
    {
        private readonly List<User> _users;

        public UtilisateurService(List<User> users)
        {
            _users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public BusinessResult<List<User>> GetUsers()
        {
            try
            {
                return BusinessResult<List<User>>.FromSuccess(_users);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<User>>.FromError("Erreur lors de la récupération des utilisateurs.", BusinessErrorReason.BusinessRule);
            }
        }

        public BusinessResult<User?> GetUserById(long id)
        {
            try
            {
                User? user = _users.Find(u => u.id == id);
                if (user != null)
                {
                    return BusinessResult<User?>.FromSuccess(user);
                }
                else
                {
                    return BusinessResult<User?>.FromError($"L'utilisateur avec l'ID {id} n'a pas été trouvé.", BusinessErrorReason.NotFound);
                }
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
                item.id = ++User._nextUserId;
                _users.Add(item);
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
                User? existingUser = _users.Find(u => u.id == id);
                if (existingUser != null)
                {
                    existingUser.Nom = model.Nom;
                    return BusinessResult<User>.FromSuccess(existingUser);
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
                User? userToRemove = _users.Find(u => u.id == id);
                if (userToRemove != null)
                {
                    _users.Remove(userToRemove);
                    return BusinessResult.FromSuccess();
                }
                else
                {
                    return BusinessResult.FromError($"L'utilisateur avec l'ID {id} n'a pas été trouvé.", BusinessErrorReason.NotFound);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult.FromError($"Erreur lors de la suppression de l'utilisateur avec l'ID {id}.", BusinessErrorReason.BusinessRule);
            }
        }
    }
}
