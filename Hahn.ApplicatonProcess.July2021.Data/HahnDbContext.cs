using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class HahnDbContext : DbContext
    {
        public HahnDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
