using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC.Website.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [StringLength(300, MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Faculty number")]
        [Required]
        [StringLength(10, MinimumLength = 8)]
        public string FacultyNumber { get; set; }

        [Display(Name = "Create date")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }
}