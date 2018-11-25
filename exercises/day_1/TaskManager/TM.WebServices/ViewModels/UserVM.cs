using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM.Data.Entities;

namespace TM.WebServices.ViewModels
{
    public class UserVM
    {
        public UserVM() { }
        public UserVM(User user)
        {
            FirstName = user.FirtName;
            LastName = user.LastName;
            UserName = user.UserName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}