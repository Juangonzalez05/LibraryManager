using LibraryManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Interfaces.Repositories
{
	public interface IBookRepository
	{
		Task<IEnumerable<Book>> GetAllBooksAsync();
		Task<Book?> GetBookByIdAsync(int id);
		Task AddBookAsync(Book book);
		Task UpdateBookAsync(Book book);
		Task DeleteBookAsync(Book book);
	}
}
