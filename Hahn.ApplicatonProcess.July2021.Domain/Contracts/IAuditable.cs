using System;

namespace Hahn.ApplicatonProcess.July2021.Domain.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
