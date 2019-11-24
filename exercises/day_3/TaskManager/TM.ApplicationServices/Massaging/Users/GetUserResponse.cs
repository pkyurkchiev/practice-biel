using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.ViewModels;

namespace TM.ApplicationServices.Massaging.Users
{
    public class GetUserResponse : ServiceResponseBase
    {
        public UserViewModel User { get; set; }
    }
}
