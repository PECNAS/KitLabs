using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Researcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BDate { get; set; }
        public string PhoneNumber { get; set; }
        public string ResearchLocation { get; set; }
        public string FirstPublicDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Researcher()
        {

        }

        public Researcher(string Name, string Surname, string Email, string Password,
            string BDate, string PhoneNumber, string ResearchLocation, string FirstPublicDate)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Password = Password;
            this.BDate = BDate;
            this.PhoneNumber = PhoneNumber;
            this.ResearchLocation = ResearchLocation;
            this.FirstPublicDate = FirstPublicDate;
        }
    }
}
