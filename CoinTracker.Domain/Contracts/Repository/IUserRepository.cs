using CoinTracker.Domain.Entities;

namespace CoinTracker.Domain.Contracts.Repository
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
    }
}
