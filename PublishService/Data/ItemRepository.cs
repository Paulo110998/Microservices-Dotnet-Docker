using PublishService.Models;

namespace PublishService.Data;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateItem(Item item)
    {
       if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

       _context.Items.Add(item);
    }

    public IEnumerable<Item> GetAllItems()
    {
        return _context.Items.ToList();
    }

    public Item GetItemById(int id) => _context.Items.FirstOrDefault(item => item.Id == id);
   

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
