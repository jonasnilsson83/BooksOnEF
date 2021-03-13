
using System.Collections.Generic;

namespace BooksOnEF.Core.DataModels
{
    public class Author
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
