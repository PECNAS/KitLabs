using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Represitories;
using System.Security.Cryptography;
using WebApplication1.SignDto;

namespace WebApplication1.Controllers
{
	public class LoginController : Controller
	{
        MobileContext db;

        public LoginController(MobileContext db)
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
            var login = HttpContext.Session.GetString("login");
            if (login != null)
            {
                return Redirect("~/Catalog");
            }
            return View("~/Views/Login.cshtml");
		}

        [HttpPost]
        public IActionResult Index(SignInDto signIn)
        {
            var us_rep = new UserRepositoriesImpl(db);
            User user = us_rep.GetUserByLogin(signIn.Login);

            if (user != null)
            {
                if (user.Password == GetHashString(signIn.Password))
                {
                    HttpContext.Session.SetString("login", user.Login);
                    return Redirect("~/Profile");
                }

            }
            ViewBag.Error = "Пользователь с такими данными не найден";
            return View("~/Views/Login.cshtml");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("~/Login");
        }
    }
}
