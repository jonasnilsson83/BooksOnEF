using BooksOnEF.Core.Models;
using BooksOnEF.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksOnEF.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithAuthorAsync();

        Task<Book> GetWithAuthorByIdAsync(int bookId);

        Task<IEnumerable<Book>> GetAllWithAuthorByAuthorId(int authorId);
    }
}
