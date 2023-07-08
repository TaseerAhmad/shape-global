using Microsoft.EntityFrameworkCore;
using ShapeServer.Models;
using ShapeServer.Models.Configurations;

namespace ShapeServer
{
    public class ShapeContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ShapeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }
    }
}
