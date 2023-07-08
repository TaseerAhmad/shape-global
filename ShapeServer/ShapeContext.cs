using Microsoft.EntityFrameworkCore;

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
    }
}
