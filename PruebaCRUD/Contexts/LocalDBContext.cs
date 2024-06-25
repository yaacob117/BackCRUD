using Microsoft.EntityFrameworkCore;
using PruebaCRUD.Models;
namespace PruebaCRUD.Contexts
{
    public class LocalDBContext : DbContext
    {
        public LocalDBContext(DbContextOptions<LocalDBContext> options) : base(options) { }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Loan> Loan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
