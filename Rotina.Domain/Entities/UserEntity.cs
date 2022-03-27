using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Active = 1;
        }

        public UserEntity Add(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Active = 1;

            return this;
        }

        public UserEntity Update(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;

            return this;
        }

        public UserEntity Delete()
        {
            Active = 0;

            return this;
        }
    }
}
