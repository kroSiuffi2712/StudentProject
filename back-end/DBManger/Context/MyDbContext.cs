using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DBManger.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<DBManger.Entities.Student> Students { get; set; }
        public object Student { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<DBManger.Entities.Student>().ToTable("Student", "test");
            modelBuilder.Entity<DBManger.Entities.Student>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
