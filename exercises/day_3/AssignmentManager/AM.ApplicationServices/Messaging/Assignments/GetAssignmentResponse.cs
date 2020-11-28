using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class GetAssignmentResponse : ServiceResponseBase
    {
        public AssignmentViewModel Assignment { get; set; }
    }
}
