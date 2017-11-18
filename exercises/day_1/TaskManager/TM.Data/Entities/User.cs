using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Data.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
