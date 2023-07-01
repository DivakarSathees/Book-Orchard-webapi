using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            return await _context.Books.ToListAsync();
        }


        [HttpGet("{genre:alpha}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByGenre(string genre)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.Where(b => b.Genre.ToLower() == genre.ToLower()).ToListAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}
