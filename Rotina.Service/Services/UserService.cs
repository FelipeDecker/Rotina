using Rotina.Domain.Commands;
using Rotina.Domain.Entities;
using Rotina.DomainService.Expressions;
using Rotina.DomainService.Factories;
using Rotina.DomainService.IRepositories;
using Rotina.DomainService.IServices;
using Rotina.DomainService.Validators;
using System;
using System.Threading.Tasks;

namespace Rotina.Service.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly UserValidator _userValidator;
        private readonly UserFactory _userFactory;

        public UserService(IUnitOfWork repUnitOfWork) 
            : base(repUnitOfWork)
        {
            _userValidator = new UserValidator();
            _userFactory = new UserFactory();
        }

        public async Task Add(UserCommand command)
        {
            _userValidator.Add(command);

            UserEntity userDuplicate = await _repUnitOfWork.User.FindFirstAsync(UserExpression.FindByEmail(command.Email));

            if (userDuplicate != null)
                GenerateError("Email already registered");

            await _repUnitOfWork.User.AddAsync(_userFactory.Add(command));
        }

        public async Task Update(UserCommand command)
        {
            _userValidator.Update(command);

            UserEntity user = await _repUnitOfWork.User.FindFirstAsync(UserExpression.FindById(Guid.Parse(command.Id)));

            if (user != null)
                GenerateError("User not found");

            if (command.Email != user.Email)
            {
                UserEntity userDuplicate = await _repUnitOfWork.User.FindFirstAsync(UserExpression.FindByEmail(command.Email));

                if (userDuplicate != null)
                    GenerateError("Email already registered");
            }

            await _repUnitOfWork.User.UpdateAsync(_userFactory.Update(command));
        }

        public async Task Delete(string id)
        {
            UserEntity user = await _repUnitOfWork.User.FindFirstAsync(UserExpression.FindById(Guid.Parse(id)));

            if (user != null)
                GenerateError("User not found");

            await _repUnitOfWork.User.UpdateAsync(user.Delete());
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _repUnitOfWork.User.FindFirstAsync(UserExpression.FindByEmail(email));
        }

        public async Task<UserEntity> FindById(string id)
        {
            return await _repUnitOfWork.User.FindFirstAsync(UserExpression.FindById(Guid.Parse(id)));
        }

        public async Task<UserEntity> FindAllByName(string name, decimal page = 1, decimal amount = 10)
        {
            return await _repUnitOfWork.User.FindFirstAsync(UserExpression.FindByName(name));
        }
    }
}
