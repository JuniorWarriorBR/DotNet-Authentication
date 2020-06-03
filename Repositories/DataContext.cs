using jobRegister.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace jobRegister.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
