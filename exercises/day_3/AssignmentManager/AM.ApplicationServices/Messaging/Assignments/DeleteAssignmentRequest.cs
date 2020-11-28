using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class DeleteAssignmentRequest : IntegerIdRequest
    {
        public DeleteAssignmentRequest(int id) : base(id) { }
    }
}
