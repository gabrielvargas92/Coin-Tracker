using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Dto.User
{
    public class AddressCommandRequest : IRequest<AddressCommandResponse>
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}