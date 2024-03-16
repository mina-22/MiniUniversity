using System.ComponentModel.DataAnnotations;
using University.Models;

namespace University.ModeView
{
    public class CourseStudent
    {
       public int StudentId { get; set; }
       
        public int? CourseId { get; set; }
		
		public List<Course>? courses { get; set; }
         
    }
}
