using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Data.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
