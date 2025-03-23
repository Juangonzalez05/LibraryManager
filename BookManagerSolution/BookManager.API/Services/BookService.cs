using BookManager.API.DTOs;
using BookManager.API.Entities;
using BookManager.API.Exceptions;
using BookManager.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManager.API.Services
{
	public class BookService : IBookService
	{
		private readonly ApplicationDbContext _context;
		private const int MaxBooksAllowed = 100; // Límite de libros

		public BookService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
		{
			return await _context.Books
				.Include(b => b.Author)
				.Select(b => new BookDTO
				{
					Id = b.Id,
					Title = b.Title,
					Year = b.Year,
					Genre = b.Genre,
					PageCount = b.PageCount,
					AuthorId = b.AuthorId,
					AuthorName = b.Author.FullName
				}).ToListAsync();
		}

		public async Task<BookDTO?> GetBookByIdAsync(int id)
		{
			var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
			if (book == null) return null;

			return new BookDTO
			{
				Id = book.Id,
				Title = book.Title,
				Year = book.Year,
				Genre = book.Genre,
				PageCount = book.PageCount,
				AuthorId = book.AuthorId,
				AuthorName = book.Author.FullName
			};
		}

		public async Task<BookDTO> CreateBookAsync(CreateBookDTO bookDto)
		{
			// Verificar si se alcanzó el límite de libros
			int bookCount = await _context.Books.CountAsync();
			if (bookCount >= MaxBooksAllowed)
				throw new BookLimitExceededException(); // ✅ Excepción personalizada

			// Verificar si el autor existe
			var author = await _context.Authors.FindAsync(bookDto.AuthorId);
			if (author == null)
				throw new AuthorNotFoundException(); // ✅ Excepción personalizada

			var book = new Book
			{
				Title = bookDto.Title,
				Year = bookDto.Year,
				Genre = bookDto.Genre,
				PageCount = bookDto.PageCount,
				AuthorId = bookDto.AuthorId
			};

			_context.Books.Add(book);
			await _context.SaveChangesAsync();

			return new BookDTO
			{
				Id = book.Id,
				Title = book.Title,
				Year = book.Year,
				Genre = book.Genre,
				PageCount = book.PageCount,
				AuthorId = book.AuthorId,
				AuthorName = author.FullName
			};
		}
		public async Task<BookDTO?> UpdateBookAsync(BookDTO bookDto)
		{
			var book = await _context.Books.FindAsync(bookDto.Id);
			if (book == null) return null;

			book.Title = bookDto.Title;
			book.AuthorId = bookDto.AuthorId;
			book.Genre = bookDto.Genre;

			await _context.SaveChangesAsync();

			return new BookDTO
			{
				Id = book.Id,
				Title = book.Title,
				AuthorId = book.AuthorId,
		
				Genre = book.Genre
			};
		}

		public async Task<bool> DeleteBookAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book == null) return false;

			_context.Books.Remove(book);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
