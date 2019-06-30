using System.Collections.Generic;

namespace havuclukek.security.Authorization
{
    public interface IUserService
    {
        AuthToken Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
