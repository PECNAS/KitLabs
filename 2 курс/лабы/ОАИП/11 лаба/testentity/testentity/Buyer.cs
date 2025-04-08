using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string FirstBuyDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Buyer()
        {

        }

        public Buyer(string Name, string Surname, string Email, string Password,
            DateOnly BDate, string PhoneNumber, string Adress, DateOnly FirstBuyDate)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Password = Password;
            this.BDate = BDate.ToString();
            this.PhoneNumber = PhoneNumber;
            this.Adress = Adress;
            this.FirstBuyDate = FirstBuyDate.ToString();
        }
    }
}
