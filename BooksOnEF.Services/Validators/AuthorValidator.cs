using BooksOnEF.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksOnEF.Services.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FirstName)
                .NotNull()
                .MaximumLength(250);

            RuleFor(a => a.LastName)
                .NotNull()
                .MaximumLength(250);


        }
    }
}
