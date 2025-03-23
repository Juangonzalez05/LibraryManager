using BookManager.API.DTOs;
using BookManager.API.Exceptions;
using BookManager.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
	[Route("api/books")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllBooks()
		{
			var books = await _bookService.GetAllBooksAsync();
			return Ok(books);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBookById(int id)
		{
			var book = await _bookService.GetBookByIdAsync(id);
			if (book == null) return NotFound("Book not found.");

			return Ok(book);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO bookDto)
		{
			try
			{
				if (bookDto == null) return BadRequest("Invalid data.");

				var createdBook = await _bookService.CreateBookAsync(bookDto);
				return CreatedAtAction(nameof(CreateBook), new { id = createdBook.Id }, createdBook);
			}
			catch (BookLimitExceededException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
			catch (AuthorNotFoundException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
			catch (Exception)
			{
				return StatusCode(500, "An unexpected error occurred.");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDto)
		{
			if (bookDto == null || id != bookDto.Id)
			{
				return BadRequest("Invalid data.");
			}

			var updatedBook = await _bookService.UpdateBookAsync(bookDto);
			if (updatedBook == null)
			{
				return NotFound("Book not found.");
			}

			return Ok(updatedBook);
		}



		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook(int id)
		{
			var deleted = await _bookService.DeleteBookAsync(id);
			if (!deleted) return NotFound("Book not found.");

			return NoContent();
		}
	}
}
