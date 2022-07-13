using Microsoft.EntityFrameworkCore;

namespace Mecca.API.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UsersLogs { get; set; }
    }
}
