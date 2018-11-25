using log4net;

namespace TM.ApplicationServices.Services
{
    public class BaseService
    {
        #region Properties
        // protected readonly UnitOfWork _unitOfWork = new UnitOfWork();
        protected readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
    }
}
