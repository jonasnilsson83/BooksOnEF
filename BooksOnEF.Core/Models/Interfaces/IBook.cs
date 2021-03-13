using BooksOnEF.Core.DataModels;

namespace BooksOnEF.Core.Models.Interfaces
{
    public interface IBook_NotTaskCompatible
    {

        Author Author { get; }

        int AuthorId { get; set; }
        string Title { get; }
        decimal Price { get; }
        int NbrInStock { get; }
        int Id { get; set; }
    }
}
