using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Models;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace WebApplication1.Represitories
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
            User us = _context.Users.FirstOrDefault(x => x.Login == user.Login);

            if (us != null)
            {
                _context.Users.Update(user);
            } else
            {
                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }

        public User GetUserByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login== login);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
