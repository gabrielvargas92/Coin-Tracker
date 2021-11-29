using System;

namespace CoinTracker.Domain.Contracts
{
    public interface IEntity<T> where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}
