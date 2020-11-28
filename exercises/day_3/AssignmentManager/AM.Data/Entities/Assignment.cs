using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AM.Data.Entities
{
    public class Assignment : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }

        public int? OwnedBy { get; set; }
        [ForeignKey("OwnedBy")]
        public virtual User User { get; set; }
    }
}
