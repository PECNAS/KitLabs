using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    public class SampleData
    {
        public void FillDatabase()
        {
            MobileContext db = new MobileContext();
            if (!db.Categories.Any())
            {
                List<Category> categories = new List<Category>() {
                new Category
                    {
                        Title = "Реклама на билбордах",
                        Description = "Размещение рекламы на городских билбордах и баннерах",
                        Cost = 15000
                    },
                    new Category
                    {
                        Title = "Реклама в кино",
                        Description = "Показ рекламного видеоролика перед начало киносеанса",
                        Cost = 5000
                    },
                    new Category
                    {
                        Title = "Реклама в общ. транспорте",
                        Description = "Размещение ркламных баннеров в обещственном транспорте",
                        Cost = 2500
                    }
                };
                db.Categories.AddRange(categories);
                db.SaveChanges();
            }

            if (!db.Executors.Any())
            {
                List<Executor> execs = new List<Executor>()
                {
                    new Executor
                    {
                        Surname = "Бусов",
                        Name = "Владислав",
                        Post = "Главный рекламщик",
                        Password = "admin",
                        Email = "busovrm4@mail.ru",
                        EmailKey = "z2z2B0nfEEJJFmDdL3EK"
                    },
                    new Executor
                    {
                        Surname = "Борисов",
                        Name = "Ярослав",
                        Post = "Стажер",
                        Password = "executor1",
                        Email = "busovrm4@mail.ru",
                        EmailKey = "z2z2B0nfEEJJFmDdL3EK"
                    },
                    new Executor
                    {
                        Surname = "Филлипов",
                        Name = "Генадий",
                        Post = "Исполнитель",
                        Password = "executor2",
                        Email = "busovrm4@mail.ru",
                        EmailKey = "z2z2B0nfEEJJFmDdL3EK"
                    }
                };
                db.Executors.AddRange(execs);
                db.SaveChanges();
            }
        }
    }
}
