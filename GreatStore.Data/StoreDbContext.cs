using GreatStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GreatStore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
