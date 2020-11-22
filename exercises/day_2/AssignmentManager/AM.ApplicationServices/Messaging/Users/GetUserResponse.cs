using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Users
{
    public class GetUserResponse : ServiceResponseBase
    {
        public UserViewModel User { get; set; }
    }
}
