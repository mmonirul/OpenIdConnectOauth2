using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WestPay.Access.API.Dtos;
using WestPay.Access.API.Services.Interfaces;
using WestPay.Access.DAL.Entities.Library;

namespace WestPay.Access.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all books
        /// </summary>

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> Get()
        {
            var authorId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var books = Enumerable.Empty<Book>();

            if(User.IsInRole("admin"))
            {
                books = await _bookService.GetAllBooksAsync();
                return _mapper.Map<IEnumerable<BookViewModel>>(books).ToList();
            }
            
            books = await _bookService.GetAllBooksAsync(authorId);

            return _mapper.Map<IEnumerable<BookViewModel>>(books).ToList();

        }

        /// <summary>
        /// Get book by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            return book;
        }

        /// <summary>
        /// Creates a Book
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /books
        ///     {
        ///        "Title": "Item1",
        ///        "ISBN": true,
        ///        "publisherId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A newly created Book</returns>
        /// <response code="201">Returns the newly created book with location</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Book>> Post(Book model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var book = await _bookService.AddAsync(model);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }


        /// <summary>
        /// Update a specific book
        /// </summary>
        /// <param name="model"></param>   
        /// <param name="id"></param>   
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, [FromBody] Book model)
        {
            var bookToUpdate = await _bookService.GetBookByIdAsync(id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            bookToUpdate.Title = model.Title;
            bookToUpdate.ISBN = model.ISBN;

            model = await _bookService.UpdateAsync(bookToUpdate);

            return Ok(model);
        }

        /// <summary>
        /// Deletes a specific Book
        /// </summary>
        /// <param name="id"></param>   
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            _bookService.Remove(book);

            return Ok();
        }
    }
}
