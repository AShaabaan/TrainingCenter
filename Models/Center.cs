using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Center : IdentityDbContext<ApplicationUser>
    {
        public Center() : base()
        {

        }

        public Center(DbContextOptions options) : base(options) { }

        public DbSet<Department> Department { get; set; }
        public DbSet<Attandance> Attandance { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instractor> Instractors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=trainingcenter;integrated security=true;").UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
