using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Domain.Queries
{
    public class GetAssetQuery : IRequest<AssetResponse>
    {
        public int Id { get; set; }
    }
}
