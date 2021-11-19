using System;

namespace Hahn.ApplicatonProcess.July2021.Domain.Contracts
{
    public interface IEntity<T> where T : IEquatable<T>
    {
        T Id { get; set;  }
    }
}
