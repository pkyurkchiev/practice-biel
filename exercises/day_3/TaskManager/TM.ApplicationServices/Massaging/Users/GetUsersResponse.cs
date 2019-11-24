using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.ViewModels;

namespace TM.ApplicationServices.Massaging.Users
{
    public class GetUsersResponse : ServiceResponseBase
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
