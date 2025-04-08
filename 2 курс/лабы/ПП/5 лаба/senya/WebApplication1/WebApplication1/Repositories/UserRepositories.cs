using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Represitories
{
    public interface UserRepositories
    {

        User GetUserByLogin(string login);
        void SaveUser(User user);
    }
}
