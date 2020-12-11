using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksOnEF.Api.PresentationModels
{
    public class AuthorModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }
    }
}
