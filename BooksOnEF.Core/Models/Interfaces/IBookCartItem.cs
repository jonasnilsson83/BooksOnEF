using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOnEF.Core.Models.Interfaces
{
    public interface IBookCartItem
    {
        int Quantity { get; set; }

        System.DateTime DateCreated { get; set; }

        Book Book { get; set; }

        bool CanBeOrdered { get; set; }


    }
}
