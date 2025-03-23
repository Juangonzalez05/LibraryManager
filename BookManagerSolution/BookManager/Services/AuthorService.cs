using System.Net.Http.Json;
using BookManager.Blazor.Models;

namespace BookManager.Blazor.Services
{
	public class AuthorService
	{
		private readonly HttpClient _httpClient;

		public AuthorService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Author>> GetAuthorsAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Author>>("authors");
		}

		public async Task<bool> CreateAuthorAsync(CreateAuthorDTO author)
		{
			var response = await _httpClient.PostAsJsonAsync("authors", author);
			return response.IsSuccessStatusCode;
		}

		public async Task<Author> GetAuthorByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Author>($"authors/{id}");
		}

		public async Task<List<Book>> GetAuthorBooksAsync(int authorId)
		{
			return await _httpClient.GetFromJsonAsync<List<Book>>($"authors/{authorId}/books");
		}


		public async Task<bool> UpdateAuthorAsync(UpdateAuthorDTO author)
		{
			var response = await _httpClient.PutAsJsonAsync($"authors/{author.Id}", author);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteAuthorAsync(int authorId)
		{
			var response = await _httpClient.DeleteAsync($"authors/{authorId}");
			return response.IsSuccessStatusCode;
		}


	}
}
