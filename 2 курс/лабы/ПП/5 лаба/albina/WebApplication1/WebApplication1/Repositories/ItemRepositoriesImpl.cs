using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ItemRepositoriesImpl : ItemRepositories
    {
        private MobileContext _context;
        public ItemRepositoriesImpl(MobileContext context)
        {
            this._context = context;
        }
        
        public Item GetItemById(int item_id)
        {
            Item item = _context.Items.FirstOrDefault(x => x.ItemId == item_id);
            return item;
        }

        public string GetItemsForGpt()
        {
            string result = "В нашем онлайн-магазине техники есть следующие товары: ";
            foreach(Item item in _context.Items)
            {
                result += $"Название:{item.Title}, цена: {item.Price}\n";
            }
            return result;
        }

        public void BuyAll(string email)
        {
            User user = _context.Users.First(x => x.Email == email);
            var carts = _context.ShopCarts.Where(x => x.UserId == user.UserId);
            List<Item> items_list = new List<Item>();

            foreach (ShopCart sc in carts)
            {
                var item = _context.Items.First(x => x.ItemId == sc.ItemId);
                items_list.Add(item);
                _context.Items.Remove(item);
                _context.ShopCarts.Remove(sc);
            }
            _context.SaveChanges();
        }
    }
}
