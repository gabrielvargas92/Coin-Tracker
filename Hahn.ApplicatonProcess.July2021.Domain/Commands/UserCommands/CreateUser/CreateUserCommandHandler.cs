using Hahn.ApplicatonProcess.July2021.Domain.Contracts.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Dto.User;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Commands.UserCommands.CreateUser
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
