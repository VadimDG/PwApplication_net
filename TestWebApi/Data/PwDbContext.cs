using Microsoft.EntityFrameworkCore;
using TestWebApi.Data.Models;

namespace TestWebApi.Data
{
    public class PwDbContext: DbContext
    {
        public PwDbContext(DbContextOptions<PwDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);

            modelBuilder.DescribeUser();
        }
    }
}
