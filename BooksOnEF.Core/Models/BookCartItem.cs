using BooksOnEF.Core.Models.Interfaces;

namespace BooksOnEF.Core.Models
{
    public class BookCartItem : IBookCartItem
    {
        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public Book Book { get; set; }

        public bool CanBeOrdered { get; set; }

        public int IdForPresentation { get { return Book.Id; } }
    }
}
