using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging.Users
{
    public class InsertUserRequest : ServiceRequestBase
    {
        public UserPropertiesVM UserProperties { get; set; }
    }
}
