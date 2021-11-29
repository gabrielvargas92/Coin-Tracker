using CoinTracker.Domain.Commands.CreateAssetCommands;
using CoinTracker.Domain.Contracts;

namespace CoinTracker.Domain.Entities
{
    public class Asset : IEntity<int>
    {
        public Asset()
        {

        }
        public Asset(CreateAssetCommand command)
        {
            Symbol = command.Symbol;
            Name = command.Name;
        }
        public int Id { get; set; }
        public string Symbol { get; private set; }
        public string Name { get; private set; }
    }
}
