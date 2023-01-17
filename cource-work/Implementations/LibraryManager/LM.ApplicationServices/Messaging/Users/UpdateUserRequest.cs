using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging.Users
{
    public class UpdateUserRequest : IntegerIdRequest
    {
        public UpdateUserRequest(int id, UserPropertiesViewModel properties) : base(id)
        {
            UserProperties = properties;
        }

        public UserPropertiesViewModel UserProperties { get; set; }
    }
}
