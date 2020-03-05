using GreatStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GreatStore.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}
