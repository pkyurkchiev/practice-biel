using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.ViewModels;

namespace TM.ApplicationServices.Massaging.Tasks
{
    public class GetTasksResponse : ServiceResponseBase
    {
        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
