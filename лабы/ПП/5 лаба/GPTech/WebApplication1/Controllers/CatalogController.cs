using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        MobileContext db;
        public CatalogController(MobileContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.Name != null)
            {
                UserRepositoriesImpl us = new UserRepositoriesImpl(db);
                ViewBag.user = us.GetUserByEmail(User.Identity.Name);
            }

            ViewBag.items_array = db.Items.ToArray();
            ViewBag.items_count = db.Items.Count();
            return View("~/Views/Catalog.cshtml");
        }

        public object AddToCart(int item_id, int user_id)
        {
            ShopCartRepositoriesImpl sc = new ShopCartRepositoriesImpl(db);
            sc.AddItem(item_id, user_id);

            return new { item_id = item_id, count = sc.GetCount(item_id, user_id) };
        }

        [HttpGet]
        public IActionResult Item(int ItemId)
        {
            var it_rep = new ItemRepositoriesImpl(db);
            var us_rep = new UserRepositoriesImpl(db);

            Item item = it_rep.GetItemById(ItemId);
            User user = us_rep.GetUserByEmail(User.Identity.Name);

            ViewBag.item = item;
            ViewBag.user = user;

            return View("~/Views/Item.cshtml");
        }
    }
}
