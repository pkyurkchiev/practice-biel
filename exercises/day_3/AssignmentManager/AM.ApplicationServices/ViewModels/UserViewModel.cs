using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
    }
}
