using Hahn.ApplicatonProcess.July2021.Domain.Contracts.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class UserRepository :
        BaseRepository<User, int, HahnDbContext>, IUserRepository
    {
        public UserRepository(HahnDbContext context) : base(context) { }
    }
}
