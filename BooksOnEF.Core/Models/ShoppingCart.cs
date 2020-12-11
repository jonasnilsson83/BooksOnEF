using BooksOnEF.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksOnEF.Core.Models
{
    public class ShoppingCart : IShoppingCart
    {
        readonly int _id;
        public ShoppingCart()
        {
            _id = new Random().Next();
            this.BooksInCart = new List<IBookCartItem>();
        }

        public int Id { get { return _id; } }
        public List<IBookCartItem> BooksInCart { get; set; }

        public decimal TotalSum
        {
            get
            {
                return this.BooksInCart == null || this.BooksInCart.Count == 0 ? 0 : this.BooksInCart.Where(it => it.CanBeOrdered).Sum(s => s.Quantity * s.Book.Price);
            }
        }

        public int TotalQuantity
        {
            get
            {
                return this.BooksInCart == null || this.BooksInCart.Count == 0 ? 0 : this.BooksInCart.Where(it => it.CanBeOrdered).Sum(s => s.Quantity );
            }
        }
    }
}
