using Rotina.Domain.Entities;

namespace Rotina.DomainService.IRepositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<LoginEntity> Login { get; }
        IGenericRepository<UserEntity> User { get; }
    }
}
