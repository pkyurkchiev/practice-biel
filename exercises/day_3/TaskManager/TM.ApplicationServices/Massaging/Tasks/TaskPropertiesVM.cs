using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging.Tasks
{
    public class TaskPropertiesVM
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
    }
}
