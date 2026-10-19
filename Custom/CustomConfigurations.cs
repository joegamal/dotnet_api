
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<MyModel> MyModels => Set<MyModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyModel>().HasKey(o => o.ID);
            
            modelBuilder.Entity<MyModel>()
                .Property(o => o.Name)
                .IsRequired();
        }
    
    }


public static class CustomConfig { 

    public static IServiceCollection CustomDBConfigure(this IServiceCollection service, 
        IConfiguration config)
    {
        service.AddDbContext<AppDbContext>(o => 
            o.UseSqlite(config.GetConnectionString("Default")));

        return service;
    }
    
}




 