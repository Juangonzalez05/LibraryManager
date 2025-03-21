using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Application.Interfaces.Repositories;
using LibraryManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _bookRepository;
		private readonly IAuthorRepository _authorRepository;

		public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
		{
			_bookRepository = bookRepository;
			_authorRepository = authorRepository;
			_authorRepository = authorRepository;
		}

		public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
		{
			var books = await _bookRepository.GetAllBooksAsync();
			return books.Select(b => new BookDTO
			{
				Id = b.Id,
				Title = b.Title,
				Genre = b.Genre,
				Year = b.Year,
				AuthorName = b.Author.FullName
			}).ToList();
		}

		public async Task<BookDTO?> GetBookByIdAsync(int id)
		{
			var book = await _bookRepository.GetBookByIdAsync(id);
			if (book == null) return null;

			return new BookDTO
			{
				Id = book.Id,
				Title = book.Title,
				Genre = book.Genre,
				Year = book.Year,
				AuthorName = book.Author.FullName
			};
		}

		public async Task<BookDTO> CreateBookAsync(CreateBookDTO bookDto)
		{
			var author = await _authorRepository.GetAuthorByIdAsync(bookDto.AuthorId);
			if (author == null)
			{
				throw new Exception("El autor especificado no existe.");
			}

			var book = new Book
			{
				Title = bookDto.Title,
				Genre = bookDto.Genre,
				Year = bookDto.Year,
				PageCount = bookDto.PageCount,
				AuthorId = bookDto.AuthorId,
				Author = author // 🔹 Ahora se asigna el `Author`
			};

			await _bookRepository.AddBookAsync(book);

			return new BookDTO
			{
				Id = book.Id,
				Title = book.Title,
				Genre = book.Genre,
				Year = book.Year,
				PageCount = book.PageCount,
				AuthorName = book.Author.FullName
			};
		}




		public async Task<bool> UpdateBookAsync(int id, UpdateBookDTO bookDto)
		{
			var book = await _bookRepository.GetBookByIdAsync(id);
			if (book == null) return false;

			book.Title = bookDto.Title;
			book.Genre = bookDto.Genre;
			book.Year = bookDto.Year;
			book.AuthorId = bookDto.AuthorId;

			await _bookRepository.UpdateBookAsync(book);
			return true;
		}

		public async Task<bool> DeleteBookAsync(int id)
		{
			var book = await _bookRepository.GetBookByIdAsync(id);
			if (book == null) return false;

			await _bookRepository.DeleteBookAsync(book);
			return true;
		}
	}
}
