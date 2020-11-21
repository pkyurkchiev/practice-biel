using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Data.Entities
{
    public class Assignment : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
    }
}
