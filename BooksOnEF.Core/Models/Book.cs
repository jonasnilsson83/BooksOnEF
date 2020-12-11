using BooksOnEF.Core.Models.Interfaces;
using System.Collections.Generic;

namespace BooksOnEF.Core.Models
{
    public class Book // : IBook
    {
        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }
        
        public decimal Price { get; set; }
        public int NbrInStock { get; set; }

        public int Id { get; set; }
    }

}
