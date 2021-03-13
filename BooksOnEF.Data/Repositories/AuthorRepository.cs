using BooksOnEF.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksOnEF.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BooksOnEFDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await Context.Authors
                .Include(m => m.Books)
                .ToListAsync();
        }

        public async Task<Author> GetWithBooksByIdAsync(int id)
        {
            return await Context.Authors
                .Include(m => m.Books)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
