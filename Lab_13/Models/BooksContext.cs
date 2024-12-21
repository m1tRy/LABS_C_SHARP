using Microsoft.EntityFrameworkCore;

namespace Lab_13.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BooksContext(DbContextOptions<BooksContext> dbContextOptions ) :base(dbContextOptions)
        {
            Database.EnsureCreated();

        }
    }
}
