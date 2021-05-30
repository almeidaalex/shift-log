using Microsoft.EntityFrameworkCore;
using ShiftLogger.Model;

namespace ShiftLogger.Infra
{
    public class ShiftLoggerContext : DbContext
    {
        public ShiftLoggerContext(DbContextOptions<ShiftLoggerContext> optionsBuilder)
            :base(optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShiftLog>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<ShiftLog>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<ShiftLog> ShiftLogs { get; private set; }
        
        
    }
}