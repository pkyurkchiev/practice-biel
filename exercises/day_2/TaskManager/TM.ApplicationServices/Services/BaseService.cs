using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TM.Data.Context;
using TM.Repositories.Implementations;
using TM.Repositories.Interfaces;

namespace TM.ApplicationServices.Services
{
    public abstract class BaseService
    {
        #region Fields
        protected readonly UnitOfWork _unitOfWork = new UnitOfWork();
        protected readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
    }
}
