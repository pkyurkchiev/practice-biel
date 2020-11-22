using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class UpdateAssignmentRequest : IntegerIdRequest
    {
        public UpdateAssignmentRequest(int id, AssignmentPropertiesViewModel assignmentProperties) : base(id) 
        {
            AssignmentProperties = assignmentProperties;
        }

        public AssignmentPropertiesViewModel AssignmentProperties { get; set; }
    }
}
