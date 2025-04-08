using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Repositories;
using WebApplication1.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Controllers
{
    public class GptController : Controller
    {
        MobileContext db;
        public GptController(MobileContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.Name != null)
            {
                UserRepositoriesImpl us_rep = new UserRepositoriesImpl(db);
                User user = us_rep.GetUserByEmail(User.Identity.Name);
                ViewBag.user = user;
            }
            return View("~/Views/Gpt.cshtml");
        }

        public object gpt_build(string gpu, string ozu, string type)
        {
            string prompt = $"собери для меня {type} компьютер." +
            $"Минимальное количество ОЗУ - {ozu}." +
            $"Минимальное количество видеопамяти - {gpu}. " +
            $"В качестве ответа дай названия всех компонентов." +
            $"После каждого компонента нужно написать <br>";
            //string prompt = "Привет! собери для меня игровой компьютер. В качестве названия выведи названия всех компонентов";

            Task<object> task = GptAsync(prompt);
            task.Wait();
            object res = task.Result;

            return res;
        }

        
        async Task<object> GptAsync(string prompt)
        {
            ItemRepositoriesImpl it_rep = new ItemRepositoriesImpl(this.db);
            var history_dict = new Dictionary<string, string>()
            {
                { "content", it_rep.GetItemsForGpt() },
                { "role", "user" },
            };

            var prompt_dict = new Dictionary<string, string>()
            {
                { "content", prompt },
                { "role", "user" }
            };

            using (HttpClient client = new HttpClient())
            {
                StringContent json_content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        model = "gpt-3.5-turbo",
                        provider = "Liaobots",
                        stream = false,
                        messages = new List<Dictionary<string, string>>() { prompt_dict }
                    }),
                    Encoding.UTF8,
                    "application/json");
                var response = await client.PostAsync("http://localhost:1337/v1/chat/completions", json_content);

                if (response != null)
                {
                    var json_string_result = await response.Content.ReadAsStringAsync();
                    return json_string_result;
                }
            }
            return new { res = "api error" };
        }
    }
}
