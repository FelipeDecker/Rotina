using Rotina.DomainService.Helpers;
using Rotina.DomainService.IRepositories;
using System.Collections.Generic;

namespace Rotina.Service.Services
{
    public class ServiceBase
    {
        protected readonly IUnitOfWork _repUnitOfWork;
        public ApiException Exception { get; set; }

        public ServiceBase(IUnitOfWork repUnitOfWork)
        {
            _repUnitOfWork = repUnitOfWork;
            Exception = new ApiException("Service");
        }

        protected void GenerateError(string error)
        {
            Exception.GenerateError(error);
        }

        protected void GenerateError(List<string> error)
        {
            Exception.GenerateError(error);
        }
    }
}
