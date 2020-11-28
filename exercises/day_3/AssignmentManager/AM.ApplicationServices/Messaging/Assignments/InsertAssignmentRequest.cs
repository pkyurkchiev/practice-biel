using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class InsertAssignmentRequest : ServiceRequestBase
    {
        public InsertAssignmentRequest(AssignmentPropertiesViewModel assignmentProperties)
        {
            AssignmentProperties = assignmentProperties;
        }
        public AssignmentPropertiesViewModel AssignmentProperties { get; set; }
    }
}
