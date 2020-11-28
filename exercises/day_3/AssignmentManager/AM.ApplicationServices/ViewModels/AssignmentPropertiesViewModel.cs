using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.ViewModels
{
    public class AssignmentPropertiesViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
        public int OwnerBy { get; set; }
    }
}
