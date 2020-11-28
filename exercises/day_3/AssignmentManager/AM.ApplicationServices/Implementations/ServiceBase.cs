using AM.ApplicationServices.Interfaces;
using AM.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Implementations
{
    public class ServiceBase : IServiceBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
