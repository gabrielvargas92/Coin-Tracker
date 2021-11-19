using Hahn.ApplicatonProcess.July2021.Domain.Commands.UserCommands.CreateUser;
using Hahn.ApplicatonProcess.July2021.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class User : IEntity<int>
    {
        public User() { }
        public User(CreateUserCommand request)
        {
            Age = request.Age;
            FirstName = request.FirstName;  
            LastName = request.LastName;
            Email = request.Email;
            Address = new Address
            {
                Number = request.Address.Number,
                PostalCode = request.Address.PostalCode,
                Street = request.Address.Street,
            };
        }

        public int Id { get; set; }
        public int Age { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        
        public string Email { get;  set; }
        public virtual Address Address { get;  set; }
    }
}
