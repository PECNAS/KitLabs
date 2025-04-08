using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Represitories;
using System.Security.Cryptography;
using WebApplication1.SignDto;

namespace WebApplication1.Controllers
{
	public class RegistrationController : Controller
	{
		MobileContext db;

		public RegistrationController(MobileContext db)
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
			var login= HttpContext.Session.GetString("login");
			if (login != null)
			{
				return Redirect("~/Catalog");
			}
			return View("~/Views/Reg.cshtml");
		}

		[HttpPost]
		public IActionResult Index(SignUpDto signUp)
		{
			var us_rep = new UserRepositoriesImpl(db);
			User user = us_rep.GetUserByLogin(signUp.Login);

			if (user == null)
			{
				User new_user = new User
				{
					FirstName = signUp.FirstName,
                    SecondName = signUp.SecondName,
                    ThirdName = signUp.ThirdName,
                    Password = GetHashString(signUp.Password),
					Login = signUp.Login,
					Group = signUp.Group,
					Role = "User",
					Avatar = "/",
				};
				us_rep.SaveUser(new_user);
                HttpContext.Session.SetString("login", new_user.Login);

				return Redirect("~/Profile");
            }

			ViewBag.Error = "Пользователь с такими данными уже существует, пожалуйста, войдите в свой аккаунт";
			return View("~/Views/Reg.cshtml");
		}
	}
}
