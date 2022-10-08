using Microsoft.EntityFrameworkCore;
using UserAPI01.Models;

namespace UserAPI01.Data
{
    public class UserAPIDbContext : DbContext
    {
        public UserAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
