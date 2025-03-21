using LibraryManagement.Application.Interfaces.Repositories;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly ApplicationDbContext _context;

		public BookRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Book>> GetAllBooksAsync()
		{
			return await _context.Books.Include(b => b.Author).ToListAsync();
		}

		public async Task<Book?> GetBookByIdAsync(int id)
		{
			return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
		}

		public async Task AddBookAsync(Book book)
		{
			_context.Books.Add(book);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateBookAsync(Book book)
		{
			_context.Books.Update(book);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteBookAsync(Book book)
		{
			_context.Books.Remove(book);
			await _context.SaveChangesAsync();
		}
	}
}
