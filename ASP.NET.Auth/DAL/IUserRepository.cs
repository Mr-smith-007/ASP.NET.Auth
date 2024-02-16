using System.Collections.Generic;
using ASP.NET.Auth.BLL.Models;

namespace ASP.NET.Auth.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
    }
}
