using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class AssignmentPropertiesViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
        public int? OwnedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
