using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksOnEF.Api.PresentationModels
{
    public class BookModel
    {
        public virtual AuthorModel Author { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        public int NbrInStock { get; set; }

        public int Id { get; set; }
    }
}
