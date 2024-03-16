using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.db;
using University.Models;
using University.ModeView;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        public databaseContext _database;
        public CourseController (databaseContext database ) {
            _database = database;
        }
		public IActionResult ViewCourses()
		{
			var courses = _database.Courses.Include(course => course.professor).ToList();
			return View( courses);
		}
		public IActionResult Index()
        {
            
            return RedirectToAction("ViewCourses");
        }

        public IActionResult Create()
        {
            CourseProf cf = new CourseProf();
            cf.profs = _database.Professors.ToList();
            return View(cf);
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            _database.Courses.Add(course);
            _database.SaveChanges();
            return RedirectToAction("ViewCourses");
        }
        public IActionResult Update(int id)
        {
            CourseProf cf = new CourseProf();
            cf.course = _database.Courses.Find(id);
            cf.profs = _database.Professors.ToList();

            return View(cf);
        }
        [HttpPost]
        public IActionResult Update(Course course)
        {
            var c = _database.Courses.Find(course.CourseId);
            c.CourseName=course.CourseName;
            c.ProfessorId=course.ProfessorId;
            _database.Courses.Update(c);
            _database.SaveChanges();

            return RedirectToAction("ViewCourses");
        }
        public IActionResult Delete(int id)
        {

            var course = _database.Courses.Find( id);
            _database.Courses.Remove(course);
            _database.SaveChanges();
			return RedirectToAction("ViewCourses");
		}
    }
}
