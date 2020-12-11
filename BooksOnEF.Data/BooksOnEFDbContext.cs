using BooksOnEF.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BooksOnEF.Data
{
    public class BooksOnEFDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        public BooksOnEFDbContext(DbContextOptions<BooksOnEFDbContext> options)
        :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
