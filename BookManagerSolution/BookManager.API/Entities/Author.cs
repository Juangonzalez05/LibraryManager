﻿using System.ComponentModel.DataAnnotations;

namespace BookManager.API.Entities
{
	public class Author
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string FullName { get; set; } = string.Empty;

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		[MaxLength(100)]
		public string City { get; set; } = string.Empty;

		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
