using BooksOnEF.Core;
using BooksOnEF.Core.DataModels;
using BooksOnEF.Core.Models;
using BooksOnEF.Data.Repositories;
using BooksOnEF.Services.Interfaces;
using BooksOnEF.Services.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksOnEF.Services.Services
{
    public class AuthorService : IAuthorService
    {
        readonly IAuthorRepository _authorRepository;
        readonly AuthorValidator _authorValidator;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _authorValidator = new AuthorValidator();
        }

        public async Task<Result<Author>> CreateAuthor(CreateAuthorModel newAuthor)
        {
            Author author = new Author()
            {
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName
            };

            var validationResult = await _authorValidator.ValidateAsync(author);

            if (!validationResult.IsValid)
            {
                return Result.Failure(author, validationResult.Errors.Select(s => s.ErrorMessage).ToList());
            }

            var createdAuthor = await _authorRepository.AddAsync(author);

            return Result.Success(createdAuthor);
        }

        public async Task<Result<Author>> DeleteAuthor(int authorId)
        {
            var getAuthorResult = await GetAuthorById(authorId);

            if (!getAuthorResult.Succeded || !getAuthorResult.ResultObject.HasBooks)
            {
                return Result.Failure(getAuthorResult.ResultObject, "Unable to delete");
            }

            _authorRepository.Remove(getAuthorResult.ResultObject);

            return Result<Author>.Success<Author>(null);
        }

        public async Task<Result<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllWithBooksAsync();

            if (authors == null)
            {
                return Result.Failure(authors, "Unexpected error");
            }

            return Result.Success(authors);
        }

        public async Task<Result<Author>> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetWithBooksByIdAsync(id);

            if (author == null)
            {
                return Result.Failure(author, "Unknonw author");
            }

            return Result.Success(author);
        }

        public async Task<Result<Author>> UpdateAuthor(CreateAuthorModel authorToBeUpdated)
        {
            var existingAuthorResult = await GetAuthorById(authorToBeUpdated.Id);

            if (!existingAuthorResult.Succeded)
            {
                return Result.Failure(existingAuthorResult.ResultObject, existingAuthorResult.FailureMessages);
            }


            existingAuthorResult.ResultObject.FirstName = authorToBeUpdated.FirstName;
            existingAuthorResult.ResultObject.LastName = authorToBeUpdated.LastName;
        

            var validationResult = await _authorValidator.ValidateAsync(existingAuthorResult.ResultObject);

            if (!validationResult.IsValid)
            {
                return Result.Failure(existingAuthorResult.ResultObject, validationResult.Errors.Select(s => s.ErrorMessage).ToList());
            }

            
            await _authorRepository.CommitAsync();

            return Result.Success(existingAuthorResult.ResultObject);
        }
    }
}
