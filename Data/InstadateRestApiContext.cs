using InstadateRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InstadateRestApi.Data
{
    public class InstadateRestApiContext : DbContext
    {
        public InstadateRestApiContext(DbContextOptions<InstadateRestApiContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<FilePath> FilePaths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
