using CoinTracker.Domain.Contracts.Repository;
using CoinTracker.Domain.Entities;

namespace CoinTracker.Data
{
    public class UserRepository :
        BaseRepository<User, int, HahnDbContext>, IUserRepository
    {
        public UserRepository(HahnDbContext context) : base(context) { }
    }
}
