using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
