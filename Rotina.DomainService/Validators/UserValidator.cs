using Rotina.Domain.Commands;
using Rotina.DomainService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.DomainService.Validators
{
    public class UserValidator : ValidatorBase
    {
        public UserValidator() : base()
        {

        }

        public void Add(UserCommand command)
        {
            ValidateEmail(command.Email);

            GenerateError();
        }

        public void Update(UserCommand command)
        {
            ValidateEmail(command.Email);

            GenerateError();
        }

        private void ValidateEmail(string email)
        {
            if (Helper.ValidateEmail(email))
            {
                AddError("Invalid field: Email");
            }
        }
    }
}
