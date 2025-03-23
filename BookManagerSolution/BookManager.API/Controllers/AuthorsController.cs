using BookManager.API.DTOs;
using BookManager.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
	[Route("api/authors")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IAuthorService _authorService;

		public AuthorsController(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAuthors()
		{
			var authors = await _authorService.GetAllAuthorsAsync();
			return Ok(authors);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAuthorById(int id)
		{
			var author = await _authorService.GetAuthorByIdAsync(id);
			if (author == null) return NotFound("Author not found.");

			return Ok(author);
		}
		[HttpGet("{id}/books")]
		public async Task<IActionResult> GetAuthorBooks(int id)
		{
			var books = await _authorService.GetBooksByAuthorAsync(id);
			if (books == null || books.Count == 0) return NotFound("No books found for this author.");

			return Ok(books);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDTO authorDto)
		{
			if (authorDto == null) return BadRequest("Invalid data.");

			var createdAuthor = await _authorService.CreateAuthorAsync(authorDto);
			return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, createdAuthor);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDTO authorDto)
		{
			if (authorDto == null || id != authorDto.Id)
				return BadRequest("Invalid data.");

			var updatedAuthor = await _authorService.UpdateAuthorAsync(authorDto);
			if (updatedAuthor == null) return NotFound("Author not found.");

			return Ok(updatedAuthor);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAuthor(int id)
		{
			var deleted = await _authorService.DeleteAuthorAsync(id);
			if (!deleted) return NotFound("Author not found.");

			return NoContent();
		}
	}
}
