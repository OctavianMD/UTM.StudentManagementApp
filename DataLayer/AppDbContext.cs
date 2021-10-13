using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext: DbContext
    {
        public DbSet<ClassRoom> ClassRoom;
        public DbSet<Course> Course;
        public DbSet<Teacher> Teacher;  
        public DbSet<Student> Student;

        public AppDbContext(DbContextOptions<AppDbContext> settings)
            : base(settings)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.ToTable("Class");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(10);
                entity.HasMany(x => x.Courses);
                entity.HasMany(x => x.Students);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Idnp);
                entity.HasOne(x => x.ClassRoom);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Teacher);
                entity.HasMany(x => x.Students);
                entity.HasMany(x => x.ClassRooms);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.Courses);
            });
        }
    }
}
