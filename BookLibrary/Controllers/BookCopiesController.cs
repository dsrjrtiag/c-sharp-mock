using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Data;
using BookLibrary.Model;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopiesController : ControllerBase
    {
        private readonly BookLibraryContext _context;

        public BookCopiesController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET: api/BookCopies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCopy>>> GetBookCopy()
        {
            return await _context.BookCopy.ToListAsync();
        }

        // GET: api/BookCopies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCopy>> GetBookCopy(int id)
        {
            var bookCopy = await _context.BookCopy.FindAsync(id);

            if (bookCopy == null)
            {
                return NotFound();
            }

            return bookCopy;
        }

        // PUT: api/BookCopies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookCopy(int id, BookCopy bookCopy)
        {
            if (id != bookCopy.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookCopy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCopyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookCopies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookCopy>> PostBookCopy(BookCopy bookCopy)
        {
            _context.BookCopy.Add(bookCopy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookCopy", new { id = bookCopy.Id }, bookCopy);
        }

        // DELETE: api/BookCopies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookCopy>> DeleteBookCopy(int id)
        {
            var bookCopy = await _context.BookCopy.FindAsync(id);
            if (bookCopy == null)
            {
                return NotFound();
            }

            _context.BookCopy.Remove(bookCopy);
            await _context.SaveChangesAsync();

            return bookCopy;
        }

        private bool BookCopyExists(int id)
        {
            return _context.BookCopy.Any(e => e.Id == id);
        }
    }
}
