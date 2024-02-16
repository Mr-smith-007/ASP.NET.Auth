using System.Collections.Generic;

namespace ASP.NET.Auth
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
    }
}
