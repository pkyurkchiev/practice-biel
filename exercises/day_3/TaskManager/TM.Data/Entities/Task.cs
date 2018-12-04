using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TM.Data.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int? StartedBy { get; set; }
        [ForeignKey("StartedBy")]
        public virtual User User { get; set; }

        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
    }
}
