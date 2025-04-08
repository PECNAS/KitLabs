using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class ShopCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string BuyDate { get; set; }
        public bool InOrder { get; set; } // поле обозначает, находится ли связь сейчас в корзине или был куплен
    }
}
