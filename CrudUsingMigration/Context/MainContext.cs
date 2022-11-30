using CrudUsingMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingMigration.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
