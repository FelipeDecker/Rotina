using Rotina.Domain.Commands;
using Rotina.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rotina.DomainService.IServices
{
    public interface ILoginService
    {
        Task<TokenEntity> GenerateToken(LoginCommand command);

        Task<List<LoginEntity>> FindAllByUser(decimal idUser);
    }
}
