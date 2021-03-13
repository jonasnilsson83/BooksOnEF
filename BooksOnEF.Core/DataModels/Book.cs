using BooksOnEF.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOnEF.Core.DataModels
{
    public class Book // : IBook
    {
        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }
        
        public decimal Price { get; set; }
        public int NbrInStock { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }
        public string ISBN { get; set; }

        public int? TotalPages { get; set; }

        [Column(TypeName="Date")]
        public DateTime? PublicationDate { get; set; }

        public int? Edition { get; set; }

    }

}
