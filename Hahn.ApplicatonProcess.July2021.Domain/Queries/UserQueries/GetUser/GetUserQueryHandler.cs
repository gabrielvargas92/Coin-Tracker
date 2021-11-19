using Hahn.ApplicatonProcess.July2021.Domain.Contracts.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Dto.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Queries.UserQueries.GetUser
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
