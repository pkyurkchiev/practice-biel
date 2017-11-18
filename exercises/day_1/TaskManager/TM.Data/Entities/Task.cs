using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TM.Data.Entities
{
    public class Task : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public int? StartedBy { get; set; }
        [ForeignKey("StartedBy")]
        public User User { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime EndedOn { get; set; }
    }
}
