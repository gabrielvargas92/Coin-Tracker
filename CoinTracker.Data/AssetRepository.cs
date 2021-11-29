using CoinTracker.Domain.Contracts.Repository;
using CoinTracker.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoinTracker.Data
{
    public class AssetRepository :
        BaseRepository<Asset, int, HahnDbContext>, IAssetRepository
    {
        public AssetRepository(HahnDbContext context) : base(context) { }
    }
}
