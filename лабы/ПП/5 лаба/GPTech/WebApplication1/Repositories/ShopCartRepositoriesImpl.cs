using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ShopCartRepositoriesImpl : ShopCartRepositories
    {
        private MobileContext _context;
        public ShopCartRepositoriesImpl(MobileContext context)
        {
            this._context = context;
        }
        
        public void AddItem(int item_id, int user_id)
        {
            _context.ShopCarts.Add(
                new ShopCart
                {
                    ItemId = item_id,
                    UserId = user_id
                });
            _context.SaveChanges();
        }

        public void RemoveItem(int item_id, int user_id)
        {
            ShopCart sc = _context.ShopCarts.FirstOrDefault(x => x.ItemId == item_id && x.UserId == user_id);
            _context.ShopCarts.Remove(sc);
            _context.SaveChanges();
        }

        public Dictionary<Item, int> GetItems(int user_id)
        {
            ItemRepositoriesImpl it = new ItemRepositoriesImpl(_context);
            //List<Item> items = new List<Item> { };
            Dictionary<Item, int> items = new Dictionary<Item, int> { };

            var carts = _context.ShopCarts.Where(x => x.UserId == user_id);

            foreach(ShopCart cart in carts)
            {
                Item item = it.GetItemById(cart.ItemId);
                if (items.TryGetValue(item, out int value))
                {
                    items[item] = value + 1;
                }
                else items.Add(item, 1);
            }

            return items;
        }

        public int GetCount(int item_id, int user_id)
        {
            return _context.ShopCarts.Where(x => x.ItemId == item_id && x.UserId == user_id).Count();
        }
    }
}
