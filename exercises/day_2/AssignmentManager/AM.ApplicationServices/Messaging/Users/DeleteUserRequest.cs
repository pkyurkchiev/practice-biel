using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Users
{
    public class DeleteUserRequest : IntegerIdRequest
    {
        public DeleteUserRequest(int id) : base(id) { }
    }
}
