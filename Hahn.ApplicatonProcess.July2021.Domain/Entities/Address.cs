using Hahn.ApplicatonProcess.July2021.Domain.Contracts;

namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class Address : IEntity<int>
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}