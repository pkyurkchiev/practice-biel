using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Users
{
    public class GetUserRequest : IntegerIdRequest
    {
        public GetUserRequest(int id) : base(id) { }
    }
}
