using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Parcial.Data;

namespace Parcial
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Host=localhost;Port=5432;Database=jugadoresdb;Username=postgres;Password=73514078");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}