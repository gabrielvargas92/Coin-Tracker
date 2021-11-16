using Hahn.ApplicatonProcess.July2021.Domain.Contracts.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Dto.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository userRepository;
        public CreateUserCommandHandler(IUserRepository UserRepository)
        {
            UserRepository = userRepository;
        }

        public Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
