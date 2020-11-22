using AM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Messaging.Users
{
    public class GetUsersResponse : ServiceResponseBase
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
