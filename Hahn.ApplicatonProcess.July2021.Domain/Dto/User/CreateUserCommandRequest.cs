using MediatR;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.July2021.Domain.Dto.User
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressCommandRequest Address { get; set; }
        public ICollection<AssetCommandRequest> Assets { get; set; }
    }
}
