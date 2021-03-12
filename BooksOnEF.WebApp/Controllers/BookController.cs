using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksOnEF.Api.PresentationModels;

namespace BooksOnEF.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BookModel> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new BookModel()
            {
                Title = "a", Id = index, NbrInStock = index * 5
            })
            .ToArray();
        }
    }
}
