using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ItemRepositories
    {
        Item GetItemById(int item_id);
        string GetItemsForGpt();
        void BuyAll(string email);
    }
}
