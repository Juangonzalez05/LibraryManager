using LibraryManagement.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Interfaces
{
	public interface IAuthorService
	{
		Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();
		Task<AuthorDTO?> GetAuthorByIdAsync(int id);
		Task<AuthorDTO> CreateAuthorAsync(CreateAuthorDTO authorDto);
		Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDTO authorDto);
		Task<bool> DeleteAuthorAsync(int id);
	}
}
