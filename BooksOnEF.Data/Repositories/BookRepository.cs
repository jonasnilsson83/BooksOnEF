using BooksOnEF.Core.Models;
using BooksOnEF.Core.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOnEF.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BooksOnEFDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorAsync()
        {
            // how to not fill Author with books? BY EXPOSING ANOTHER CLASS TO THE OUTSIDE WORLD, USING AUTOMAPPER
            return await Context.Books
                .Include(m => m.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorByAuthorId(int authorId)
        {
            return await Context.Books
                .Include(m => m.Author)
                .Where(m => m.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<Book> GetWithAuthorByIdAsync(int bookId)
        {
            return await Context.Books
                 .Include(m => m.Author)
                .Where(m => m.Id == bookId)
                .SingleOrDefaultAsync(x => x.Id == bookId);
        }
    }
}
