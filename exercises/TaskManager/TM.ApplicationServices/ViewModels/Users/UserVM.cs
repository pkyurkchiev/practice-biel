using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.ViewModels.Users
{
    public class UserVM : BaseVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
