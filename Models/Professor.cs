using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId {  get; set; }
        public string ProfessorName { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
         public Department? department { get; set; }
        public virtual ICollection<Course> ?Courses { get; set; }

        
    }
}
