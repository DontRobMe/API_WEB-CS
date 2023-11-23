using System.Collections.Generic;
using TP_CS.Business.Models;

namespace TP_CS.Business.IRepositories
{
    public interface IUserRepository
    {
        void CreateUser(User newUser);
        
        void DeleteUser(long userId);
        
        IEnumerable<User> GetUsers();
        
        User GetUserById(long userId);
        
        void UpdateUser(long userId, User updatedUser); 
    }
}