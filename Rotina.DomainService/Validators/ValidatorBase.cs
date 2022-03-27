using Rotina.DomainService.Helpers;
using System.Collections.Generic;

namespace Rotina.DomainService.Validators
{
    public abstract class ValidatorBase
    {
        protected List<string> Error { get; set; }
        private ApiException Exception { get; set; }

        public ValidatorBase()
        {
            Error = new List<string>();
            Exception = new ApiException("Validator");
        }

        protected void GenerateError()
        {
            if (Error.Count > 1)
            {
                Exception.GenerateError(Error);
            }
        }

        protected void AddError(string erro)
        {
            Error.Add(erro);
        }
    }
}

