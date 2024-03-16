using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { set; get; }

        public virtual ICollection<Professor>? Professors { get; set;}

    }
}
