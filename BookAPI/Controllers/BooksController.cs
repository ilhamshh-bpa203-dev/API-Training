using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book is null) return NotFound("Book isn't exists..");
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book newBook)
        {
            var book = new Book();
            
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            book.Price = newBook.Price;

          await  _context.Books.AddAsync(book);
           await _context.SaveChangesAsync();
            return Ok("Created..");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book newBook)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            
            if (book is null) return NotFound("Book isn't exists..");

            book.IsDeleted = newBook.IsDeleted;
            book.Author = newBook.Author;
            book.Price = newBook.Price;
            book.Description = newBook.Description;
            book.Title = newBook.Title;

           await _context.SaveChangesAsync();
            return Ok("Updated..");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book is null) return NotFound("Book isn't exists..");
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok("Deleted..");
        }
    }
}
