using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.Application.Common.Exceptions;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Application.Interfaces;

namespace SimpleCleanArch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordsController : ControllerBase
    {
        private readonly IKeywordService _keywordService;

        public KeywordsController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<KeywordDto>>> GetAll()
        {
            var keywords = await _keywordService.GetAllKeywordsAsync();
            return Ok(keywords);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KeywordDto>> GetById(int id)
        {
            try
            {
                var keyword = await _keywordService.GetKeywordByIdAsync(id);
                if (keyword == null)
                    return NotFound();

                return Ok(keyword);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("book/{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<KeywordDto>>> GetByBook(int bookId)
        {
            var keywords = await _keywordService.GetKeywordsByBookIdAsync(bookId);
            return Ok(keywords);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<KeywordDto>> Create([FromBody] KeywordCreateDto keywordCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _keywordService.CreateKeywordAsync(keywordCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] KeywordDto keywordDto)
        {
            if (id != keywordDto.Id)
                return BadRequest();

            try
            {
                await _keywordService.UpdateKeywordAsync(keywordDto);
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
                await _keywordService.DeleteKeywordAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
} 