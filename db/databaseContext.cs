using Microsoft.EntityFrameworkCore;
using University.Models;
using University.ModeView;

namespace University.db
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options):base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
		
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                     new Department {  DepartmentId = 1 },
                     new Department {  DepartmentId = 2 });
            modelBuilder.Entity<Professor>().HasData(
                      new Professor { ProfessorId = 1, ProfessorName = "Mina", DepartmentId = 1 },
                      new Professor { ProfessorId = 2, ProfessorName = "Kero" , DepartmentId = 2 }) ;
            

        }

    }
}
