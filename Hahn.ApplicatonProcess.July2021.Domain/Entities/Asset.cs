using Hahn.ApplicatonProcess.July2021.Domain.Contracts;

namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class Asset : IEntity<string>
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
