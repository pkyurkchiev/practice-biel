using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging.Users
{
    public class DeleteUserRequest : IntegerIdRequest
    {
        public DeleteUserRequest(int id)
            : base(id) { }
    }
}
