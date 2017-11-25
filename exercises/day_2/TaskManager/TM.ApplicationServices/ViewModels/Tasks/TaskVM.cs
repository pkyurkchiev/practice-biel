using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.ViewModels.Tasks
{
    public class TaskVM : BaseVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartedBy { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime EndedOn { get; set; }
    }
}
