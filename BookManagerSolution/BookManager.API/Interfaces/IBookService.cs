using BookManager.API.DTOs;

namespace BookManager.API.Interfaces
{
	public interface IBookService
	{
		Task<IEnumerable<BookDTO>> GetAllBooksAsync();
		Task<BookDTO?> GetBookByIdAsync(int id);
		Task<BookDTO> CreateBookAsync(CreateBookDTO bookDto);
		Task<bool> DeleteBookAsync(int id);
		Task<BookDTO?> UpdateBookAsync(BookDTO bookDto);

	}
}
