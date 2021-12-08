using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging.Users
{
    public class InsertUserRequest : ServiceRequestBase
    {
        public InsertUserRequest(UserPropertiesViewModel properties) 
        {
            UserProperties = properties;
        }

        public UserPropertiesViewModel UserProperties { get; set; }
    }
}
