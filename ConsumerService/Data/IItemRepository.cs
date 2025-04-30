using ConsumerService.Models;

namespace ConsumerService.Data;

public interface IItemRepository
{
    IEnumerable<Item> GetAllItems();
    Item GetItemById(int id);
    void AddItem(Item item);
    bool SaveChanges();
}
