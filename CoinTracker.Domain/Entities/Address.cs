using CoinTracker.Domain.Contracts;

namespace CoinTracker.Domain.Entities
{
    public class Address : IEntity<int>
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}