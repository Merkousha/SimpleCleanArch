using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.Application.Common.Exceptions;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Application.Interfaces;

namespace SimpleCleanArch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _bookService.GetTop10BooksAsync();
            return Ok(books);
        }


        [HttpGet("GetTop10")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetTop10()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                    return NotFound();

                return Ok(book);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("slug/{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> GetBySlug(string slug)
        {
            try
            {
                var book = await _bookService.GetBookBySlugAsync(slug);
                if (book == null)
                    return NotFound();

                return Ok(book);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetByCategory(int categoryId)
        {
            var books = await _bookService.GetBooksByCategoryIdAsync(categoryId);
            return Ok(books);
        }

        [HttpGet("author/{authorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetByAuthor(int authorId)
        {
            var books = await _bookService.GetBooksByAuthorIdAsync(authorId);
            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Create([FromBody] BookCreateDto bookCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _bookService.CreateBookAsync(bookCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto bookUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _bookService.UpdateBookAsync(id, bookUpdateDto);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}