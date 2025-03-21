using LibraryManagement.Application.Interfaces.Repositories;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
	public class AuthorRepository : IAuthorRepository
	{
		private readonly ApplicationDbContext _context;

		public AuthorRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
		{
			return await _context.Authors.ToListAsync();
		}

		public async Task<Author?> GetAuthorByIdAsync(int id)
		{
			return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task AddAuthorAsync(Author author) // 🔹 Implementar el método
		{
			_context.Authors.Add(author);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAuthorAsync(Author author)
		{
			_context.Authors.Update(author);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAuthorAsync(Author author)
		{
			_context.Authors.Remove(author);
			await _context.SaveChangesAsync();
		}
	}
}
