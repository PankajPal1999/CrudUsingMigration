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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(a => new { a.Personid });
            modelBuilder.Entity<User>()
                .HasOne(a => a.Person)
                .WithOne(b=>b.users)
                .HasForeignKey<Person>(a=>a.Personid);
        }
    }
}
