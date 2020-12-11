using BooksOnEF.Core;
using BooksOnEF.Core.Models;
using BooksOnEF.Core.Models.Interfaces;
using BooksOnEF.Data.Repositories;
using BooksOnEF.Services.Interfaces;
using BooksOnEF.Services.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOnEF.Services.Services
{
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;
        readonly BookValidator _validator;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _validator = new BookValidator();
        }

        public async Task<Result<Book>> CreateBook(Book newBook)
        {
            ValidationResult validationResult = _validator.Validate(newBook);

            if (!validationResult.IsValid)
            {
                return Result.Failure(newBook, validationResult.Errors.Select(s => s.ErrorMessage).ToList());
            }

            var bookFromEF = await _bookRepository.AddAsync(newBook);

            return Result.Success(bookFromEF);
        }

        public async Task<ResultBase> DeleteBook(int id)
        {
            var existingBook = await GetBookById(id);

            if (!existingBook.Succeded)
            {
                return Result.Failure(id, existingBook.FailureMessages);
            }

            _bookRepository.Remove(existingBook.ResultObject);

            return Result.Success<Book>(null);
        }

        public async Task<Result<IEnumerable<Book>>> GetAllBooksWithAuthor()
        {
            var books = await _bookRepository.GetAllWithAuthorAsync();

            if (books == null)
            {
                return Result.Failure(books, "Unexpected error");
            }

            return Result.Success(books);
        }

        public async ValueTask<Result<Book>> GetBookById(int id)
        {
            var book = await _bookRepository.GetWithAuthorByIdAsync(id);

            if (book == null)
            {
                return Result.Failure(book, "Unknown Id");
            }

            return Result.Success(book); ;
        }

        public async Task<Result<IEnumerable<Book>>> GetBooksByAuthorId(int authorId)
        {
            var books = await _bookRepository.GetAllWithAuthorByAuthorId(authorId);


            if (books == null)
            {
                return Result.Failure(books, "Unknown error");
            }

            return Result.Success(books);
        }



        public Task<Book> UpdateBook(Book bookToBeUpdated)
        {
            throw new NotImplementedException();
        }

        public TReturn Invoke<TReturn>(Func<TReturn> function)
        {
            try
            {
                TReturn result = function();

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }



        T Execute<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
        }
    }
}

