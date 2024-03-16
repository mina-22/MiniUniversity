using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.db;
using University.Models;
using University.ModeView;

namespace University.Controllers
{
    
    public class StudentController : Controller
    {
        private databaseContext _database;
      public  StudentController(databaseContext database) {
            _database = database;
           
      }
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Account(int id)
		{
			var student = _database.Students.Include(s => s.courses).SingleOrDefault(t=>t.StudentId==id);
			return View(student);
		}

		public IActionResult Regist()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Regist(Student std)
		{
            var student = _database.Students.Include(s=> s.courses).SingleOrDefault(sd => sd.Email == std.Email);
            if (student==null||student.FirstName != std.FirstName)
            {
                ViewData["valid"] = "This Email Or Name Does not Exist";
				return View(std);

            }
 			return View("Account", student);
		}
		public IActionResult SignUp()
        {
            ViewData["valid"] = "";

			return View();
        }
        [HttpPost]
        public IActionResult SignUp(Student std)
        {
            TempData["Signed"] = "";
            var student = _database.Students.SingleOrDefault(st => st.Email == std.Email);
            if (student != null)
            {
				ViewData["valid"] = "This Email addres is regesterd allready";
                return View(std);
            }
			TempData["Signed"] = "You Sign Up successfully";
            _database.Students.Add(std);
            _database.SaveChanges();
            
            return RedirectToAction("Regist");
        }  
        public IActionResult AssignCourse(int id)
        {
              CourseStudent courseStudent = new CourseStudent();

            courseStudent.StudentId =id;
            courseStudent.courses = _database.Courses.ToList();
            return View(courseStudent);
        }
        [HttpPost]
        public IActionResult AssignCourse(CourseStudent cs)
        {
            TempData["op"] = "";

			var student = _database.Students.Include(s=>s.courses).SingleOrDefault(c=>c.StudentId==cs.StudentId);
            int count = student.courses.Count();
			var course = _database.Courses.Find(cs.CourseId);
            student.courses.Add(course);
            if(count== student.courses.Count())
            {
                TempData["op"] = "You Selected this course already";
               return RedirectToAction("AssignCourse", cs.StudentId);
            }
            TempData["op"] = "You Assigned successfully";

			_database.Students.Update(student);
            _database.SaveChanges();
         
			return View("Account",student);
        }
    }
}
