using MediatR;

namespace CoinTracker.Domain.Commands.CreateAssetCommands
{
    public class CreateAssetCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
