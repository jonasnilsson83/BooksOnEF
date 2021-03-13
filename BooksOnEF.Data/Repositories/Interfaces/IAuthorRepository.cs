using BooksOnEF.Core.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksOnEF.Data.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllWithBooksAsync();
        Task<Author> GetWithBooksByIdAsync(int id);
    }
}
