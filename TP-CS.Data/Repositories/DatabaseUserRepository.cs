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

        public User CreateUser(User newUser)
        {
            try
            {
                _dbContext.Users?.Add(newUser);
                _dbContext.SaveChanges();
                // Log successful user creation
                Console.WriteLine("Utilisateur ajouté à la base de données !");
                return newUser;
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during user creation
                Console.WriteLine($"Erreur lors de l'ajout de l'utilisateur à la base de données : {ex.Message}");
                throw; // Rethrow the exception to handle it in the service layer
            }
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
            return _dbContext.Users?.ToList();
        }

        public User GetUserById(long userId)
        {
            return _dbContext.Users?.FirstOrDefault(u => u.Id == userId)
                   ?? throw new InvalidOperationException("Utilisateur introuvable");
        }

        public BusinessResult<User> UpdateUser(long userId, User updatedUser)
        {
            try
            {
                var user = _dbContext.Users?.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.Nom = updatedUser.Nom;
                    int affected = _dbContext.SaveChanges();

                    // Vérification du nombre d'entités affectées par SaveChanges
                    if (affected > 0)
                    {
                        return BusinessResult<User>.FromSuccess(user);
                    }
                    else
                    {
                        return BusinessResult<User>.FromError("Aucune modification enregistrée.",
                            BusinessErrorReason.BusinessRule);
                    }
                }
                else
                {
                    return BusinessResult<User>.FromError($"L'utilisateur avec l'ID {userId} n'a pas été trouvé.",
                        BusinessErrorReason.NotFound);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult<User>.FromError(
                    $"Erreur lors de la mise à jour de l'utilisateur avec l'ID {userId}.",
                    BusinessErrorReason.BusinessRule);
            }
        }

    }
}