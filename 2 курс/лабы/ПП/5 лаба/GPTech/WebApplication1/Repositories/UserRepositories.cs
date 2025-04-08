using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface UserRepositories
    {
        User GetUserByEmail(string email);
        User GetUserById(int user_id);
        void SaveUser(User user);
    }
}
