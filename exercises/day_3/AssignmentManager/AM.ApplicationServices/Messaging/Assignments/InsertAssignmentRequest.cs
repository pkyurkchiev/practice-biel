using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class InsertAssignmentRequest : ServiceRequestBase
    {
        public InsertAssignmentRequest(AssignmentPropertiesViewModel properties) 
        {
            AssignmentProperties = properties;
        }

        public AssignmentPropertiesViewModel AssignmentProperties { get; set; }
    }
}
