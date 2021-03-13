using System;
using System.Collections.Generic;
using System.Text;

namespace BooksOnEF.Core.Models
{
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }
    }
}
