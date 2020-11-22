using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Assignments
{
    public class GetAssignmentRequest : IntegerIdRequest
    {
        public GetAssignmentRequest(int id) : base(id) { }
    }
}
