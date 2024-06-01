using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepositoriesImpl : UserRepositories
    {
        private MobileContext _context;
        public UserRepositoriesImpl(MobileContext context)
        {
            this._context = context;
        }
        public void SaveUser(User user)
        {
            user.Role = "user";
            _context.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email == email);

            return user;
        }

        public User GetUserById(int user_id)
        {
            User user = _context.Users.FirstOrDefault(x => x.UserId == user_id);
            return user;
        }

        public void DeleteUserByEmail(string email)
        {
            User user = _context.Users.First(x => x.Email == email);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdatePsswd(User user, string psswd)
        {
            psswd = MobileContext.GetHashString(psswd);
            user.Password = psswd;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
