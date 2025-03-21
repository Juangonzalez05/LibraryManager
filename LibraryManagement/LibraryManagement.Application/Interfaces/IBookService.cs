using LibraryManagement.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Interfaces
{
	public interface IBookService
	{
		Task<IEnumerable<BookDTO>> GetAllBooksAsync();
		Task<BookDTO?> GetBookByIdAsync(int id);
		Task<BookDTO> CreateBookAsync(CreateBookDTO bookDto);
		Task<bool> UpdateBookAsync(int id, UpdateBookDTO bookDto);
		Task<bool> DeleteBookAsync(int id);
	}
}
