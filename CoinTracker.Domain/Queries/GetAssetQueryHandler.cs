using CoinTracker.Domain.Contracts.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinTracker.Domain.Queries
{
    public class GetAssetQueryHandler : IRequestHandler<GetAssetQuery, AssetResponse>
    {
        private readonly IAssetRepository assetRepository;

        public GetAssetQueryHandler(IAssetRepository AssetRepository)
        {
            assetRepository = AssetRepository;
        }

        public async Task<AssetResponse> Handle(GetAssetQuery request, CancellationToken cancellationToken)
        {
            var response = assetRepository.GetById(request.Id);

            return new AssetResponse();
        }
    }
}
