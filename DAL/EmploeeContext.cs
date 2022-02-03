using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EmploeeContext : DbContext
    {
        public EmploeeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=emploee.db");
        }

    }
}