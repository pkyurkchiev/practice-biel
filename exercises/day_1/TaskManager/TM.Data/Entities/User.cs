using System.Collections.Generic;

namespace TM.Data.Entities
{
    public class User : BaseEntity
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
