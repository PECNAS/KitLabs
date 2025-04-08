using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        MobileContext db;

        public LoginController(MobileContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult Delete()
        {
            if (User.Identity.Name != null)
            {
                UserRepositoriesImpl us_rep = new UserRepositoriesImpl(db);
                us_rep.DeleteUserByEmail(User.Identity.Name);
                return Redirect("~/Login/Logout");
            }

            return Redirect("~/Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string psswd)
        {
            UserRepositoriesImpl us = new UserRepositoriesImpl(db);
            User user = us.GetUserByEmail(email);

            psswd = MobileContext.GetHashString(psswd);

            if (user != null && user.Password == psswd)
            {
                await Authenticate(email); // аутентификация

                return Redirect("~/Profile");
            }
            ViewBag.Error = $"Неверный email или пароль";
            return View("~/Views/Login.cshtml");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/Login");
        }
    }
}
