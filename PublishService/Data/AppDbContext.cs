using Microsoft.EntityFrameworkCore;
using PublishService.Models;

namespace PublishService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
                
    }


    public DbSet<Item> Items { get; set; }
}
