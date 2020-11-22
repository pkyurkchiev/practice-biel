using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Users
{
    public class InsertUserRequest : ServiceRequestBase
    {
        public InsertUserRequest(UserPropertiesViewModel userProperties)
        {
            UserProperties = userProperties;
        }
        public UserPropertiesViewModel UserProperties { get; set; }
    }
}
