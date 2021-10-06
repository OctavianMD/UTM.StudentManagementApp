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
                entity.HasMany<Course>();
                entity.HasMany<Student>();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Idnp);
                entity.HasOne<ClassRoom>();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne<Teacher>();
                entity.HasMany<Student>();
                entity.HasMany<ClassRoom>();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany<Course>();
            });
        }
    }
}
