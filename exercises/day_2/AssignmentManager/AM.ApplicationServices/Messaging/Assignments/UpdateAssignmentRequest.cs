using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class UpdateAssignmentRequest : IntegerIdRequest
    {
        public UpdateAssignmentRequest(int id, AssignmentPropertiesViewModel properties) : base(id)
        {
            AssignmentProperties = properties;
        }

        public AssignmentPropertiesViewModel AssignmentProperties { get; set; }
    }
}
