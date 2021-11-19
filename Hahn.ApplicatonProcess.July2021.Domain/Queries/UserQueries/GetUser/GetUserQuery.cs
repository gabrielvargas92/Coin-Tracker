using Hahn.ApplicatonProcess.July2021.Domain.Dto.User;
using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Queries.UserQueries.GetUser
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public int Id { get; set; }
    }
}
