using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging.Users
{
    public class GetUserRequest : IntegerIdRequest
    {
        public GetUserRequest(int id) 
            : base(id) { }
    }
}
