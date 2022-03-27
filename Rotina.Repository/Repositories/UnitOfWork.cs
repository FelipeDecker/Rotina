using Rotina.Domain.Entities;
using Rotina.DomainService.IRepositories;
using Rotina.Repository.Contexts;

namespace Rotina.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private GenericRepository<LoginEntity> LoginRepository = null;
        private GenericRepository<UserEntity> UserRepository = null;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<LoginEntity> Login
        {
            get
            {
                if (LoginRepository == null)
                {
                    LoginRepository = new GenericRepository<LoginEntity>(_context);
                }

                return LoginRepository;
            }
        }

        public IGenericRepository<UserEntity> User
        {
            get
            {
                if (UserRepository == null)
                {
                    UserRepository = new GenericRepository<UserEntity>(_context);
                }

                return UserRepository;
            }
        }
    }
}
