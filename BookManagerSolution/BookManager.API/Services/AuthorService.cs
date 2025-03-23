using BookManager.API.DTOs;
using BookManager.API.Entities;
using BookManager.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManager.API.Services
{
	public class AuthorService : IAuthorService
	{
		private readonly ApplicationDbContext _context;

		public AuthorService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
		{
			return await _context.Authors
				.Select(a => new AuthorDTO
				{
					Id = a.Id,
					FullName = a.FullName,
					DateOfBirth = a.DateOfBirth,
					City = a.City,
					Email = a.Email
				}).ToListAsync();
		}

		public async Task<AuthorDTO?> GetAuthorByIdAsync(int id)
		{
			var author = await _context.Authors.FindAsync(id);
			if (author == null) return null;

			return new AuthorDTO
			{
				Id = author.Id,
				FullName = author.FullName,
				DateOfBirth = author.DateOfBirth,
				City = author.City,
				Email = author.Email
			};
		}

		public async Task<AuthorDTO> CreateAuthorAsync(CreateAuthorDTO authorDto)
		{
			var author = new Author
			{
				FullName = authorDto.FullName,
				DateOfBirth = authorDto.DateOfBirth,
				City = authorDto.City,
				Email = authorDto.Email
			};

			_context.Authors.Add(author);
			await _context.SaveChangesAsync();

			return new AuthorDTO
			{
				Id = author.Id,
				FullName = author.FullName,
				DateOfBirth = author.DateOfBirth,
				City = author.City,
				Email = author.Email
			};
		}
		public async Task<AuthorDTO?> UpdateAuthorAsync(AuthorDTO authorDto)
		{
			var existingAuthor = await _context.Authors.FindAsync(authorDto.Id);
			if (existingAuthor == null) return null;

			existingAuthor.FullName = authorDto.FullName;
			existingAuthor.DateOfBirth = authorDto.DateOfBirth;
			existingAuthor.City = authorDto.City;
			existingAuthor.Email = authorDto.Email;

			await _context.SaveChangesAsync();

			return new AuthorDTO
			{
				Id = existingAuthor.Id,
				FullName = existingAuthor.FullName,
				DateOfBirth = existingAuthor.DateOfBirth,
				City = existingAuthor.City,
				Email = existingAuthor.Email
			};
		}

		public async Task<bool> DeleteAuthorAsync(int id)
		{
			var author = await _context.Authors.FindAsync(id);
			if (author == null) return false;

			_context.Authors.Remove(author);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<List<BookDTO>> GetBooksByAuthorAsync(int authorId)
		{
			return await _context.Books
				.Where(b => b.AuthorId == authorId)
				.Select(b => new BookDTO
				{
					Id = b.Id,
					Title = b.Title,
					
				})
				.ToListAsync();
		}
	}
}
