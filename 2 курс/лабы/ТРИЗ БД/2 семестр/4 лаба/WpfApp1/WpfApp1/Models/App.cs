using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class App
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
    }
}
