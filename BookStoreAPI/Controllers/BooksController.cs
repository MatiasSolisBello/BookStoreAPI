using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public BooksController(AplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            //Books por que se coloco Book en DbContext
            return await context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);
        }


        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            var existAuthor = await context.Authors.AnyAsync(x => x.Id == book.AuthorId);

            if (!existAuthor)
            {
                return BadRequest($"Not exist the author with the id { book.AuthorId}");
            }
            context.Add(book);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
