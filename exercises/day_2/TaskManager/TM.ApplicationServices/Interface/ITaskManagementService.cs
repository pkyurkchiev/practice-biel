using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.Massaging.Tasks;

namespace TM.ApplicationServices.Interface
{
    public interface ITaskManagementService
    {
        GetTasksResponse GetAll();
    }
}
