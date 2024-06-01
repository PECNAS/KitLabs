using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Represitories;
using System.Security.Cryptography;

namespace WebApplication1.Controllers
{
    public class ProfileController : Controller
    {
        MobileContext db;
        public ProfileController(MobileContext db)
        {
            this.db = db;
        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        public IActionResult Index()
        {
            string login = HttpContext.Session.GetString("login");
            if (login != null)
            {
                var us_rep = new UserRepositoriesImpl(db);
                User user = us_rep.GetUserByLogin(login);
                ViewBag.user = user;
                return View("~/Views/Profile.cshtml");
            }
            return Redirect("~/Login");
        }

        [HttpPost]
        public IActionResult Update(string FirstName, string SecondName, string ThirdName, int Group, string Password)
        {
            var us_rep = new UserRepositoriesImpl(db);
            User user = us_rep.GetUserByLogin(HttpContext.Session.GetString("login"));

            user.FirstName = FirstName;
            user.SecondName = SecondName;
            user.ThirdName = ThirdName;
            user.Group = Group;
            if (GetHashString(Password) != user.Password) {
                user.Password = GetHashString(Password);
            }


            us_rep.SaveUser(user);
            return Redirect("~/Login/Logout");
        }
    }
}
