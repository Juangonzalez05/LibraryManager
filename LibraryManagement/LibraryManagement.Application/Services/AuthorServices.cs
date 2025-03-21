using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Application.Interfaces.Repositories;
using LibraryManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services
{
	public class AuthorService : IAuthorService
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorService(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
		{
			var authors = await _authorRepository.GetAllAuthorsAsync();
			return authors.Select(a => new AuthorDTO
			{
				Id = a.Id,
				FullName = a.FullName,
				BirthDate = a.BirthDate,
				City = a.City,
				Email = a.Email
			}).ToList();
		}

		public async Task<AuthorDTO?> GetAuthorByIdAsync(int id)
		{
			var author = await _authorRepository.GetAuthorByIdAsync(id);
			if (author == null) return null;

			return new AuthorDTO
			{
				Id = author.Id,
				FullName = author.FullName,
				BirthDate = author.BirthDate,
				City = author.City,
				Email = author.Email
			};
		}

		public async Task<AuthorDTO> CreateAuthorAsync(CreateAuthorDTO authorDto)
		{
			var author = new Author
			{
				FullName = authorDto.FullName,
				BirthDate = authorDto.BirthDate,
				City = authorDto.City,
				Email = authorDto.Email
			};

			await _authorRepository.AddAuthorAsync(author);

			return new AuthorDTO
			{
				Id = author.Id,
				FullName = author.FullName,
				BirthDate = author.BirthDate,
				City = author.City,
				Email = author.Email
			};
		}

		public async Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDTO authorDto)
		{
			var author = await _authorRepository.GetAuthorByIdAsync(id);
			if (author == null) return false;

			author.FullName = authorDto.FullName;
			author.BirthDate = authorDto.BirthDate;
			author.City = authorDto.City;
			author.Email = authorDto.Email;

			await _authorRepository.UpdateAuthorAsync(author);
			return true;
		}

		public async Task<bool> DeleteAuthorAsync(int id)
		{
			var author = await _authorRepository.GetAuthorByIdAsync(id);
			if (author == null) return false;

			await _authorRepository.DeleteAuthorAsync(author);
			return true;
		}
	}
}
