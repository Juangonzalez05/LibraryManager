using System.ComponentModel.DataAnnotations;

namespace BookManager.API.DTOs
{
	public class CreateBookDTO
	{
		[Required]
		[MaxLength(200)]
		public string Title { get; set; } = string.Empty;

		[Required]
		public int Year { get; set; }

		[Required]
		[MaxLength(50)]
		public string Genre { get; set; } = string.Empty;

		[Required]
		public int PageCount { get; set; }

		[Required]
		public int AuthorId { get; set; }
	}
}
