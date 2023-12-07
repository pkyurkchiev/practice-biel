using System.ComponentModel.DataAnnotations;

namespace AM.Data.Entites
{
    public class User : BaseEntity
    {
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(150, MinimumLength = 3)]
        public string LastName { get; set; }
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string UserName { get; set; }
    }
}
