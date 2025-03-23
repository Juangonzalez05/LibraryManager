using System.Net.Http.Json;
using BookManager.Blazor.Models;

namespace BookManager.Blazor.Services
{
	public class BookService
	{
		private readonly HttpClient _httpClient;

		public BookService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Book>> GetBooksAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Book>>("books");
		}

		public async Task<Book> GetBookByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Book>($"books/{id}");
		}

		public async Task<bool> CreateBookAsync(CreateBookDTO book)
		{
			var response = await _httpClient.PostAsJsonAsync("books", book);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateBookAsync(Book book)
		{
			var response = await _httpClient.PutAsJsonAsync($"books/{book.Id}", book);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteBookAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"books/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
