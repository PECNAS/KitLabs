using System.Data;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Group { get; set; }
        public string Avatar { get; set; }
	}
}
