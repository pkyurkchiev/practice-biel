using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.Interface;
using TM.Repositories.Interface;

namespace TM.ApplicationServices.Implementation
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
