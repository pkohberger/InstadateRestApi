using InstadateRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InstadateRestApi.Data
{
    public class InstadateRestApiContext : DbContext
    {
        public InstadateRestApiContext(DbContextOptions<InstadateRestApiContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
