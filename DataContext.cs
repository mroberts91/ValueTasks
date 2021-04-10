using Microsoft.EntityFrameworkCore;

namespace ValueTasks
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(e =>
            {
                e.HasKey(o => o.Id);
                e.Property(o => o.Id)
                    .ValueGeneratedOnAdd();
            });
        }

    }
}
