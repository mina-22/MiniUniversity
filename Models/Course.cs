using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int ? ProfessorId { get; set; }
        [ForeignKey("ProfessorId")]
        
        public Professor? professor { get; set; }
        public virtual ICollection<Student>? students { set; get; }
    }
}
