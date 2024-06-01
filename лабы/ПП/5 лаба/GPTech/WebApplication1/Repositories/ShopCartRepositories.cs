using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ShopCartRepositories
    {
        void AddItem(int item_id, int user_id);
        void RemoveItem(int item_id, int user_id);
        Dictionary<Item, int> GetItems(int user_id);
        int GetCount(int item_id, int user_id);
    }
}
