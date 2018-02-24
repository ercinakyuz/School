using Microsoft.EntityFrameworkCore;
using School.Data.Entity;
using School.Data.Mappping;

namespace School.Data.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {      
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<StudentLesson> StudentLesson { get; set; }
        public DbSet<Classroom> Classroom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = @"Server=(localdb)\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;ConnectRetryCount=0";
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new BaseEntityMap());
            //modelBuilder.ApplyConfiguration(new StandardMap());
            modelBuilder.ApplyConfiguration(new ClassroomMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new LessonMap());
            modelBuilder.ApplyConfiguration(new StudentLessonMap());
            modelBuilder.ApplyConfiguration(new TeacherMap());
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
