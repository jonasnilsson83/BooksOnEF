using BooksOnEF.Core.DataModels;
using BooksOnEF.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksOnEF.Services.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.AuthorId)
                .NotEmpty();

            RuleFor(b => b.Price)
                .GreaterThan(0);

            RuleFor(b => b.Title)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(b => b.NbrInStock)
               .NotNull()
               .GreaterThan(0);
        }
    }
}
