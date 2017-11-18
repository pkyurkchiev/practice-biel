using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.ViewModels
{
    public abstract class BaseVM
    {
        #region Properties
        public int Id { get; set; }

        public bool IsActive { get; set; }
        #endregion
    }
}
