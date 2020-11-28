using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AM.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
