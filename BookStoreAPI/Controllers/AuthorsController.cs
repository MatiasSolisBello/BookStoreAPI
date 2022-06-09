using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController: ControllerBase
    {
        private readonly AplicationDbContext context;

        public AuthorsController(AplicationDbContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await context.Authors.Include(x => x.Book).ToListAsync();
        }



        [HttpPost]
        public async Task<ActionResult> Post(Author author)
        {
            context.Add(author);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]  //   api/authors/1
        public async Task<ActionResult> Put(Author author, int id)
        {
            if(author.Id != id)
            {
                return BadRequest("The author id is not same of the URL");
            }
            context.Update(author);
            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpDelete("{id:int}")]  //   api/authors/1
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Authors.AnyAsync(x => x.Id == id);

            if (exist)
            {
                return NotFound();
            }

            context.Remove(new Author() { Id = id});
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
