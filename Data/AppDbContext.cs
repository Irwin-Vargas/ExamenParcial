using Microsoft.EntityFrameworkCore;
using PARCIAL.Models;

namespace PARCIAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>()
                .HasIndex(a => new { a.PlayerId, a.TeamId })
                .IsUnique();
        }
    }
}
