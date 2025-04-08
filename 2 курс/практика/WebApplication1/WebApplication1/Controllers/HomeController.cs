using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Context db;
        public HomeController(Context context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            db.Users.Any();
            return View("~/Views/Index.cshtml");
        }

        [HttpPost]
        public object UserLogin(User user)
        {
            User user_in_bd = db.Users.FirstOrDefault(x => x.Email == user.Email);
            if (user_in_bd == null)
            {
                db.Users.Add(new User
                {
                    Email = user.Email,
                    Password = user.Password
                });
                db.SaveChanges();

                user_in_bd = db.Users.FirstOrDefault(x => x.Email == user.Email);
            }
            return user;
        }
    }
}
