using BookManager.API.DTOs;

namespace BookManager.API.Interfaces
{
	public interface IAuthorService
	{
		Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();
		Task<AuthorDTO?> GetAuthorByIdAsync(int id);
		Task<AuthorDTO> CreateAuthorAsync(CreateAuthorDTO authorDto);
		Task<bool> DeleteAuthorAsync(int id);
		Task<List<BookDTO>> GetBooksByAuthorAsync(int authorId);
		Task<AuthorDTO?> UpdateAuthorAsync(AuthorDTO authorDto);



	}
}
