using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Student
    {
       
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Length(2,15)]
        public string FirstName { get; set; }
        [Required]
        [Length(2, 15)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Major { get; set; }

        public virtual ICollection<Course>? courses { set; get; }

    }
}
