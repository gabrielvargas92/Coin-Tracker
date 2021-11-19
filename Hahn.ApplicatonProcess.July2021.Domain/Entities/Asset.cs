using Hahn.ApplicatonProcess.July2021.Domain.Commands.CreateAssetCommands;
using Hahn.ApplicatonProcess.July2021.Domain.Contracts;

namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
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
