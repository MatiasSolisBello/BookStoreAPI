using BookStoreAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI
{
    public class AplicationDbContext: DbContext
    {
        // Configuraciones para EntityFramework
        public AplicationDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Author> Authors { get; set; }
    
    }
}
