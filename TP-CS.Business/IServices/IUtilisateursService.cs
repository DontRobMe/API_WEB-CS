using System.Collections.Generic;
using TP_CS.Business.Models;

namespace TP_CS.Business.IServices
{
    public interface IUtilisateursService
    {
        public BusinessResult<IEnumerable<User>> GetUsers();

        public BusinessResult<User> GetUserById(long id);

        public BusinessResult<User> CreateUser(User item);

        public BusinessResult UpdateUser(long id, User model);

        public BusinessResult DeleteUser(long id);
    }
}