using System;

namespace TM.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
