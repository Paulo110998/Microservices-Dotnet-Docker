using Microsoft.EntityFrameworkCore;
using ConsumerService.Models;
using System.Collections.Generic;

namespace ConsumerService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Item> Items { get; set; }
}
