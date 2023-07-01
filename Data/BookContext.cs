using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Data
{
    public class BookContext :DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }



    }
}
