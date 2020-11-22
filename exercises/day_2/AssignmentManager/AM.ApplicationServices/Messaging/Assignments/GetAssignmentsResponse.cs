using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class GetAssignmentsResponse : ServiceResponseBase
    {
        public IEnumerable<AssignmentViewModel> Assignments { get; set; }
    }
}
