using Microsoft.EntityFrameworkCore;
using Modles;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
    :base(options) {}

    public DbSet<Student> Students {get; set;}
    public DbSet<Course> Courses {get;set;}
    public DbSet<Doctor> Doctors {get;set;}
    public DbSet<TA> TAs {get;set;}
    public DbSet<Admin> Admins {get;set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students)
            .UsingEntity(j => j.ToTable("StudentCourses"));

        modelBuilder.Entity<Course>()
            .HasOne(d => d.Doc)
            .WithMany(d => d.Courses)
            .HasForeignKey(p => p.DoctorId);
        
        modelBuilder.Entity<TA>()
            .HasMany(t => t.Courses)
            .WithMany(c => c.TAs)
            .UsingEntity(j => j.ToTable("TAsCourses"));
        
    }
} 