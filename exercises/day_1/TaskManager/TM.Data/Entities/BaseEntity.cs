using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TM.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
