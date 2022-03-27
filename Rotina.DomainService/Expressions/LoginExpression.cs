using Rotina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.DomainService.Expressions
{
    public static class LoginExpression
    {
        public static Expression<Func<LoginEntity, bool>> FindByUser(decimal idUser)
        {
            return x => x.IdUser.Equals(idUser);
        }
    }
}
