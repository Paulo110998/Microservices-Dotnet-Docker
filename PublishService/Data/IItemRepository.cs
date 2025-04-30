using Microsoft.AspNetCore.Mvc;
using PublishService.Models;

namespace PublishService.Data;

public interface IItemRepository
{
    void SaveChanges();
    IEnumerable<Item> GetAllItems();
    Item GetItemById(int id);  
    void CreateItem(Item item);

}
