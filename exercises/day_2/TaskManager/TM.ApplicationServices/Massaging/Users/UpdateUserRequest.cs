using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging.Users
{
    public class UpdateUserRequest : IntegerIdRequest
    {
        public UpdateUserRequest(int id) : base(id) { }

        public UserPropertiesVM UserProperties { get; set; }
    }
}
