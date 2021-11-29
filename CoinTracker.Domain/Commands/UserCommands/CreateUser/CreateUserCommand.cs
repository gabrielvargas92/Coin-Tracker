using CoinTracker.Domain.Dto.User;
using MediatR;
using System.Collections.Generic;

namespace CoinTracker.Domain.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressCommandRequest Address { get; set; }
        public ICollection<AssetCommandRequest> Assets { get; set; }
    }
}
