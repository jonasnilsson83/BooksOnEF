using System;
using System.Collections.Generic;
using System.Text;

namespace BooksOnEF.Core.Models
{
    public class CreateBookModel
    {
        public int AuthorId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        public int NbrInStock { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }
        public string ISBN { get; set; }

        public int TotalPages { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Edition { get; set; }
    }
}
