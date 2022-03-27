using Rotina.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Rotina.DomainService.Expressions
{
    public static class UserExpression
    {
        public static Expression<Func<UserEntity, bool>> FindById(Guid id, int active = 1)
        {
            return x => x.Id.Equals(id) && x.Active.Equals(active);
        }

        public static Expression<Func<UserEntity, bool>> FindByEmail(string email, int active = 1)
        {
            return x => x.Email.Equals(email) && x.Active.Equals(active);
        }

        public static Expression<Func<UserEntity, bool>> FindByName(string name, int active = 1)
        {
            return x => x.Name.Contains(name) && active.Equals(active);
        }
    }
}
