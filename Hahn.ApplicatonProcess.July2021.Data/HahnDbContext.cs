using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.July2021.Data
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
