using BooksOnEF.Core.Models.Interfaces;
using System.Collections.Generic;

namespace BooksOnEF.Core.Models
{
    public class Author //: IAuthor
    {
        public Author() 
        {
            Books = new List<Book>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public virtual List<Book> Books { get; set; }

        public bool HasBooks => Books?.Count > 0;
    }
}
