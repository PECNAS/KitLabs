using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class ProfileController : Controller
    {
        MobileContext db;

        public ProfileController(MobileContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            UserRepositoriesImpl us = new UserRepositoriesImpl(db);
            User user = us.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                ShopCartRepositoriesImpl sc = new ShopCartRepositoriesImpl(db);
                ViewBag.user = user;
                ViewBag.cart = sc.GetItems(user.UserId);

                return View("~/Views/Profile.cshtml");
            } else return Redirect("~/Login");
        }

        [HttpPost]
        public IActionResult Update(string psswd)
        {
            var us_rep = new UserRepositoriesImpl(db);
            User user = us_rep.GetUserByEmail(User.Identity.Name);
            us_rep.UpdatePsswd(user, psswd);

            return Redirect("~/Logout");
        }

        [HttpPost]
        public IActionResult BuyAll()
        {
            var it_rep = new ItemRepositoriesImpl(db);
            it_rep.BuyAll(User.Identity.Name);

            return Redirect("~/Profile");
        }
    }
}
