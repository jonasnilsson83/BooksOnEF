using AutoMapper;
using BooksOnEF.Api.PresentationModels;
using BooksOnEF.Core.Models;
using BooksOnEF.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksOnEF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthor(id);

            if (result.Succeded)
                return NoContent();
            else
                return BadRequest(result.FailureMessages);
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateAuthor(CreateAuthorModel author)
        {
            var result = await _authorService.CreateAuthor(author);

            if (result.Succeded)
            {
                return Ok(_mapper.Map<AuthorModel>(result.ResultObject));
            }
            else
            {
                return BadRequest(result.FailureMessages);
            }
        }

        [HttpPut("")]
        public async Task<ActionResult> UpdateAuthor([FromBody] CreateAuthorModel authorToUpdate)
        {
            
            var result = await _authorService.UpdateAuthor(authorToUpdate);

            if (result.Succeded)
                return Ok(_mapper.Map<AuthorModel>(result.ResultObject));
            else
                return BadRequest(result.FailureMessages);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetWithBooksById(int id)
        {
            var result = await _authorService.GetAuthorById(id);

            if (result.Succeded)
                return Ok(_mapper.Map<AuthorModel>(result.ResultObject));
            else
                return BadRequest(result.FailureMessages);
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllAuthorsWithBooks()
        {
            var result = await _authorService.GetAllAuthors();

            if (result.Succeded)
                return Ok(_mapper.Map<IEnumerable<AuthorModel>>(result.ResultObject));
            else
                return NotFound();
        }
    }
}
