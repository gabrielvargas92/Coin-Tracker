using CoinTracker.Domain.Contracts.Repository;
using CoinTracker.Domain.Dto.User;
using CoinTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoinTracker.Domain.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository userRepository;
        public CreateUserCommandHandler(IUserRepository UserRepository)
        {
            userRepository = UserRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request);

            userRepository.Add(user);

            await userRepository.SaveChangesAsync();

            return new CreateUserCommandResponse();
        }
    }
}
