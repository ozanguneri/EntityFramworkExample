using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TEST.Core.Entities;

namespace TEST.Core
{
    public class TestContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TestContext(DbContextOptions<TestContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
        }
    }
}
