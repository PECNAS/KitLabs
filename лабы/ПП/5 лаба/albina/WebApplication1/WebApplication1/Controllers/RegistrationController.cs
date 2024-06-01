using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class RegistrationController : Controller
    {
        MobileContext db;
        public RegistrationController(MobileContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Registration(string email, string psswd)
        {
            UserRepositoriesImpl us = new UserRepositoriesImpl(db);
            if (us.GetUserByEmail(email) != null)
            {
                ViewBag.Error = $"Ошибка! Пользователь с email {email} уже существует";
                return View("~/Views/Login.cshtml");
            }

            psswd = MobileContext.GetHashString(psswd);

            User user = new User
            {
                Email = email,
                Password = psswd,
                Role = "user"
            };
            us.SaveUser(user);

            return Redirect("~/Profile");
        }
    }
}
