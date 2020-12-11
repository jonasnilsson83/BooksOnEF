using AutoMapper;
using BooksOnEF.Api.PresentationModels;
using BooksOnEF.Core.Models;
using BooksOnEF.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksOnEF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);

            if (result.Succeded)
                return NoContent();
            else
                return NotFound();
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateBook(Book book)
        {
            var result = await _bookService.CreateBook(book);

            if (result.Succeded)
            {
                return Ok(_mapper.Map<BookModel>(result.ResultObject));
            }
            else
            {
                return BadRequest(result.FailureMessages);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var result = await _bookService.GetBookById(id);

            if (result.Succeded)
                return Ok(_mapper.Map<BookModel>(result.ResultObject));
            else
                return NotFound();
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllBooksWithAuthor()
        {
            var result = await _bookService.GetAllBooksWithAuthor();

            if (result.Succeded)
                return Ok(_mapper.Map<IEnumerable<BookModel>>(result.ResultObject));
            else
                return NotFound();
        }

        [HttpGet("author/{authorId}")]
        public async Task<ActionResult> GetAllBooksWithAuthor(int authorId)
        {
            var result = await _bookService.GetBooksByAuthorId(authorId);

            if (result.Succeded)
                return Ok(_mapper.Map<IEnumerable<BookModel>>(result.ResultObject));
            else
                return NotFound();
        }
    }
}
