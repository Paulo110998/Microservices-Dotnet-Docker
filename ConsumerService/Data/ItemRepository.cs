using ConsumerService.Models;

namespace ConsumerService.Data;

public class ItemRepository : IItemRepository
{
    private readonly List<Item> _items = new();

    public void AddItem(Item item)
    {
        _items.Add(item);       
    }

    public IEnumerable<Item> GetAllItems()
    {
        return _items;
    }

    public Item GetItemById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public bool SaveChanges()
    {
        // Em um banco de dados real, aqui seria onde commit seria realizado.
        return true;
    }
}
