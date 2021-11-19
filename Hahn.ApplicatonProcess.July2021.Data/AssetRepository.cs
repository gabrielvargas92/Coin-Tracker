using Hahn.ApplicatonProcess.July2021.Domain.Contracts.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class AssetRepository :
        BaseRepository<Asset, int, HahnDbContext>, IAssetRepository
    {
        public AssetRepository(HahnDbContext context) : base(context) { }
    }
}
