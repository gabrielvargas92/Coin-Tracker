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
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Email { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
