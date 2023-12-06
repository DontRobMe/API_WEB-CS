using Microsoft.EntityFrameworkCore;
using TP_CS.Business.IRepositories;
using TP_CS.Business.Models;
using TP_CS.Data.Context;

namespace TP_CS.Data.Repositories
{
    public class DatabaseUserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public DatabaseUserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public User CreateUser(User newUser, Team team)
        {
            _dbContext.Teams?.FirstOrDefault(u => u.Id == team.Id)?.Users.Add(newUser);
            _dbContext.Users?.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public void DeleteUser(long userId)
        {
            var user = _dbContext.Users?.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _dbContext.Users?.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<User>? GetUsers()
        {
            return _dbContext.Users?
                .Include(b => b.UserTasks)
                .ThenInclude(t => t.Tags)
                .ToList();
        }

        public User GetUserById(long? userId)
        {
            return _dbContext.Users?.FirstOrDefault(u => u.Id == userId)
                   ?? throw new InvalidOperationException("Utilisateur introuvable");
        }

        public BusinessResult<User> UpdateUser(long userId, User updatedUser)
        {
            var user = _dbContext.Users?.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.Nom = updatedUser.Nom;
            }
            else
            {
                throw new InvalidOperationException("User introuvable");
            }

            _dbContext.SaveChanges();
            return BusinessResult<User>.FromSuccess(user);
        }
    }
}