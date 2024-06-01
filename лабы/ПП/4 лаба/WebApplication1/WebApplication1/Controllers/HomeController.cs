using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string nbr)
        {
            ViewBag.res = (Convert.ToInt32(nbr) / 7);
            ViewBag.ost = (Convert.ToInt32(nbr) % 7);
            ViewBag.n = (Convert.ToInt32(nbr));
            if (Convert.ToInt32(nbr) % 7 == 0) ViewBag.Message = "Число кратно 7";
            else ViewBag.Message = "Число не кратно 7";

            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(string row)
        {
            string res = "";
            int counter = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == 'с' || row[i] == 'c' || row[i] == 'С' || row[i] == 'C') counter++;
                else res += row[i];
            }

            for (int i = 0; i < counter; i++)
            {
                res += '_';
            }

            ViewBag.result = res;


            return View();
        }

        [HttpGet]
        public ActionResult Third()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Third(string array)
        {
            string[] mas = array.Split(';');
            int quad = 0;
            int cube = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (int.TryParse(mas[i], out int value))
                {
                    if (i % 2 == 0) quad += (int)(Math.Pow(value, 2));
                    else cube += (int)(Math.Pow(value, 3));
                } else {
                    ViewBag.quad = "Неверный формат ввода";
                    ViewBag.cube = "Неверный формат ввода";
                    return View();
                }
            }

            ViewBag.quad = quad;
            ViewBag.cube = cube;
            return View();
        }
    }
}
