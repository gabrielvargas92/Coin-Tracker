using CoinTracker.Domain.Entities;

namespace CoinTracker.Domain.Contracts.Repository
{
    public interface IAssetRepository : IBaseRepository<Asset, int>
    {
    }
}
