using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data.Entites
{
    public class Library : BaseEntity
    {
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }

        public int? OwnedBy { get; set; }
        [ForeignKey("OwnedBy")]
        public virtual User User { get; set; }
    }
}
