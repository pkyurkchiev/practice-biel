using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.ViewModels
{
    public class TaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
    }
}
