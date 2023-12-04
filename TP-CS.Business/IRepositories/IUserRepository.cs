using System.Collections.Generic;
using TP_CS.Business.Models;

namespace TP_CS.Business.IRepositories
{
    public interface IUserRepository
    {
        User CreateUser(User newUser, Team team);
        
        void DeleteUser(long userId);
        
        IEnumerable<User>? GetUsers();
        
        User GetUserById(long userId);
        
        BusinessResult<User> UpdateUser(long userId, User updatedUser);
    }
}