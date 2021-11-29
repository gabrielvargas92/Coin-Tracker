using CoinTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinTracker.Data
{
    public class HahnDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Asset> Asset { get; set; }

        public HahnDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
