using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketQuest { get; set; }
        public string Image { get; set; }
        public int TrueAnswer { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }

    }
}
