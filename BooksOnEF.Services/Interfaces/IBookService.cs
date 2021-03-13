using BooksOnEF.Core;
using BooksOnEF.Core.DataModels;
using BooksOnEF.Core.Models;
using BooksOnEF.Core.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksOnEF.Services.Interfaces
{
    public  interface IBookService
    {
        Task<Result<IEnumerable<Book>>> GetAllBooksWithAuthor();
        ValueTask<Result<Book>> GetBookById(int id);
        Task<Result<IEnumerable<Book>>> GetBooksByAuthorId(int authorId);
        Task<Result<Book>> CreateBook(CreateBookModel newBook);
        Task<Result<Book>> UpdateBook(CreateBookModel bookToBeUpdated);
        Task<ResultBase> DeleteBook(int id);
    }
}
