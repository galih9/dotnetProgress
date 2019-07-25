using Microsoft.EntityFrameworkCore;
using projecOne.Models.Param;

namespace projectOne.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
        : base(options)
        {

        }
        public DbSet<Book> Books { get; set;}
    }
}