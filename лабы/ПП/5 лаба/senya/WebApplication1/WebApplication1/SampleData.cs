using WebApplication1.Models;

namespace WebApplication1
{
    public class SampleData
    {
        public static void Initialize(MobileContext context, IWebHostEnvironment env)
        {
            if (!context.Segments.Any())
            {
                context.AddRange(new Segment
                {
                    Title = "Теееехгруппа",
                    Description = "Техгруппа - люди, которые помогают на мероприятиях, делают декорации, таскают декорации, бегают из ленина в 7 и обратно. Короче много че делают",
                    Leader = 2
                },
                new Segment
                {
                    Title = "Театральное направление",
                    Description = "Лучшее направление студенческого совета с лучшим руководом в мире. Хочешь блеснуть своими навыками на сцене или написать свой лучший сценарий? Тогда смело можешь вступать!",
                    Leader = 1
                },
                 new Segment
                 {
                     Title = "Шаман club",
                     Description = "ЭТО МОЙ БОЙ ДО ПОСЛЕДНЕГО ВЗДОХА. Это и ваш бой тоже. Лучший руководитель вокального направления - Насыйбуллин Шаман. Не упусти такую возможность!",
                     Leader = 3
                 }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.AddRange(new User
                {
                    FirstName = "Есения",
                    Login = "achego",
                    SecondName = "Хусаенова",
                    ThirdName = "Данисовна",
                    Group = 4238,
                    Role = "User",
                    Password = "12345678",
                    Avatar = "/imgs/1.jpg"
                },
                new User
                {
                    FirstName = "Владислав",
                    Login = "vlad",
                    SecondName = "Бусов",
                    ThirdName = "Романович",
                    Group = 4238,
                    Role = "User",
                    Password = "87654321",
                    Avatar = "/imgs/2.jpg"
                },
                new User
                {
                    FirstName = "Амир",
                    Login = "amir",
                    SecondName = "Насыйбуллин",
                    ThirdName = "Шамильевич",
                    Group = 4238,
                    Role = "User",
                    Password = "87654321",
                    Avatar = "/imgs/3.jpg"
                });
                context.SaveChanges();
            }
        }
    }
}
