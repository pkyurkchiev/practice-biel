using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data.Entites
{
    public class User : BaseEntity
    {
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(150, MinimumLength = 3)]
        public string LastName { get; set; }
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string UserName { get; set; }

        public virtual ICollection<Library> Library { get; set; }
    }
}
