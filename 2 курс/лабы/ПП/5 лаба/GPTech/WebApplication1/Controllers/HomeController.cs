using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("~/Catalog");
        }
    }
}
