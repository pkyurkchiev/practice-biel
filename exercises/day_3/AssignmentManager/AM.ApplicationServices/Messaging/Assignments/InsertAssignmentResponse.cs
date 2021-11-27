using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class InsertAssignmentResponse : ServiceResponseBase
    {
        public AssignmentViewModel Assignment { get; set; }
    }
}
