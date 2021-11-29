using CoinTracker.Domain.Dto.User;
using MediatR;

namespace CoinTracker.Domain.Queries.UserQueries.GetUser
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public int Id { get; set; }
    }
}
