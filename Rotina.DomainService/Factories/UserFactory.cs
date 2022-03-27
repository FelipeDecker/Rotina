using Rotina.Domain.Commands;
using Rotina.Domain.Entities;
using System;

namespace Rotina.DomainService.Factories
{
    public class UserFactory
    {
        public UserEntity Entity { get; set; }

        public UserFactory()
        {
            Entity = new UserEntity();
        }

        public UserEntity Add(UserCommand command)
        {
            Entity.Add(command.Name, command.Email, command.Password);

            return Entity;
        }

        public UserEntity Update(UserCommand command)
        {
            Entity.Update(Guid.Parse(command.Id), command.Name, command.Email, command.Password);

            return Entity;
        }
    }
}
