using LibraryManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Interfaces.Repositories
{
	public interface IAuthorRepository
	{
		Task<IEnumerable<Author>> GetAllAuthorsAsync();
		Task<Author?> GetAuthorByIdAsync(int id);
		Task AddAuthorAsync(Author author); // 🔹 Agregar este método
		Task UpdateAuthorAsync(Author author);
		Task DeleteAuthorAsync(Author author);
	}
}
