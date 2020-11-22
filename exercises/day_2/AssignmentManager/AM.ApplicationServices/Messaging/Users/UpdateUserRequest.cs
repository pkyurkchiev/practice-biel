using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Users
{
    public class UpdateUserRequest : IntegerIdRequest
    {
        public UpdateUserRequest(int id, UserPropertiesViewModel userProperties) : base(id) 
        {
            UserProperties = userProperties;
        }

        public UserPropertiesViewModel UserProperties { get; set; }
    }
}
