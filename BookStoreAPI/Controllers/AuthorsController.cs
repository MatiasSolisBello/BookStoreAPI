using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            return new List<Author>()
            {
                new Author() { Id = 1, Name = "Felipe" },
                new Author() { Id = 2, Name = "Claudia" }
            };
        }
    }
}
