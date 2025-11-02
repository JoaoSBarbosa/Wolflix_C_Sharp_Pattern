using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolflix.Domain.Exceptions;

namespace Wolflix.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public User(string name, string email) { 
        
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            valid();
        }

        private void valid()
        {
            if (String.IsNullOrWhiteSpace(Name)) throw new EntityValidRequest("O Nome é obrigatório");
            if (String.IsNullOrWhiteSpace(Email)) throw new EntityValidRequest("O E-mail é obrigatório");
        }
    }
}
