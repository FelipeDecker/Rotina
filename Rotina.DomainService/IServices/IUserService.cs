using Rotina.Domain.Commands;
using Rotina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.DomainService.IServices
{
    public interface IUserService
    {
        Task Add(UserCommand command);

        Task Update(UserCommand command);

        Task Delete(string id);

        Task<UserEntity> FindById(string id);

        Task<UserEntity> FindByEmail(string email);

        Task<UserEntity> FindAllByName(string name, decimal page = 1, decimal amount = 10);
    }
}
