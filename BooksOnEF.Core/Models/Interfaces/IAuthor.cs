using BooksOnEF.Core.DataModels;
using System.Collections.Generic;

namespace BooksOnEF.Core.Models.Interfaces
{
    public interface IAuthor_NotTaskCompatible
    {
        string FirstName { get; }
        string LastName { get; }
        int Id { get; set; }

        List<Book> Books { get; set; }
    }
}
