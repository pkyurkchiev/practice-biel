using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Entites
{
    public class Assignment : BaseEntity
    {
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
    }
}
