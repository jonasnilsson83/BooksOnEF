using BooksOnEF.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
