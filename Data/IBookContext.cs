using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Data
{
    public interface IBookContext
    {
        DbSet<Book> Books { get; set; }
    }
}
