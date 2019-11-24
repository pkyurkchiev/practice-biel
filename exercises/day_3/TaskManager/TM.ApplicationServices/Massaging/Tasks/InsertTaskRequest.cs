using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging.Tasks
{
    public class InsertTaskRequest : ServiceRequestBase
    {
        public TaskPropertiesVM TaskProperties { get; set; }
    }
}
