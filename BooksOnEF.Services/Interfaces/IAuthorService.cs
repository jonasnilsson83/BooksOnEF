using BooksOnEF.Core;
using BooksOnEF.Core.Models;
using BooksOnEF.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksOnEF.Services.Interfaces
{
   public interface IAuthorService : IService
    {
        Task<Result<IEnumerable<Author>>> GetAllAuthors();
        Task<Result<Author>> GetAuthorById(int id);
        Task<Result<Author>> CreateAuthor(Author newAuthor);
        Task<Result<Author>> UpdateAuthor(Author authorToBeUpdated);
        Task<Result<Author>> DeleteAuthor(int authorId);
    }
}
