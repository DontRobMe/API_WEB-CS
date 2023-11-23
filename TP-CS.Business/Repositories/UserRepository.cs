using System;
using System.Collections.Generic;
using System.Linq;
using TP_CS.Business.Models;

namespace TP_CS.Business.Repositories
{
    public class UserRepository
    {
        public void CreateUser(User newUser)
        {
            newUser.Id = User._nextUserId;
            User._users.Add(newUser);
            User._nextUserId++;
        }

        public void DeleteUser(long userId)
        {
            var user = User._users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                User._users.Remove(user);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            if (User._users.Count == 0)
            {
                throw new InvalidOperationException("Aucun utilisateur");
            }
            return User._users;
        }

        public User GetUserById(long userId)
        {
            var user = User._users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new InvalidOperationException("Utilisateur introuvable");
            }
            return user;
        }

        public void UpdateUser(long userId, User updatedUser)
        {
            var user = User._users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.Nom = updatedUser.Nom;
            }
        }
    }
}