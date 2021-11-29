using CoinTracker.Domain.Contracts.Repository;
using CoinTracker.Domain.Dto.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoinTracker.Domain.Queries.UserQueries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IUserRepository userRepository;

        public GetUserQueryHandler(IUserRepository UserRepository)
        {
            userRepository = UserRepository;
        }

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = await userRepository.GetByIdAsync(request.Id, p => p.Address);

            return new UserResponse();
        }
    }
}
